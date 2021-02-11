# Unitor [![](https://img.shields.io/github/v/release/BitCrackers/Unitor?style=flat-square)](https://github.com/BitCrackers/Unitor/latest) [![Discord](https://img.shields.io/badge/Discord-Invite-7289DA.svg?logo=Discord&style=flat-square)](https://discord.gg/AUpXd3VUh8) [![Paypal](https://img.shields.io/badge/PayPal-Donate-Green.svg?logo=Paypal&style=flat-square)](https://www.paypal.com/donate/?hosted_button_id=TYMU92FD9D9UW)

## Features
* Analyse any windows unity game that doesn't have custom encryption.
* Support for both Mono and Il2Cpp scripting backend.
* Function dissasembly for both il and assembly code.
* Method structure analysis: see what methods are never called(not optimzed/perfect)

### Planned features
* BepInEx auto installer
* Deobfuscation using json mappings generated by [Beebyte-Deobfuscator](https://github.com/OsOmE1/Beebyte-Deobfuscator)
* Asset browser
* String table references

### Screenshots
![](https://i.imgur.com/k467Df7.png)

### Installation
1. Download the latest release from the [releases](https://github.com/BitCrackers/Unitor/releases/latest) page, or [build from source](#building-from-source).
2. Extract the archive.
3. Run the executable.


### Building from source
1. Clone the repository:  
   `$ git clone https://github.com/BitCrackers/Unitor.git`
2. Clone the Il2CppInspector and Beebyte-Deobfuscator  
   `$ git clone https://github.com/OsOmE1/Beebyte-Deobfuscator.git`  
   `$ git clone --recursive https://github.com/djkaty/Il2CppInspector`
3. Replace all the paths to the dependecy dlls in the .csproj file
4. Build with visual studio.
