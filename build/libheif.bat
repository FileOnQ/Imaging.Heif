@echo off
title Building libheif
set arch=%1
set config=%2
set thirdPartyPath=%3
set vcvar=
set progFile=


::check default 
set vswhereFile="%ProgramFiles%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist %vswhereFile% (	
	goto setprogfile
)
goto check86



:setprogfile
set progFile=%ProgramFiles%
goto vswhereFound



:check86
set vswhereFile86="%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist "%vswhereFile86%" (
	set progFile=%vswhereFile86%
	goto vswhereFound
)
goto fileNotFound



:vswhereFound
set vcvar=
for /f "usebackq tokens=1 delims=" %%x in (`%progFile% -find **\vcvarsall.bat`) do set vcvar="%%~x"
if defined vcvar goto fileFound



:fileNotFound
echo "unable to find 'vcvarsall.bat'. visual studio c++ package needs to be installed"
exit /b 2



:fileFound
echo "vcvarsall.bat was found, continuing"

call %vcvar% %arch%
cd ../third-party/libheif-%arch%

mkdir build
cd build

cmake -G"NMake Makefiles"^
 -preset:release^
 -DDAV1D_INCLUDE_DIR:PATH=%thirdPartyPath%\dav1d-%arch%\build\include^
 -DDAV1D_LIBRARY:FILEPATH=%thirdPartyPath%\dav1d-%arch%\build\src\dav1d.lib^
 -DJPEG_INCLUDE_DIR:PATH=%thirdPartyPath%\libjpeg-turbo-%arch%^
 -DJPEG_LIBRARY_DEBUG:FILEPATH=%thirdPartyPath%\libjpeg-turbo-%arch%\jpeg.lib^
 -DJPEG_LIBRARY_RELEASE:FILEPATH=%thirdPartyPath%\libjpeg-turbo-%arch%\jpeg.lib^
 -DLIBDE265_INCLUDE_DIR:PATH=%thirdPartyPath%\libde265-%arch%^
 -DLIBDE265_LIBRARY:FILEPATH=%thirdPartyPath%\libde265-%arch%\libde265\libde265.lib^
 ..

nmake