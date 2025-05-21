#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base 
#RUN apt-get update && apt-get install -y wget unzip
#RUN wget https://bin.equinox.io/c/4VmDzA7iaJY/ngrok-stable-linux-amd64.zip && unzip ngrok-stable-linux-amd64.zip && mv ngrok /usr/local/bin/
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["whatsapp_webhook.csproj", "."]
RUN dotnet restore "./whatsapp_webhook.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./whatsapp_webhook.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./whatsapp_webhook.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "whatsapp_webhook.dll"]