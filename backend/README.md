# Emuhub - Backend
## Contributing
### Database Migrations
```
cd ./backend/
dotnet ef migrations add <migration_name> --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API
dotnet ef database update --project ./Emuhub.Infrastructure --startup-project ./Emuhub.API
```