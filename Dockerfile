FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Web.API/Web.API.csproj", "src/Web.API/"]
RUN dotnet restore "src/Web.API/Web.API.csproj"
COPY . .
WORKDIR "/src/src/Web.API"
RUN dotnet build "Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Crear directorio para archivos estáticos
RUN mkdir -p /app/public
VOLUME /app/public

ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Web.API.dll"]