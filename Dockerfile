FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /app

COPY ./CityRide.sln .
COPY . ./

#RUN dir
RUN dotnet restore CityRide.sln

RUN dotnet run --project ./CityRide.WebApi/CityRide.WebApi.csproj


ENTRYPOINT ["dotnet", "aspnetapp.dll"]