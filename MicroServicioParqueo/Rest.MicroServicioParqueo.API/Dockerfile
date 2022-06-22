#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Rest.MicroServicioParqueo.API/Rest.MicroServicioParqueo.API.csproj", "Rest.MicroServicioParqueo.API/"]
COPY ["Rest.MicroServicioParqueo.Infraestructure/Rest.MicroServicioParqueo.Infraestructure.csproj", "Rest.MicroServicioParqueo.Infraestructure/"]
COPY ["Rest.MicroServicioParqueo.Dominio/Rest.MicroServicioParqueo.Dominio.csproj", "Rest.MicroServicioParqueo.Dominio/"]
COPY ["Rest.MicroServicioParqueo.Application/Rest.MicroServicioParqueo.Application.csproj", "Rest.MicroServicioParqueo.Application/"]
RUN dotnet restore "Rest.MicroServicioParqueo.API/Rest.MicroServicioParqueo.API.csproj"
COPY . .
WORKDIR "/src/Rest.MicroServicioParqueo.API"
RUN dotnet build "Rest.MicroServicioParqueo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rest.MicroServicioParqueo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rest.MicroServicioParqueo.API.dll"]