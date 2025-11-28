FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Students.APIServer/Students.APIServer.csproj", "Server/Students.APIServer/"]
RUN dotnet restore "Server/Students.APIServer/Students.APIServer.csproj"
COPY . .
WORKDIR "/src/Server/Students.APIServer"
RUN dotnet build "Students.APIServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Students.APIServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Students.APIServer.dll"]