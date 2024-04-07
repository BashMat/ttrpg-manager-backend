create table [Item]
(
    [Id] int primary key identity(1, 1),
    [Name] nvarchar(256) not null,
    [Description] nvarchar(512)
)