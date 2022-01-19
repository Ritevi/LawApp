#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LawApp.Web/LawApp.Web.csproj", "LawApp.Web/"]
COPY ["LawApp.Rep/LawApp.Rep.csproj", "LawApp.Rep/"]
COPY ["LawApp.Common/LawApp.Common.csproj", "LawApp.Common/"]
COPY ["LawApp.Bll/LawApp.Bll.csproj", "LawApp.Bll/"]
RUN dotnet restore "LawApp.Web/LawApp.Web.csproj"
COPY . .
WORKDIR "/src/LawApp.Web"
RUN dotnet build "LawApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LawApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV "ConnectionStrings__pgConnectionString"="Host=db;Username=sa;Password=pass;Database=law_app"
ENTRYPOINT ["dotnet", "LawApp.Web.dll"]
