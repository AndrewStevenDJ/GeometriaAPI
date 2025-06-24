# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia global.json para que la versión se use en el build
COPY global.json ./

# Copia el resto del código
COPY . ./

# Restaura dependencias
RUN dotnet restore

# Publica en Release
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia la app publicada
COPY --from=build /app/publish ./

# Expone puerto 80
EXPOSE 80

# Ejecuta la aplicación
ENTRYPOINT ["dotnet", "GeometriaAPI.dll"]
