@echo off
title Building FileOnQ.Imaging.Encoders
set arch=%1
set config=%2
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../src/FileOnQ.Imaging.Heif.Encoders
msbuild /p:Platform=%arch% /p:Configuration=%config%