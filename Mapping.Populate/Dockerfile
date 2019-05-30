FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /app

COPY . ./

RUN dotnet restore 
RUN dotnet publish ./Mapping.Populate.csproj --configuration Release --output out

FROM mcr.microsoft.com/dotnet/core/runtime:3.0

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Mapping.Populate.dll"]