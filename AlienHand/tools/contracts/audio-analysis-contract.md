# Audio Analysis Contract

Implements the authority described by:

- [Audio_Processing.md](C:/Project/Minigames/schema/Audio_Processing.md)

Command:

```text
audio_analyze.py inspect --input <wav> [--output <json>] [--preset battleship]
audio_analyze.py compare --candidate <wav> --reference <wav> [--output <json>]
```

Required behavior:

- inspect waveform metadata
- report duration, sample rate, channel count
- report peak and RMS
- estimate transient density and zero-crossing rate
- provide bounded judgment hints

Output contract:

- JSON report
- includes `subject`, `metrics`, `judgment`, and `uncertainty`
