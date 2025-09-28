function build() {
    dotnet build MicrosoftGraphConsole.csproj
}

function run() {
    dotnet run --project MicrosoftGraphConsole.csproj
}

function docker-up {
	docker-compose up --build
}

function docker-down {
	docker-compose down
}

function podman-up {
	podman-compose up --build
}

function podman-down {
	podman-compose down
}