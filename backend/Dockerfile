# BASE
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# FINAL
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# COPY TOOLS TO APP DIR
COPY tools/wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh