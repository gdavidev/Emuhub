# Emuhub - Backend
## Contributing
### Initilizing The Project
```bash
# In the project root
## Development 
docker compose -f docke-compose.infra.yml up --build -d
docker compose up --build -d

## Release (Ignore override file)
docker compose -f docke-compose.infra.yml up --build -d
docker compose -f docker-compose.yml up --build -d

## Turn off Running containers
docker compose -f docke-compose.infra.yml down
docker compose -f docker-compose.yml down
```

### Database Migrations
```bash
cd ./backend/

# Adding migration
dotnet ef migrations add <migration_name> -p Emuhub.Infrastructure -s Emuhub.API --msbuildprojectextensionspath Emuhub.API\obj\local

# Updating the database with current migrations
dotnet ef database update -p Emuhub.Infrastructure -s Emuhub.API --msbuildprojectextensionspath Emuhub.API\obj\local
```
**Note**: On the first run, ef core will complain about a `*csproj.EntityFrameworkCore.targets` file, which needs to be created
in both projects, Infrastructure and API, when you face this issue, chage the param `msbuildprojectextensionspath` to run o the 
Infrastructure project before finally running in the API project, which will add the migration just fine

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

