FROM mcr.microsoft.com/dotnet/sdk:3.1 as build

WORKDIR /app

COPY ["receiving/Receive/Receive.sln", "receiving/Receive/Receive.sln"]
COPY ["receiving/Receive/Receive.Domain/Receive.Domain.csproj", "receiving/Receive/Receive.Domain/"]
COPY ["receiving/Receive/Receive.Api/Receive.Api.csproj", "receiving/Receive/Receive.Api/"]
COPY ["receiving/Receive/Receive.Domain.Tests/Receive.Domain.Tests.csproj", "receiving/Receive/Receive.Domain.Tests/"]

RUN dotnet restore receiving/Receive/Receive.sln

COPY ["receiving/Receive/Receive.Domain/*", "receiving/Receive/Receive.Domain/"]
COPY ["receiving/Receive/Receive.Api/*", "receiving/Receive/Receive.Api/"]
COPY ["receiving/Receive/Receive.Domain.Tests/*", "receiving/Receive/Receive.Domain.Tests/"]

FROM build as unittest
WORKDIR /app/receiving/Receive/Receive.Domain.Tests

FROM build as publish
WORKDIR /app

RUN dotnet publish receiving/Receive/Receive.Api/Receive.Api.csproj -c Release --no-restore -o /app/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final

ARG BUILD_NUMBER=0
ARG BUILD_TAG=local

LABEL version="3.1"
LABEL build_number=${BUILD_NUMBER}
LABEL build_tag=${BUILD_TAG}

WORKDIR /app
COPY --from=publish /app/out .

ENTRYPOINT ["dotnet", "Receive.Api.dll"]