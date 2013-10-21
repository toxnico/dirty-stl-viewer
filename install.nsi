SetCompressor /SOLID lzma



;Icon stl.ico

; The name of the installer
Name "Dirty STL Viewer"

; The file to write
OutFile "DirtySTL installer.exe"

; The default installation directory
InstallDir $PROGRAMFILES32\DirtySTL

; Request application privileges for Windows Vista
RequestExecutionLevel user

Function .onInit
	;SetSilent silent
FunctionEnd

;--------------------------------

Page directory

Page instfiles

Section ""

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File DirtySTL.exe
  File DirtySTL.exe.config
  File *.dll
  
  CreateShortCut "$DESKTOP\Dirty STL Viewer.lnk" "$INSTDIR\DirtySTL.exe"
  
SectionEnd ; end the section
