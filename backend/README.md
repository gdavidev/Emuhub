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
dotnet ef migrations add <migration_name> --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API
dotnet ef database update --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API
```