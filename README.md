# retirement-countdown-clock

Contains the core code that makes up the windows store app Retirement Countdown Clock.

I have decided to publish the code in the aims of providing others out there thinking of writing an app with useful examples of core features, for example how to get adaptive tiles working.  A lot of the time I have spent writing this app has been trying to find examples with very mixed success... (makes me realise how good the Java community is!)

I haven't checked in the core solution files as those contain my publisher details, so in order to use the code, 
1. Setup a new solution named "Retirement Countdown Clock"
2. Create three projects in the solution
* "Retirement Countdown Clock" (Blank App[Universal Windows]), 
* "Retirement Countdown Clock Core" (Class Library[Universal Windows]),
* "Retirement Countdown Clock Runtime Component" (Windows Runtime Component[Universal Windows])
3. Download the code and put the code in to the relevant project folders
4. In the project "Retirement Countdown Clock", open the Package.appxmanifest file and select the Declarations tab.  Using the Available Declarations drop down, select Background Tasks and click Add.  Tick the "Timer" supported task types and in the "Entry point" text box, enter "Retirement_Countdown_Clock_Runtime_Component.uk.co.vsf.retirement.task.TileUpdateTimer" (without quotes).
5. In the project "Retirement Countdown Clock", add references to "Retirement Countdown Clock Core" and "Retirement Countdown Clock Runtime Component"
6. In "Retirement Countdown Clock Core", add Nuget references to NotificationsExtensions and NotificationsExtensions.Win10
7. In "Retirement Countdown Clock Runtime Component", add Nuget references to NotificationsExtensions and NotificationsExtensions.Win10
8. In "Retirement Countdown Clock Runtime Component", add references to "Retirement Countdown Clock Core"


All the code was built using the 2015 Community edition of Visual Studio.
