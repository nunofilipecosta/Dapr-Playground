FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app

COPY App2/*.csproj ./
RUN dotnet restore

COPY App2/ ./
RUN dotnet build "App2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App2.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS final
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App2.dll"]