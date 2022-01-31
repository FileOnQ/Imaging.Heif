@echo off
title Building libheif
set arch=%1
set config=%2
set thirdPartyPath=%3
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/libheif-%arch%

mkdir build
cd build
cmake -G"NMake Makefiles"^
 -DCMAKE_BUILD_TYPE=%config%^
 -DDAV1D_INCLUDE_DIR:PATH=%thirdPartyPath%\dav1d-%arch%\build\include^
 -DDAV1D_LIBRARY:FILEPATH=%thirdPartyPath%\dav1d-%arch%\build\src\dav1d.lib^
 -DJPEG_INCLUDE_DIR:PATH=%thirdPartyPath%\libjpeg-turbo-%arch%^
 -DJPEG_LIBRARY_DEBUG:FILEPATH=%thirdPartyPath%\libjpeg-turbo-%arch%\jpeg.lib^
 -DJPEG_LIBRARY_RELEASE:FILEPATH=%thirdPartyPath%\libjpeg-turbo-%arch%\jpeg.lib^
 -DLIBDE265_INCLUDE_DIR:PATH=%thirdPartyPath%\vcpkg\installed\%arch%-windows\include^
 -DLIBDE265_LIBRARY:FILEPATH=%thirdPartyPath%\vcpkg\installed\%arch%-windows\lib\libde265.lib^
 -DWITH_X265=OFF^
 ..
 nmake