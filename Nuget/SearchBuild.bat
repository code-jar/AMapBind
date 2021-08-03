msbuild ../AMapSearch/AMapSearch.csproj /t:Clean /t:Rebuild /v:minimal /p:Configuration=Release;DebugType=none;TargetFrameworkVersion=v11.0;OutDir=bin\Release\lib\monoandroid11.0

nuget pack amap.xamarin.android.search.nuspec -Version 7.9.0
pause