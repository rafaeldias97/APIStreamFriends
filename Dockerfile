FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
WORKDIR /app
COPY . .
RUN cd APIStreamFriends.presentation.webapi
RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/samples:aspnetapp
WORKDIR /app
COPY --from=builder /out .
ENTRYPOINT ["dotnet", "APIStreamFriends.presentation.webapi.dll"]
EXPOSE 80
