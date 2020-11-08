FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=https://+:443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY [".", "src/Echo.Service/"]
RUN dotnet restore "src/Echo.Service/Echo.Service.csproj"
COPY . .
WORKDIR "/src/src/Echo.Service"
RUN dotnet build "Echo.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Echo.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Echo.Service.dll"]