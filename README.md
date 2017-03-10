# JSON 3-Ways
```json 
{ "Saying": "Trust the universe, but tie up your camels" } 
```
## Introduction
In a recent C# project I worked on, the team seemed to spend a great deal of time on getting the JSON
serialization/de-serialization right. I also  wonder how hard this task is in C# compared to python and nodejs.
The following is reading JSON from a file using .Net core (dotnet), python and node.js on Ubuntu.  

## Objective
Read the following JSON from a file and print the resulting object to STD out.
```json
[{
    "firstName": "Nikki",
    "lastName": "Alexander",
    "title": "Dr"
}]
```
The file contains a simple list of a 'person' object to silently witness the three techniques in action.
All the code for this blog can be found [here.](https://github.com/rockonsoft/camelJson)

## Dot Net Core
The inspiration for the code comes from [here.](http://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp)

According to this article the simples solution would be to use the widely used package, Newtonsoft.Json.
So the first thing would be to install the package. In the normal Visual Studio tooling this is quite a trivial task.
All three the target languages and runtimes has their own package management system.

| Language/Run-Time|Package Manager|
|-----------------------|----------------------|
| .Net Core | NuGet (wrapped with dotnet add package)|
| Python | pip |
| Node.js | nmp |

Unfortunately, I had an older version of the dotnet core installed,. This version did not have the 
```dotnet add package``` option, so I had to update my dotnet core installation. (see the notes section)  

#### Creating the project
To create the project:
* ```dotnet new console``` creates the basic structure and project file. This has changed since the previous release and 
there seems to be a lot more templates to choose from to create new projects. Wheres as most of the project files in the previous 
version was json, a few xml files, like the core.scproj (more familiar to VS users)
*  To add the dependancy on Newtonsoft.Json ``` dotnet add package newtonsoft.json ```. This updates the csproj file.
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
* It is possible to restore the packages to a directory using the --package switch ```dotnet restore core.csproj --packages ./packages```
* The to read the file:
```csharp 
  using (StreamReader r = File.OpenText(fullFilePath))
  {
      string json = r.ReadToEnd();
      List<Person> items = JsonConvert.DeserializeObject<List<Person>>(json);
      
      return items;
  }
```
* The code to get the properties of the JSON object is displayed:
```csharp
    foreach(var p in list)
    {
        System.Console.WriteLine($"Title: {p.title}");
        System.Console.WriteLine($"FirstName: {p.firstName}");
        System.Console.WriteLine($"LastName: {p.lastName}");
    }
```

The code is working fine. 

## Using Python
The inspiration for the code comes from [here.](http://stackoverflow.com/questions/2835559/parsing-values-from-a-json-file-using-python)
The process is very straight forward:
* Create the file.
* Edit the code.
* Test and debug.
The code could not be more simple:```python
with open(fileName) as data_file:    
    list = json.load(data_file)

    for person in list:
        print('Title: ' + person["title"])
        print('FirstName: ' + person["firstName"])
        print('LastName: ' + person["lastName"])

```
Run the script with ```'python' read.py ../data/simple.json```
This was a quick typing exercise.

## Using Node.js
The inspiration for the code comes from [here.](http://stackoverflow.com/questions/10011011/using-node-js-how-do-i-read-a-json-object-into-server-memory)

Using the async methods the code looks like this:
```js
function testJson(fileName){
    var fs = require('fs');
    var obj;
    fs.readFile(fileName, 'utf8', function (err, data) {
        if (err) throw err;
        list = JSON.parse(data);
        list.forEach(function(person) {
            console.log('Title: ' + person.title);
            console.log('FirstName: ' + person.firstName);
            console.log('Last Name: ' + person.lastName);
        }, this);
    });
};
```

This was again more or less some typing exercise.
Run the script with ```node readjson.js ../data/simple.json```

## Conclusion
* This is quite a trivial exercise, but a nice way to do a roundup of all the relevant tooling for .Net Core, Python and Node.js.
* It took me about three times longer to get the .Net core solution going that with Python and Node.js. It also helps that Ubuntu comes with 
  Python and Node.js pre-installed.
* Manipulating JSON just feels more part of the languages when using Python and Javascript.
* That said, .Net core is cool and would only get better. In my mind it is geared towards bigger solutions.
* If you want to do something quick and dirty involving a lot of JSON, Python and Node.js rocks.
