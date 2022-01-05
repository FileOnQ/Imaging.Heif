@echo off
title Building libjpeg-turbo
set arch=%1
set config=%2
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/libjpeg-turbo-%arch%
cmake -G"NMake Makefiles" -DCMAKE_BUILD_TYPE=%config% .
nmake