#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["NUnitTestProject1/OpahTeste.csproj", "NUnitTestProject1/"]
COPY ["Opah/Opah.Infrastructure.Shared/Opah.Infrastructure.Shared.csproj", "Opah/Opah.Infrastructure.Shared/"]
COPY ["Opah/Opah.Infrastructure.Persistence/Opah.Infrastructure.Persistence.csproj", "Opah/Opah.Infrastructure.Persistence/"]
COPY ["Opah/Opah.Domain/Opah.Domain.csproj", "Opah/Opah.Domain/"]
COPY ["Opah/Opah.Application/Opah.Application.csproj", "Opah/Opah.Application/"]
RUN dotnet restore "NUnitTestProject1/OpahTeste.csproj"
COPY . .
WORKDIR "/src/NUnitTestProject1"
RUN dotnet build "OpahTeste.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpahTeste.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpahTeste.dll"]