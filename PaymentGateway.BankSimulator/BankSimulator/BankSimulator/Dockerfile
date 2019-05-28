FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53318
EXPOSE 44331

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["BankSimulator/BankSimulator.csproj", "BankSimulator/"]
RUN dotnet restore "BankSimulator/BankSimulator.csproj"
COPY . .
WORKDIR "/src/BankSimulator"
RUN dotnet build "BankSimulator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BankSimulator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BankSimulator.dll"]