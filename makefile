build:
	dotnet build MicrosoftGraphConsole.csproj

run:
	dotnet run --project MicrosoftGraphConsole.csproj

docker-up:
	docker compose up --build

docker-down:
	docker compose down

podman-up:
	podman compose up --build

podman-down:
	podman compose down