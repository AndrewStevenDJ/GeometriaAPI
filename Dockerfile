# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo el proyecto
COPY . .

# Restaura paquetes y publica en Release
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia solo los archivos publicados de la etapa build
COPY --from=build /app/publish .

# Listar archivos para verificar (opcional)
RUN ls -l /app

# Puerto expuesto
EXPOSE 80

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "GeometriaAPI.dll"]
