FROM mcr.microsoft.com/dotnet/sdk:3.1 as build

WORKDIR /app

COPY ["sending/Send/Send.sln", "sending/Send/Send.sln"]
COPY ["sending/Send/Send.Domain/Send.Domain.csproj", "sending/Send/Send.Domain/"]
COPY ["sending/Send/Send.Api/Send.Api.csproj", "sending/Send/Send.Api/"]
COPY ["sending/Send/Send.Domain.Tests/Send.Domain.Tests.csproj", "sending/Send/Send.Domain.Tests/"]

RUN dotnet restore sending/Send/Send.sln

COPY ["sending/Send/Send.Domain/*", "sending/Send/Send.Domain/"]
COPY ["sending/Send/Send.Api/*", "sending/Send/Send.Api/"]
COPY ["sending/Send/Send.Domain.Tests/*", "sending/Send/Send.Domain.Tests/"]

FROM build as unittest
WORKDIR /app/sending/Send/Send.Domain.Tests

FROM build as publish
WORKDIR /app

RUN dotnet publish sending/Send/Send.Api/Send.Api.csproj -c Release --no-restore -o /app/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final

ARG BUILD_NUMBER=0
ARG BUILD_TAG=local

LABEL version="3.1"
LABEL build_number=${BUILD_NUMBER}
LABEL build_tag=${BUILD_TAG}

WORKDIR /app
COPY --from=publish /app/out .

ENTRYPOINT ["dotnet", "Send.Api.dll"]