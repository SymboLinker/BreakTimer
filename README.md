# Break timer

Non-annoying timer for reminding you of taking breaks.

<p align="center">
    <img src="https://raw.githubusercontent.com/SymboLinker/BreakTimer/main/BreakTimer.png" />
</p>

Click 60, 45, 30, 15, 10 or 5. The timer disappears and shows itself again after the selected number of minutes.

Optional:
- This app is designed to be non-annoying, but if you're afraid you won't take breaks with a silent reminder, you can set annoying sounds ;)
- Move the timer menu to the location you want it to reappear: mid-screen or at a corner?

## Installation

1. Download and unzip [BreakTimer.zip](https://github.com/SymboLinker/BreakTimer/raw/main/BreakTimer.zip).
2. Move the files to a folder of your choice.
3. Create two shortcuts by right clicking `BreakTimer.exe` and selecting `Create shortcut`. Then:
    1. put one shortcut on your desktop.
    2. put one shortcut in `C:\Users\YOUR USER NAME\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup` to start BreakTimer automatically when starting up Windows. (If that folder does not exist, find your `Startup` folder via `Windows + R`, `shell:startup`, `OK`.)
4. Double click the shortcut on your desktop to start BreakTimer.
5. In case Windows warns you that this app is not downloaded from the Microsoft Store and may be unsafe, select `More...` and `Run anyway` (needed only the first time).

## Notes for developers

- The optional sounds come from [SoundJay.com](https://www.soundjay.com).
- For publishing this application yourself after modifications, right-click the `BreakTimer` project in `Visual Studio`'s `Solution Explorer` and select `Publish`. Then click the `Publish` button to create/copy all `.exe` and `.dll` files required for this app into the `PublishDir` as specified in `BreakTimer\Properties\PublishProfiles\FolderProfile.pubxml`.