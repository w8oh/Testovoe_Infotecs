FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CopyAppWorker/CopyAppWorker.csproj", "CopyAppWorker/"]
RUN dotnet restore "CopyAppWorker/CopyAppWorker.csproj"
COPY . .
WORKDIR "/src/CopyAppWorker"
RUN dotnet build "CopyAppWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CopyAppWorker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CopyAppWorker.dll"]
