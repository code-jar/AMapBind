msbuild ../AMapSearch/AMapSearch.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v4.4;OutDir=bin\Release\lib\monoandroid44

nuget pack amap.xamarin.android.search.nuspec -Version 7.6.0
pause