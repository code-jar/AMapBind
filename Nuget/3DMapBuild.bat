msbuild ../AMap3DMap/AMap3DMap.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v6.0;OutDir=bin\Release\lib\monoandroid60

set curDir=%cd%
cd ../AMap3DMap/bin
del /S Xamarin.Android.Support.v4.dll
cd %curDir%

nuget pack amap.xamarin.android.3dmap.nuspec -Version 7.5.0
pause