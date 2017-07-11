all: cleanup restore build run

cleanup:
	dotnet clean src/devWarsztaty-GatewayService

restore:
	dotnet restore src/devWarsztaty-GatewayService

build:
	dotnet build src/devWarsztaty-GatewayService
	
run:
	dotnet run -p src/devWarsztaty-GatewayService/devWarsztaty-GatewayService.csproj