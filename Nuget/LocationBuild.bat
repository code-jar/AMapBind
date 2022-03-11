msbuild ../AMapLocation/AMapLocation.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v11.0;OutDir=bin\Release\lib\monoandroid11.0

nuget pack amap.xamarin.android.location.nuspec -Version 6.0.0
pause