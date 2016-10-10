dotnet pack ./TaroWork.LetsRest/project.json -c Release -o ./publish

nuget push "./publish/TaroWork.LetsRest.0.2.1.nupkg" -Source https://www.nuget.org/api/v2/package
