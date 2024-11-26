#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web_Truyen_API/Web_Truyen_API.csproj", "Web_Truyen_API/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
RUN dotnet restore "./Web_Truyen_API/Web_Truyen_API.csproj"
COPY . .
WORKDIR "/src/Web_Truyen_API"
RUN dotnet build "./Web_Truyen_API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web_Truyen_API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_Truyen_API.dll"]