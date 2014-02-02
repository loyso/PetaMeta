@echo off
xcopy /Y /E /I /R MetaMetadata ..\BootstrapReflection\MetaMetadata
copy /Y *.cs ..\BootstrapReflection
MSBuild ..\BootstrapReflection\BootstrapReflection.csproj /p:Configuration=Debug
MSBuild ..\BootstrapReflection\BootstrapReflection.csproj /p:Configuration=Release
