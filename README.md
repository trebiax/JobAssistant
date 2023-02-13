# Run project through IIS
- Open .sln file which is in root folder
- Execute via IIS

# Run project through kestrel
In root folder execute:
- `dotnet run --urls=http://localhost:80 --project JobAssistant`
- Navigate to `http://localhost:80/swagger/index.html`

# Run project using docker image:
In root folder execute:
- `docker build -f .\Dockerfile -t job-assistant:1 .`
- `docker run -p 80:80 job-assistant:1`
- Navigate to `http://localhost:80/swagger/index.html`


# ---
Test/example data is provided in body of `POST` request in swagger UI
