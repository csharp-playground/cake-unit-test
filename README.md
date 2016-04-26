## Execute Unit Test With Cake

- โหลดไฟล์ `build.sh` จาก https://github.com/cake-build/example
- สร้างไฟล์ `packages.config` ไว้ในโฟลเดอร์ `tools`

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
    <package id="Cake" version="0.10.1" />
    <package id="NUnit.Console" version="3.0.1" />
</packages>
```

- รัน `./build.sh` เพื่อโหลด `nuget.exe` และ `cake.exe`

- แก้ไขไฟล์ `build.cake` โดยเพิ่ม Target `RunUnitTest` ดังนี้

```csharp
Task("RunUnitTest")
    .IsDependentOn("Build")
    .Does(() => {
        NUnit3("./src/Example/bin/" + configuration + "/Example.dll", new NUnit3Settings {
            NoResults = true
        });
});
```

- เขียน Unit Test ไว้ในไฟล์ `src\Example\Example.fs`

```fsharp
[<Test>]
let shouldCheckEquality() =
    1 + 1 |> should equal 2
```

- รัน Unit Test โดยใช้คำสั่ง `./build.sh`

```java
...
Test Run Summary
    Overall result: Passed
   Tests run: 1, Passed: 1, Errors: 0, Failures: 0, Inconclusive: 0
     Not run: 0, Invalid: 0, Ignored: 0, Explicit: 0, Skipped: 0
  Start time: 2016-04-26 17:55:30Z
    End time: 2016-04-26 17:55:30Z
    Duration: 0.125 seconds

Finished executing task: RunUnitTest

========================================
Default
========================================
Executing task: Default
Finished executing task: Default

Task                          Duration
--------------------------------------------------
Clean                         00:00:00.0061904
RestoreNugetPackages          00:00:00.4879480
Build                         00:00:04.1431304
RunUnitTest                   00:00:01.5413487
Default                       00:00:00.0003019
--------------------------------------------------
Total:                        00:00:06.1789194
```
