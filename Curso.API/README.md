# MIGRATIONS
## Criar nova migration
* dotnet ef migrations add InitialCreation -p Curso.Repo -s Curso.API -o Database/Migrations

## Remover a última migration
* dotnet ef migrations remove -p Curso.Repo -s Curso.API

## Executar migrations no banco
* dotnet ef database update -p Curso.Repo -s Curso.API

## Desfaz todas migrations
* dotnet ef database update 0 -p Curso.Repo -s Curso.API

## Avança ou faz roolback para uma migration específica
* dotnet ef database update NomeDaMigration -p Curso.Repo -s Curso.API