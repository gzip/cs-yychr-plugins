# YY-CHR Plugins
A selection of plugins for the graphics editor YY-CHR.NET.

To install a plugin, download it from the [releases](releases) page and unzip the dll file to the `Plugins` folder of your YY-CHR installation.

The following plugins are currently available:

**CGA2BppLinearFormat** - Edit 8x8 [CGA linear](https://moddingwiki.shikadi.net/wiki/Raw_CGA_Data#Linear_CGA_data) formatted tiles found in many early DOS games.

## Building Plugins

Open the solution file (`.sln`) for the given plugin in Visual Studio and from the main menu select `Build > Build Solution`. The resulting `dll` file is written to `bin\Debug`. (Tested in Microsoft Visual Studio Community 2022.)

## Installing Plugins

Move the `dll` to the `Plugins` folder of your YY-CHR directory and open the app.
