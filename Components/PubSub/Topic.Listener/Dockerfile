#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY ["Topic.Listener/Topic.Listener.csproj", "Topic.Listener/"]
RUN dotnet restore "Topic.Listener/Topic.Listener.csproj"
COPY . .
WORKDIR "/Topic.Listener"
RUN dotnet build "Topic.Listener.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Topic.Listener.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS final
WORKDIR /app

EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Topic.Listener.dll"]