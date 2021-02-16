FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY DemoWebAPI.csproj .
RUN dotnet restore "DemoWebAPI.csproj"
COPY . .
RUN dotnet build "DemoWebAPI.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "DemoWebAPI.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# CMD [ "dotnet", "DemoWebAPI.dll" ]
# Bellow is what Heroku uses:
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DemoWebAPI.dll