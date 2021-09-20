FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Lab1Sharp.csproj", "./"]
RUN dotnet restore "Lab1Sharp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Lab1Sharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab1Sharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab1Sharp.dll"]
