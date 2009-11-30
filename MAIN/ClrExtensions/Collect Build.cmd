call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\vcvarsall.bat" x86

set build-root=C:\CodePlex\tfs02\ClrExtensions\DEV\ClrExtensions

cd %build-root%

rd Builds /s /q
md Builds
cd builds
md ClrExtensions40
md ClrExtensions40-Untested
md ClrExtensions40Client
md ClrExtensions40Client-Untested
md ClrExtensions35
md ClrExtensions35-Untested
md ClrExtensions30
md ClrExtensions30-Untested
md ClrExtensions20
md ClrExtensions20-Untested
cd %build-root%

MSBuild /t:Clean /p:Configuration=Debug /v:quiet
MSBuild /t:Clean /p:Configuration=Debug-Untested /v:quiet
MSBuild /t:Clean /p:Configuration=Release-Untested /v:quiet
MSBuild /t:Clean /p:Configuration=Release /v:quiet

MSBuild /t:Rebuild /p:Configuration=Release /v:quiet
Copy "ClrExtensions40\bin\Release\*.*" "Builds\ClrExtensions40"
Copy "ClrExtensions40Client\bin\Release\*.*" "Builds\ClrExtensions40Client"
Copy "ClrExtensions35\bin\Release\*.*" "Builds\ClrExtensions35"
Copy "ClrExtensions30\bin\Release\*.*" "Builds\ClrExtensions30"
Copy "ClrExtensions20\bin\Release\*.*" "Builds\ClrExtensions20"

cd %build-root%\Builds
..\zip ClrExtensions.zip ClrExtensions40\*.* ClrExtensions40Client\*.* ClrExtensions35\*.* ClrExtensions30\*.* ClrExtensions20\*.*
cd %build-root%

MSBuild /t:Rebuild /p:Configuration=Release-Untested /v:quiet
Copy "ClrExtensions40\bin\Release-Untested\*.*" "Builds\ClrExtensions40-Untested"
Copy "ClrExtensions40Client\bin\Release-Untested\*.*" "Builds\ClrExtensions40Client-Untested"
Copy "ClrExtensions35\bin\Release-Untested\*.*" "Builds\ClrExtensions35-Untested"
Copy "ClrExtensions30\bin\Release-Untested\*.*" "Builds\ClrExtensions30-Untested"
Copy "ClrExtensions20\bin\Release-Untested\*.*" "Builds\ClrExtensions20-Untested"

cd %build-root%\Builds
..\zip ClrExtensions-Untested.zip ClrExtensions40-Untested\*.* ClrExtensions40Client-Untested\*.* ClrExtensions35-Untested\*.* ClrExtensions30-Untested\*.* ClrExtensions20-Untested\*.*
cd %build-root%

