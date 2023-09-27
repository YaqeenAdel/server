# Use a Linux-based image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

WORKDIR /app

EXPOSE 80

# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY ["./Yaqeen.Backend.sln", "YaqeenBackend/"]
COPY ["./YaqeenApi/YaqeenApi.csproj", "YaqeenBackend/YaqeenApi/"]
COPY ["./YaqeenDAL/YaqeenDAL.csproj", "YaqeenBackend/YaqeenDAL/"]
COPY ["./YaqeenInfrastructure/YaqeenInfrastructure.csproj", "YaqeenBackend/YaqeenInfrastructure/"]
COPY ["./YaqeenServices/YaqeenServices.csproj", "YaqeenBackend/YaqeenServices/"]

RUN dotnet restore "YaqeenBackend/Yaqeen.Backend.sln"

COPY . ./YaqeenBackend/

WORKDIR "/src/YaqeenBackend"

RUN dotnet build "Yaqeen.Backend.sln" -c Release

# Publish each project
RUN dotnet publish YaqeenApi/YaqeenApi.csproj -c Release -o /app/publish/YaqeenApi
RUN dotnet publish YaqeenDAL/YaqeenDAL.csproj -c Release -o /app/publish/YaqeenDAL
RUN dotnet publish YaqeenInfrastructure/YaqeenInfrastructure.csproj -c Release -o /app/publish/YaqeenInfrastructure
RUN dotnet publish YaqeenServices/YaqeenServices.csproj -c Release -o /app/publish/YaqeenServices

# Add more RUN lines for additional projects if needed

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the published output from each project into the final image
COPY --from=build /app/publish/YaqeenApi .
COPY --from=build /app/publish/YaqeenDAL .
COPY --from=build /app/publish/YaqeenInfrastructure .
COPY --from=build /app/publish/YaqeenServices .

# Set the entry point to start your application
ENTRYPOINT ["dotnet", "Yaqeen.Backend.dll"]