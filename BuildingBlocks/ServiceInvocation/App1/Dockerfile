FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app

COPY App1/*.csproj ./
RUN dotnet restore

COPY App1/ ./
RUN dotnet build "App1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App1.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS final
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App1.dll"]