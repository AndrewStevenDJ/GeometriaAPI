# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solo el archivo .csproj para optimizar cache de restore
COPY ["GeometriaAPI.csproj", "./"]

# Restaura las dependencias (nugets)
RUN dotnet restore "GeometriaAPI.csproj"

# Copia el resto del código
COPY . .

# Publica la app en Release mode
RUN dotnet publish "GeometriaAPI.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia la app compilada desde la etapa build
COPY --from=build /app/publish .

# Expone el puerto 80 para tráfico HTTP
EXPOSE 80

# Ejecuta la aplicación
ENTRYPOINT ["dotnet", "GeometriaAPI.dll"]
