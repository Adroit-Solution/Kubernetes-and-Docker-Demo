# -----------------------------
# Stage 1: Build
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Backend

# Copy csproj and restore dependencies first (leverages Docker cache)
COPY *.csproj ./
RUN dotnet restore

# Copy full source and publish
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# -----------------------------
# Stage 2: Runtime
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Expose port (adjust if needed)
EXPOSE 8080

# Environment config (optional but recommended)
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Start application
ENTRYPOINT ["dotnet", "DockerDemo.dll"]
