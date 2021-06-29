FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY . /app
WORKDIR /app
RUN dotnet build api.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0 
COPY --from=0 /app/bin/Debug/net5.0 /app
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000