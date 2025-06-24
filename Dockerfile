# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos los archivos del proyecto
COPY . .

# Restaura dependencias
RUN dotnet restore

# Compila la aplicación en modo Release
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia el resultado de la compilación
COPY --from=build /app/publish .

# Expone el puerto por defecto (modifícalo si es necesario)
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "GeometriaAPI.dll"]
