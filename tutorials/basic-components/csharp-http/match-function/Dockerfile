# Building Image with SKD/Runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS BuildImage

# Publish App for linux-x64
COPY . /app
RUN dotnet publish -c Release -r linux-x64 /app/match-function.csproj

# Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set Listen PORT https://andrewlock.net/5-ways-to-set-the-urls-for-an-aspnetcore-app/#environment-variables
ENV ASPNETCORE_URLS=http://*:51502

# Get publish from BuildImage
COPY --from=BuildImage /app/bin/Release/net6.0/linux-x64/publish /app

WORKDIR /app

ENTRYPOINT ["./match-function"]