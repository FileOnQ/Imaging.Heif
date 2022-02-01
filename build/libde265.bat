@echo off
title Building libde265
set arch=%1
set config=%2
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/libde265-%arch%
mkdir build
cd build
cmake -G"NMake Makefiles" -DCMAKE_BUILD_TYPE=%config% ..
nmake