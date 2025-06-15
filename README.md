# EmuHub - Emulator Manager Platform
## Links
- **Deploy Backend**: http://144.22.133.234:5000
- **Deploy Frontend**: http://144.22.133.234:8080
- **API Documentation**: http://144.22.133.234:5000/scalar

## The Stack
- **Frontend:**
  - Main Tech: Typescript on React with Vite and Tailwind;
  - Component Libraries: SwiperJS and MUI Components;
  - Tool Libraries: ReactQuery and Axios for HTTP Requests handling and js-cookie;
  - Testing: Vitest and react-testing-library.
- **Back API:** 
  - Main Tech: C#.NET 8, Controller based API
  - Libraries: EF Core, MailKit, FluentValidation
  - Testing: xUnit
- **Infrastructure**:
  - Cloud Provider: Hosted at a OracleCloud instance on Docker
  - Database: PostgresSQL
  - Storage: Minio Container
- **Desktop Client:** 
  - Main Tech: Delphi
  - Download link: https://github.com/Denis-Saavedra/EmuHub-Desktop

## Emuhub - Backend
### Initializing The Project
```bash
npm run dev

http:localhost:5173
```

## Emuhub - Backend
### Initializing The Project
```bash
# In the project root
## Development 
docker compose -f docker-compose.infra.yml up --build -d
docker compose up --build -d

## Release (Ignore override file)
docker compose -f docker-compose.infra.yml up --build -d
docker compose -f docker-compose.yml up --build -d

## Turn off Running containers
docker compose -f docke-compose.infra.yml down
docker compose -f docker-compose.yml down
```

### Database Migrations
```bash
cd ./backend/

# Adding migration
dotnet ef migrations add <migration_name> -p Emuhub.Infrastructure -s Emuhub.API \
  --msbuildprojectextensionspath Emuhub.API/obj/local

# Updating the database with current migrations
dotnet ef database update -p Emuhub.Infrastructure -s Emuhub.API \
  --msbuildprojectextensionspath Emuhub.API/obj/local
```
**Note**: On the first run, ef core will complain about a `*csproj.EntityFrameworkCore.targets` file,
which needs to be created in both projects, Infrastructure and API, when you face this issue,
change the param `msbuildprojectextensionspath` to run on the Infrastructure project before
finally running in the API project, which will add the migration just fine.
**Note 2**: In Ubuntu the EF target files are not being created automatically.

### Running Commands in the Container
```bash
docker exec -it <container-hash-or-name> psql \
  -h localhost -U postgres -d <database-name> -c "<your-sql-command>"
```

### How to send the container to the VPS
```bash
docker login \
  --username <your-github-username> \
  --password <your-github-token-with-access-to-your-packages>

# Build the production images and push to github container registry
docker compose -f docker-compose.yml build
docker push ghcr.io/<your-username>/emuhub-backend:latest
docker push ghcr.io/<your-username>/emuhub-frontend:latest

# Send required files to the vps (If some of these files changed)
scp -i <ssh-private-token-file-path> \
 .env docker-compose.infra.yml docker-compose.deploy.yml \
  <user>@<vps-ip>:~/Emuhub

# Ssh into the VPS and execute the services
ssh -i <ssh-private-token> <user>@<vps-ip>

# Start the containers
docker compose -f docker-compose.infra.yml up -d && docker compose -f docker-compose.deploy.yml up -d
```

### Workflow
The Backend project uses Clean Architecture in the following folder structure:

<pre style="font-family: 'Cascadia Mono'">
.
├─ Source
│  ├─ Shared
│  │  ├─ Emuhub.Communication	# DTO's
│  │  └─ Emuhub.Exceptions	# Exceptions and localized messages resource
│  ├─ Emuhub.API		# Controllers, Middlewares and Initialization (Presentation layer)
│  ├─ Emuhub.Application	# Use cases, validation and serialization
│  ├─ Emuhub.Domain		# Entities and Enum's
│  └─ Emuhub.Infrastructure	# External services like Databases, Email and File Storage
└─ Test
</pre>

- Requests are received by the API layer's controllers;
- Which will get passed to the respective UseCase class in the Application layer;
- Then will be superficially validated for required fields and content consistency;
- The valid request object will be passed to its respective repository/service in the Infrastructure layer;
- The repository, will check for duplicates or non-existing id's to secure consistent relationships in the Database;
- Then if all goes well, the UseCase will return the required result;
- Which will be served to the client by the API layer;


