![GitHub](https://img.shields.io/github/license/EnderIce2/SDR-RPC)
![GitHub All Releases](https://img.shields.io/github/downloads/EnderIce2/SDR-RPC/total)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/EnderIce2/SDR-RPC)
# SDR-RPC

**SDR-RPC** is a plugin for [SDRSharp](https://airspy.com/download/) that integrates Discord Rich Presence (RPC) to provide live updates about your SDRSharp activities directly in Discord.

---

## ✨Features
- ✏Displays **frequency, playback state, and RDS information**  
- 🔌Optimized with **asynchronous code** for smoother performance  
- 📖**Logging** to help troubleshoot issues  
- 🔨**Simple installation** process 

## 🎁How to install + Demo

📽**Watch the video:**

[![](http://img.youtube.com/vi/OOnt8ytrDc0/0.jpg)](https://youtu.be/OOnt8ytrDc0 "")

## 💻Building from Source

### Prerequisites
Before you start, ensure you have the following:
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
  - [.NET 4.6](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net46-developer-pack-offline-installer)
  - [SDRSharp Plugin SDK](https://airspy.com/?ddownload=5944)
    - SDRSharp.Common.dll
    - SDRSharp.PanView.dll
    - SDRSharp.Radio.dll

### Steps

1. Clone the repository or download it as a ZIP file.  
   - To clone: Click **Code** and select "Open with Visual Studio".  
   - To download: Select "Download ZIP", extract the archive, and open `SDRSharpPlugin.DiscordRPC.sln`.  

![Captură de ecran 2020-10-26 025111.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20025111.png)

2. Build the solution in Visual Studio.  
   - If compilation fails, try moving reference files to the `/bin/Debug` or `/bin/Release` folder.  

3. Copy the compiled files to the SDR# installation directory.

## 👀Customizing RPC Images

1. Visit the [Discord Developer Portal](https://discord.com/developers/applications) and create a new application.  
   - Name it “SDRSharp” or something similar.  

![2024-11-27_02-35](https://github.com/user-attachments/assets/38eb265d-1617-470d-9804-de7cd48323ab)

2. Navigate to **Rich Presence > Assets** and upload your images.  
   - Use descriptive names for easy reference.  

![2024-11-27_02-35_1](https://github.com/user-attachments/assets/1ac8743b-e645-4e57-a3de-2170353fe7f7)

3. Go to **General Information** and copy the **Client ID**.  

![Captură de ecran 2020-10-26 023915.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20023915.png)

4. Paste the Client ID into the plugin textbox in SDRSharp and press **ENTER**.  

![Captură de ecran 2020-10-26 024024.png](https://raw.githubusercontent.com/EnderIce2/SDR-RPC/master/.github/MEDIA/Captur%C4%83%20de%20ecran%202020-10-26%20024024.png)

5. Restart SDRSharp. Your custom images will now appear in Discord.

## 📕Roadmap

### Planned Features
- Invite people to get Spy Server Address or connecting via voice chat system to listen and having the ability to change the frequency
- Change Settings Panel to match SDR# theme
- Show "Listening" instead of "Playing"
