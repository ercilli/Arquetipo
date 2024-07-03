# Utiliza la imagen de SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los csproj de todos los proyectos y restaura las dependencias de manera separada para mejorar la caché de Docker layers
COPY ["Api.Example.A/Api.Example.A.csproj", "Api.Example.A/"]
COPY ["Arquetipo.Paas/Arquetipo.Paas.csproj", "Arquetipo.Paas/"]
COPY ["Arquetipo.Pom/Arquetipo.Pom.csproj", "Arquetipo.Pom/"]

# Restaura las dependencias de Api.Example.A como un paso separado
RUN dotnet restore "Api.Example.A/Api.Example.A.csproj"

# Copia el resto de los archivos de la solución
COPY . .

# Cambia al directorio del proyecto principal y construye la aplicación
WORKDIR "/src/Api.Example.A"
RUN dotnet build "Api.Example.A.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Example.A.csproj" -c Release -o /app/publish

# Utiliza la imagen base de ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Example.A.dll"]