create table [Campaign]
(
    [Id] int primary key identity(1, 1),
    [Title] nvarchar(256) not null,
    [Description] nvarchar(512),
    [CreatedBy] int,
    [CreatedAt] datetime2 not null,
    [UpdatedBy] int,
    [UpdatedAt] datetime2 not null,

    constraint [Column_CreatedBy_FK] 
    foreign key ([CreatedBy]) references [User] ([Id]),
    constraint [Column_UpdatedBy_FK]
    foreign key ([UpdatedBy]) references [User] ([Id])
)