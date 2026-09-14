# Software Requirements Specification — TalkTimer

## 1. Overview

TalkTimer is a lightweight web app for timing who speaks during meetings. Users add participants, start and pause a timer per person, and review total talk time. Only one participant can be actively timed at a time.

Live site: https://troelsmortensen.github.io/TalkTimer/

## 2. Features (current)

- **Add participants** — name, gender avatar (male/female), and auto-assigned keyboard ID
- **Participant cards** — name, ID, avatar, elapsed speech time, play/pause control
- **Exclusive timing** — starting one participant’s timer pauses any other active timer
- **Keyboard shortcuts** — IDs `1–9` and `Q`, `W`, `E`, `R`, `T` (up to 14 participants)
- **Drag-and-drop cards** — rearrange layout by dragging the avatar
- **Export** — show talk times in a summary table
- **Reset all timers** — clear every participant’s elapsed time
- **Leave confirmation** — warn before navigating away so timing data is not lost accidentally
- **Background-safe timer** — timing continues when the browser tab is not focused

## 3. Tech stack

| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core Blazor WebAssembly |
| Runtime / target | .NET 10 |
| UI | Razor components, CSS |
| Interop | JavaScript (`wwwroot/js`) for timer/counter behavior |
| Hosting | GitHub Pages (static WASM publish) |
| Solution | `SpeechTimer.sln` → single `UI` project |

## 4. Next phase — Customizable avatars

**Goal:** Let users personalize participant avatars so they resemble the people in the meeting, instead of only choosing a generic male or female image.

**Intended capabilities:**
- Customize appearance (e.g. hair, face, clothing, colors, or similar options)
- Assign a customized avatar when adding or editing a participant
- Persist the chosen look for the duration of the session (at minimum)
- Keep the existing card layout and timing UX unchanged

**Out of scope for this phase (unless later decided otherwise):**
- Full photo upload / face recognition
- Account-based cloud storage of avatar presets
