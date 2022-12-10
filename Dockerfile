FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 12000

ENV ASPNETCORE_URLS=http://+:12000
ENV ASPNETCORE_ENVIRONMENT ASPNETCORE_ENVIRONMENT
ENV AUTHDB_HOST AUTHDB_HOST
ENV AUTHDB_DATABASE AUTHDB_DATABASE
ENV AUTHDB_USER AUTHDB_USER
ENV AUTHDB_PASSWORD AUTHDB_PASSWORD
ENV GHCLIENTID GHCLIENTID
ENV GHCLIENTSECRET GHCLIENTSECRET
ENV REDIRECTURI REDIRECTURI
ENV JWTISSUER JWTISSUER
ENV JWTAUDIENCE JWTAUDIENCE
ENV JWTDURATIONINMINUTES JWTDURATIONINMINUTES
ENV JWTPRIVATEKEY JWTPRIVATEKEY
ENV RUN_MIGRATIONS RUN_MIGRATIONS

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

# copy all the layers' csproj files into respective folders
COPY ["src/Core/AuthService.Domain/AuthService.Domain.csproj", "Core/AuthService.Domain/"]
COPY ["src/Core/AuthService.Application/AuthService.Application.csproj", "Core/AuthService.Application/"]
COPY ["src/Infrastructure/AuthService.Infrastructure/AuthService.Infrastructure.csproj", "Infrastructure/AuthService.Infrastructure/"]
COPY ["src/Infrastructure/AuthService.Persistence/AuthService.Persistence.csproj", "Infrastructure/AuthService.Persistence/"]
COPY ["src/API/AuthService.API/AuthService.API.csproj", "API/AuthService.API/"]

RUN dotnet restore "API/AuthService.API/AuthService.API.csproj"
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.API.dll"]
