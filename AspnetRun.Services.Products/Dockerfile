#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AspnetRun.Services.Products/AspnetRun.Services.Products.csproj", "AspnetRun.Services.Products/"]
RUN dotnet restore "AspnetRun.Services.Products/AspnetRun.Services.Products.csproj"
COPY . .
WORKDIR "/src/AspnetRun.Services.Products"
RUN dotnet build "AspnetRun.Services.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspnetRun.Services.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspnetRun.Services.Products.dll"]