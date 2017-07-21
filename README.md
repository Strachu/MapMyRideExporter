# MapMyRideExporter
**MapMyRideExporter** is a command line application for exporting many MapMyRide activities at once to TCX files.

# Features
- Automatic exporting of possibly hundreds of activities to a local disk as TCX files. No need to export every single workout manually.
- Filtering of workouts by date - you can specify both start and end date of activities to export.
- Cross platform - should work on every platform with .NET / Mono implementation. Tested on Xubuntu 16.04.

# Requirements
To run the application you need:
- [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653)  
 *or*
- Equivalent version of [Mono](http://www.mono-project.com/download/)  

Additionally, if you want to compile the application you need:
- Microsoft Visual Studio 2015 or later  
 *or*
- MonoDevelop 6.2 or later

# Download
The binary releases and their corresponding source code snapshots can be downloaded at the  [releases](https://github.com/Strachu/MapMyRideExporter/releases) page.

If you would like to retrieve the most up to date source code and compile the application yourself, install git
and clone the repository by executing the command:
`git clone https://github.com/Strachu/MapMyRideExporter.git` or alternatively, click the "Download ZIP" button at the side
panel of this page.

# Usage
* Help display:  
``mono MapMyRideExporter.exe``
* Exporting all workouts starting from date 2011-04-12:  
``mono MapMyRideExporter.exe --login mylogin --password mypassword --start-date 2011-04-12 /home/janusz/workouts``
* Exporting all workouts starting from date 2011-04-12 excluding those made after 2011-06-20:  
``mono MapMyRideExporter.exe --login mylogin --password mypassword --start-date 2011-04-12 --end-date 2011-06-20 /home/janusz/workouts``

# Libraries
The application uses the following libraries:
- [CommandLineParser 2.1.1](https://github.com/gsscoder/commandline) command line parsing.
- [Newtonsoft.Json](http://www.newtonsoft.com/json) - JSON parsing.
- [NUnit 2.6.4](http://www.nunit.org/) as a unit test framework.
- [FluentAssertions 4.19.3](http://fluentassertions.com/) assertions helpers.

# Tools
During the creation of the application the following tools were used:
- MonoDevelop 6.2
- [Git](https://git-scm.com/)
- [Git Extensions](https://github.com/gitextensions/gitextensions)

# License
MapMyRideExporter is a free software distributed under the GNU LGPL 3 or later license.

See LICENSE.txt and LICENSE_THIRD_PARTY.txt for more information.

The most important point is:  
You can use, modify and distribute the application freely without any charge but you have to make public free of charge any changes to the source code (on LGPL 3 license) of the application *if* you modify the application and distribute the modified version.
