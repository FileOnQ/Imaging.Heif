@echo off
title Building dav1d
set arch=%1
set config=%2
for /f "usebackq delims=" %%I in (`powershell "\"%config%\".toLower()"`) do set "config=%%~I"
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/dav1d-%arch%
mkdir build
cd build
meson setup --buildtype %config% ..
ninja