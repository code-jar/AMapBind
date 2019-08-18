msbuild ../Amap2DMap/Amap2DMap.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v4.4;OutDir=bin\Release\lib\monoandroid44

nuget pack amap.xamarin.android.2dmap.nuspec -Version 5.2.1
pause