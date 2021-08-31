@echo off
title Building libheif
set arch=%1
set thirdPartyPath=%2
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsall.bat" %arch%
cd ../third-party/libheif

cmake -DDAV1D_INCLUDE_DIR:PATH=%thirdPartyPath%\vcpkg\installed\x64-windows\include\dav1d -DDAV1D_LIBRARY:FILEPATH=%thirdPartyPath%\vcpkg\installed\x64-windows\lib\dav1d.lib -DJPEG_INCLUDE_DIR:PATH=%thirdPartyPath%\libjpeg-turbo -DJPEG_LIBRARY_DEBUG:FILEPATH=%thirdPartyPath%\libjpeg-turbo\Debug\jpeg.lib -DJPEG_LIBRARY_RELEASE:FILEPATH=%thirdPartyPath%\libjpeg-turbo\Debug\jpeg.lib -DLIBDE265_INCLUDE_DIR:PATH=%thirdPartyPath%\vcpkg\installed\x64-windows\include\libde265 -DLIBDE265_LIBRARY:FILEPATH=%thirdPartyPath%\vcpkg\installed\x64-windows\lib\libde265.lib -DX265_INCLUDE_DIR:PATH=%thirdPartyPath%\vcpkg\installed\x64-windows\include -DX265_LIBRARY:FILEPATH=%thirdPartyPath%\vcpkg\installed\x64-windows\lib\libx265.lib .

msbuild libheif.sln /p:Configuration=Release