# Emuhub - Backend
## Contributing
### Development Environment Variables
Your user secrets will be stored at the path ``%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json``.
To add a user secret you can just edit the file, or use the commands:
```
# Initilizes the secrets.json file and asigns a Guid to it and your project
dotnet user-secrets init 

# Adds/Updates your secrets (For the path use the format "ParentJsonObject:ObjectValueName" or "ValueName")
dotnet user-secrets set <secret_path> <value>

# Lists secrets
dotnet user-secrets list
```

### Database Migrations
```
cd ./backend/

# Adding migration
dotnet ef migrations add <migration_name> --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API

# Updating the database with current migrations
dotnet ef database update --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API
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

