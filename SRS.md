# Software Requirements Specification — TalkTimer

## 1. Overview

TalkTimer is a lightweight web app for timing who speaks during meetings. Users add participants, start and pause a timer per person, and review total talk time. Only one participant can be actively timed at a time.

## 2. Features (current)

- **Add participants** — name, avatar preset (male/female default or custom), and auto-assigned keyboard ID
- **Avatar presets** — on the add form: male and female defaults, optional custom slot after editing, edit button opens the modal; selected preset is highlighted
- **Customizable avatars** — modal editor: hair, beard, shirt styles; per-category colors; skin tone; live preview (session-only)
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

## 4. Architecture choices
- Prefer smaller components, when possible
- Prefer code behind classes rather than code blocks, when possible
- Prefer local styling over global styling, when possible

## 4. Avatar system

**Current:** Layered SVG pieces (shirt, neck, face, optional beard/hair) with CSS mask tinting. On the add form, users pick a preset (male default, female default, or last custom) before adding; the chosen preset is highlighted. A custom preset appears after confirming the avatar editor modal. Look persists for the session only.

**Out of scope (unless later decided otherwise):**
- Full photo upload / face recognition
- Account-based cloud storage of avatar presets
- Disk/session persistence beyond the current page session

**Later / next iteration:**
- **Avatar config string** — encode the chosen look as a compact string so a user can copy/save it manually and paste it later to restore a previous avatar
- **Edit existing card avatar** — reopen the editor from a participant card to change that person’s avatar after add
