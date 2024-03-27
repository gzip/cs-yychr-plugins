# YY-CHR Plugins
A selection of plugins for the graphics editor YY-CHR.NET. The following plugins are currently available:

**CGA2BppLinearFormat** - Edit 8x8 [CGA linear](https://moddingwiki.shikadi.net/wiki/Raw_CGA_Data#Linear_CGA_data) formatted tiles found in many early DOS games.

## Installing Plugins

To install a plugin, download it from the [releases](https://github.com/gzip/cs-yychr-plugins/releases/latest) page and unzip the dll file to the `Plugins` folder of your YY-CHR installation.

## Building Plugins

Download or clone this repository. Open the solution file (`.sln`) for the given plugin in Visual Studio. From the main menu select `Build > Build Solution`. The resulting `dll` file is written to `bin\Debug`. Move the `dll` to the `Plugins` folder under your YY-CHR installation directory and open the app. (Tested in Microsoft Visual Studio Community 2022.)
