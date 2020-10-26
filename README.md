![GitHub](https://img.shields.io/github/license/EnderIce2/SDR-RPC)
![GitHub All Releases](https://img.shields.io/github/downloads/EnderIce2/SDR-RPC/total)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/EnderIce2/SDR-RPC)
[![CodeFactor](https://www.codefactor.io/repository/github/enderice2/sdr-rpc/badge?s=6ea1f91b515716a019633ad07f7d3138bc136f22)](https://www.codefactor.io/repository/github/enderice2/sdr-rpc)
![Twitter Follow](https://img.shields.io/twitter/follow/enderice22?style=flat)
# SDR-RPC

SDR-RPC is an [SDRSharp](https://airspy.com/download/) plugin that adds Discord RPC feature in it

---

### Features
- Enable / Disable
- Showing frequency, play state and RDS almost in realtime
- Most of the code is made asynchronous
- Logging for troubleshooting problems
- Easy to install
- Invite feature (give Spy Server Address or listen using voice chat system) [coming soon]

---

### How to install

Video:
[![](http://img.youtube.com/vi/Otn-xSn_ioI/0.jpg)](http://www.youtube.com/watch?v=Otn-xSn_ioI "")

---

### Example

Video:
[![](http://img.youtube.com/vi/7k02dPqAjBA/0.jpg)](http://www.youtube.com/watch?v=7k02dPqAjBA "")

---

### Building by yourself

1. You need to download these stuff before compiling:
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
  - [.NET 4.6](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net46-developer-pack-offline-installer)
  - SDRSharp files (for References)
    - SDRSharp.exe
    - SDRSharp.Common.dll
    - SDRSharp.PanView.dll
    - SDRSharp.Radio.dll

2. Click "Code" and select "Open with Visual Studio" or "Download ZIP"
![Captură de ecran 2020-10-26 025111.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20025111.png)
3. If you downloaded as ZIP, unzip the archive and double click on "SDRSharpPlugin.DiscordRPC.sln"
4. Build it and move files to SDR# location (if the compile fails try copying Reference files into /bin/Debug or /bin/Release folder)

---

### Setting your custom images on RPC

1. Go to https://discord.com/developers/applications and create your own application
2. Name it "SDRSharp" or something similar
![Captură de ecran 2020-10-26 023639.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20023639.png)
3. Go to Rich Presence > Rich Presence Assets and add your own images with these names:
![Captură de ecran 2020-10-26 023706.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20023706.png)
4. Go back to General Information and copy Client ID
![Captură de ecran 2020-10-26 023915.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20023915.png)
5. Paste the Client ID you copied earlier in plugin textbox from SDRSharp and press the ENTER key
![Captură de ecran 2020-10-26 024024.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20024024.png)
6. Restart the SDRSharp and it should be changed with your custom images

---

### TODO List

- Invite people to get Apy Server Address or connecting via voice chat system to listen and having the ability to change the frequency
- Change Settings Panel to WPF User Control
- Add better RDS decoder (if it is even possible)
