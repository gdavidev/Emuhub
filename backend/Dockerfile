# ======== DEVELOPMENT TARGET ========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
WORKDIR /app
COPY . .
RUN apt-get update && apt-get install -y
RUN chmod +x tools/wait-for-it.sh

# ======== PRODUCTION TARGET (BUILD) ========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY . .
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish

# ======== PRODUCTION TARGET (SERVE) ========
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /app

RUN apt-get update && \
    apt-get install -y && \
    rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .
COPY ./tools/wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh

