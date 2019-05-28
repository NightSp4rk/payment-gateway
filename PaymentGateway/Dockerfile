FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app
EXPOSE 50984
EXPOSE 44318

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["PaymentGateway/PaymentGateway.WebApi.csproj", "PaymentGateway/"]
RUN dotnet restore "PaymentGateway/PaymentGateway.WebApi.csproj"
COPY . .
WORKDIR "/src/PaymentGateway"
RUN dotnet build "PaymentGateway.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentGateway.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentGateway.WebApi.dll"]