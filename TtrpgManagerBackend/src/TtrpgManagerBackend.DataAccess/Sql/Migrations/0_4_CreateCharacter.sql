create table [Character]
(
    [Id] int primary key identity(1, 1),
    [PlayerId] int,
    [Name] nvarchar(256) not null,
    [RaceId] int,
    [ClassId] int,
    [Level] int,
    [MaxHealthPoints] int,
    [HealthPoints] int

    constraint [Characher_PlayerId_FK] 
    foreign key ([PlayerId]) references [User] ([Id]),
    constraint [Characher_RaceId_FK]
    foreign key ([RaceId]) references [Race] ([Id]),
    constraint [Characher_ClassId_FK]
    foreign key ([ClassId]) references [Class] ([Id])
)

create table [CampaignCharacter]
(
    [Id] int primary key identity(1, 1),
    [CampaignId] int,
    [CharacterId] int

    constraint [CampaignCharacter_CampaignId_FK]
    foreign key ([CampaignId]) references [Campaign] ([Id]),
    constraint [CampaignCharacter_CharacterId_FK]
    foreign key ([CharacterId]) references [Character] ([Id])
)

create table [CharacterItem]
(
    [Id] int primary key identity(1, 1),
    [CharacterId] int,
    [ItemId] int

    constraint [CharacterItem_CharacterId_FK]
    foreign key ([CharacterId]) references [Character] ([Id]),
    constraint [CharacterItem_CampaignId_FK]
    foreign key ([ItemId]) references [Item] ([Id]),
)