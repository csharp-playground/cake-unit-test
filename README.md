#### รันเทสด้วย Cake

- โหลดไฟล์ `build.sh` จาก https://github.com/cake-build/example
- สร้างไฟล์ `packages.config` ไว้ในโฟลเดอร์ `tools`

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
    <package id="Cake" version="0.10.1" />
    <package id="NUnit.Console" version="3.0.1" />
</packages>
```

- รัน `sh build.sh` เพื่อโหลด `nuget.exe` และ `cake.exe`
