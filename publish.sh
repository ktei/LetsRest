dotnet pack ./TaroWork.LetsRest/project.json -c Release -o ./publish

nuget push "./publish/TaroWork.LetsRest.0.1.0.nupkg" -ApiKey 2680c47b-7caa-421b-8006-36160357bb2b -Source https://www.nuget.org/api/v2/package
