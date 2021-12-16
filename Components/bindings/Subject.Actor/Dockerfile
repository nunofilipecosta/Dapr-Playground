#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY ["Subject.Actor/Subject.Actor.csproj", "Subject.Actor/"]
RUN dotnet restore "Subject.Actor/Subject.Actor.csproj"
COPY . .
WORKDIR "/Subject.Actor"
RUN dotnet build "Subject.Actor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Subject.Actor.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS final
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Subject.Actor.dll"]