# Talk timer

This is a hobby project, I created for by best bro Jesper <3

He needed an app to time who is speeking in meetings.

So, I have created a Blazor WASM site to setup the meeting participants, and you can start and stop the timer for each participant.

It is hosted here: https://troelsmortensen.github.io/TalkTimer/

To add participant:
* insert a name
* Click the avatar icon to change gender
* press the "tilføj" button.
* If the input field is still in focus, you can press enter to add a participant

Each participant is represented with a card, with
* name
* id, in ( ) after the name
* avatar
* the speech time
* button to start/pause speech time recording

You can drag the cards by dragging the avatar. It's a bit clunky, if your mouse exits the participant card, you drop the dragging, and have to pick the card up again. This probably won't be improved further.

You can start the time recorder for a participant by clicking the "play" button. Pressing the play button will pause the other talking participant, if any. It is assumed only one talks at a time.

You can press keys on the keyboard according to their id, to start/pause recording. I have support for 14 participants, per Jesper's request. They will be given the ids: 1-9qwert.


## Version 1.0
Features:
* Add participants
* Start/stop recording time for participants

## Version 2.0
Features:
* Display the time per participant in a table, with the new top-right "export" button.

## Version 3.0
Features:
* Added button to reset all the timers, top right.

## Version 3.1
Fixes:
* Improved the participant card dragging slightly.
