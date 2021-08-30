@echo off
title Building libjpeg-turbo
set arch=%1
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/libjpeg-turbo
cmake .
msbuild libjpeg-turbo.sln /p:Configuration=Release