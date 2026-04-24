-- netplay_client_udp.lua — BizHawk <-> Hub (UDP data, TCP control)
local socket = require("socket")
local json   = require("json")

local HOST         = "127.0.0.1"
local TCP_PORT     = 27777
local UDP_PORT     = 27778
local PROTO        = 1
local MAGIC        = 0x4F424A48  -- 'OBJH'
local TYPE_OBS     = 1
local TYPE_TICK    = 2

local function pack_hdr(magic, proto, type_, session, frame, player, flags)
  -- big-endian 24-byte header
  local function be16(x) return string.pack(">I2", x) end
  local function be32(x) return string.pack(">I4", x) end
  return table.concat({
    be32(magic),
    be16(proto),
    be16(type_),
    be32(session),
    be32(frame),
    be16(player),
    be16(flags or 0),
  })
end

local function unpack_hdr(s)
  if #s < 24 then return nil end
  local magic, proto, type_, session, frame, player, flags =
    string.unpack(">I4 I2 I2 I4 I4 I2 I2", s)
  if magic ~= MAGIC then return nil end
  return {
    proto = proto, type = type_, session = session,
    frame = frame, player = player, flags = flags
  }, string.sub(s, 25)
end

-- TCP control
local tcp = assert(socket.tcp()); tcp:settimeout(0); assert(tcp:connect(HOST, TCP_PORT))
local function send_tcp(tbl) tcp:send(json.stringify(tbl).."\n") end
local function recv_tcp()
  local line = tcp:receive("*l")
  return line and json.parse(line) or nil
end

-- UDP data
local udp = assert(socket.udp()); udp:settimeout(0); udp:setpeername(HOST, UDP_PORT)

-- Handshake (TCP)
send_tcp({type="HELLO", proto=PROTO, name=os.getenv("USERNAME") or "Player"})
local player, session = nil, 0
repeat
  local m = recv_tcp(); if m and m.type=="JOIN_OK" then player=m.player; session=12345 end
  emu.yield()
until player
send_tcp({type="READY", player=player})

local frame = 0

local function observation()
  return {
    player = player,
    game = gameinfo.getromname(),
    t = frame,
    fps = client.get_approx_framerate(),
    mem = {}, hud = {},
    vision = {mode="none", w=0, h=0, bytes=""}, audio={rms={}}
  }
end

while true do
  -- 1) send OBS via UDP
  local obs_json = json.stringify(observation())
  local pkt = pack_hdr(MAGIC, PROTO, TYPE_OBS, session, frame, player, 0) .. obs_json
  udp:send(pkt)

  -- 2) wait nonblocking for TICK[frame] (or newer)
  local data = udp:receive()
  if data and #data >= 24 then
    local hdr, body = unpack_hdr(data)
    if hdr and hdr.type == TYPE_TICK and hdr.frame >= frame then
      local tick = json.parse(body)
      -- apply my slice
      local my = nil
      for _,c in ipairs(tick.controllers or {}) do
        if c.port == player then my = c; break end
      end
      if my then
        local pad = {}; for _,b in ipairs(my.buttons or {}) do pad[b]=true end
        joypad.set(player, pad)
      end
      emu.frameadvance()
      frame = hdr.frame + 1
    else
      -- not for me/too old; ignore
      emu.yield()
    end
  else
    -- No TICK yet; yield and try again (hub deadline will emit)
    emu.yield()
  end
end
