#!/bin/bash
pushd src/MessagePack
dotnet build -c Release || exit 1
popd

#nuget push "`ls -Art bin/Packages/Release/NuGet/*.nupkg | grep 'Flexem.MessagePack.Annotations' | tail -n 1`" -Source https://nexus.flexem.net/repository/nuget-flexem/
nuget push "`ls -Art bin/Packages/Release/NuGet/*.nupkg | grep 'Flexem.MessagePack.[0-9]' | tail -n 1`" -Source https://nexus.flexem.net/repository/nuget-flexem/
