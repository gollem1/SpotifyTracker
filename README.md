# Spotify Song Tracker
Simple program that tracks what song is playing on Spotify and displays it in your choice of format (txt, png, gif).

Thanks to [Magik.NET](https://github.com/dlemstra/Magick.NET), for handling the mystery that is transparency in GIFs

I made this for my wife, please consider following her [twitch](https://www.twitch.tv/autumnmae).

----------------------------

### Usage

1. Extract the release zip file into the folder of your choosing
2. Run SoptifySongTracker.exe.
3. Right click on the icon on the right side of your task bar to get to the various settings, change the output type, font, colors, and size of the image output
4. The output file (of the type you chose in step 3) will be located in <install_directory>\out\song.\<format> , which you can then add as a source in OBS/SLOBS/whatever

### Notes

- If you're concerned about performance/have a lower end computer then I would not recommend using the GIF output type, as it tends to use between 4-6% of CPU during output generation. PNG and TXT output is MUCH faster and uses hardly any CPU.
- Tested on x64 architecture only, Magik.NET's any CPU library causes issues on my system, so I can't guarantee stability at the moment for non-x64 processors. Since pretty much everybody has x64 CPUs apart from RPIs and new Macs (neither of which are great for recording/streaming anyway), this is a low priority issue. Will take another look at this some time in the future.
