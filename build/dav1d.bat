@echo off
title Building dav1d
set arch=%1
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/dav1d-%arch%
mkdir build
cd build
meson ..
ninja