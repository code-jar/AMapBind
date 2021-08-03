msbuild ../AMap3DMap/AMap3DMap.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v11.0;OutDir=bin\Release\lib\monoandroid11.0

nuget pack amap.xamarin.android.3dmap.nuspec -Version 8.0.0
pause