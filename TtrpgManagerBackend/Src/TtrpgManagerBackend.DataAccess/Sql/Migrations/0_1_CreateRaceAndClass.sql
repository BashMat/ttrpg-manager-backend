create table [Race]
(
	[Id] int primary key identity(1, 1),
	[Name] nvarchar(256) not null,
	[Description] nvarchar(256)
)

create table [Class]
(
    [Id] int primary key identity(1, 1),
    [Name] nvarchar(256) not null,
    [Description] nvarchar(256)
)