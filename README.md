# JSON 3-Ways

First objective
## Create a simple app/script that could parse a JSON file.

### Dot Net Core
http://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp
using this as an reference

#### Notes
1. Create project folders 
2. Create new project with ```bash dotnet new```
3. Open VSCode in the folder with ```bash code .```
4. VS Code ask to restore packages and build - this is cool

5. But then there was no dotnet add - 
* Remove dotnet with scrip 
* sudo apt-get update
* supo apt-get install (https://www.microsoft.com/net/core#linuxubuntu)
* sudo apt-get install dotnet-dev-1.0.1

Dotnet was revamped and has a lot more options
On new you could select a new template which I selected conole to create the console application

Strage - where before I had json project files - these are now all gone and xml is back
```bash
 dotnet add package newtonsoft.json
Microsoft (R) Build Engine version 15.1.548.43366
Copyright (C) Microsoft Corporation. All rights reserved.

  Writing /tmp/tmp2pl2sA.tmp
info : Adding PackageReference for package 'newtonsoft.json' into project '/home/hano/src/camelJson/core/core.csproj'.
log  : Restoring packages for /home/hano/src/camelJson/core/core.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 282ms
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/9.0.1/newtonsoft.json.9.0.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/9.0.1/newtonsoft.json.9.0.1.nupkg 217ms
info : Package 'newtonsoft.json' is compatible with all the specified frameworks in project '/home/hano/src/camelJson/core/core.csproj'.
info : PackageReference for package 'newtonsoft.json' version '9.0.1' added to file '/home/hano/src/camelJson/core/core.csproj'.
```

dotnet restore core.csproj --packages ./packages

dotnet build
dotnet run ../data/simple.json


## Using Python
http://stackoverflow.com/questions/2835559/parsing-values-from-a-json-file-using-python


## Using Node.js
http://stackoverflow.com/questions/10011011/using-node-js-how-do-i-read-a-json-object-into-server-memory
