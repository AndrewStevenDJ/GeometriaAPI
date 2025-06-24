# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todos los archivos del proyecto al contenedor
COPY . ./

# Restaurar paquetes
RUN dotnet restore

# Compilar el proyecto
RUN dotnet publish -c Release -o out

# Etapa final - imagen más ligera para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Comando que se ejecuta cuando el contenedor se inicia
ENTRYPOINT ["dotnet", "Geometria.dll"]
