FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Web.API/Web.API.csproj", "src/Web.API/"]
RUN dotnet restore "src/Web.API/Web.API.csproj"
COPY . .
WORKDIR "/src/src/Web.API"

# Instalar la herramienta dotnet-ef
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "ef", "database", "update"]