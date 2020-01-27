msbuild ../AMapLocation/AMapLocation.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v4.4;OutDir=bin\Release\lib\monoandroid44

nuget pack amap.xamarin.android.location.nuspec -Version 4.8.0
pause