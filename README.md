# ttrpg-manager-backend

Own backend project for tabletop role-playing game management.

App supports:
- creating user profiles (requires username, email and password)
- managing user characters (currently uses only D&D 5e as base for character description)

## Stack
Project created using:
- .NET 6
    - C# 10
    - ASP.NET Core 6
    - Dapper
- SQL
    - Microsoft SQL Server
    - Transact-SQL

## Structure
- \TtrpgManagerBackend – main directory
    - \src – directory for actual app code
        - \TtrpgManagerBackend.Application – core project, includes startup file, controllers and services
        - \TtrpgManagerBackend.Common – project for common items like const strings
        - \TtrpgManagerBackend.DataAccess – project for Data Access Layer, includes classes for DB queries and SQL scripts
        - \TtrpgManagerBackend.Domain – project for domain classes
        - \TtrpgManagerBackend.Dto – project for DTOs
    - \tests – directory for test code
        - \TtrpgManagerBackend.Application.Tests – project for TtrpgManagerBackend.Application related unit tests
        - \TtrpgManagerBackend.Tests.Common – project for common testing related items

## API routes
TBA