# hardware-monitor-server

A real-time hardware monitor server providing API to be consumed through http. Used by Sentient (http://sentientapp.com).

Simply open the solution with Visual Studio and install Nu-Get packages. Set HardwareMonitorApplication as start up project and let it go.
You need to run Visual Studio as Administrator to be able to read hardware sensors.

Default server port is 6620.

API:
- /api/cpu
- /api/gpu
- /api/drives
- /api/memory
- /api/network
- /api/storage

This software uses https://github.com/openhardwaremonitor
