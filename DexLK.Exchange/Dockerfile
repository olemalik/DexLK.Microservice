#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
# WORKDIR /src
# COPY ["DexLK.Exchange/DexLK.Exchange.csproj", "DexLK.Exchange/"]
# RUN dotnet restore "DexLK.Exchange/DexLK.Exchange.csproj"
# COPY . .
# WORKDIR "/src/DexLK.Exchange"
# RUN dotnet build "DexLK.Exchange.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "DexLK.Exchange.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DexLK.Exchange.dll"]

##############################################################################

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /app
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 80  

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DexLK.Exchange.csproj", "./"]
RUN dotnet restore "./DexLK.Exchange.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DexLK.Exchange.csproj" -c Release -o /app
FROM build AS publish
RUN dotnet publish "DexLK.Exchange.csproj" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DexLK.Exchange.dll"]

