IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Agendamento') IS NULL EXEC(N'CREATE SCHEMA [Agendamento];');

GO

CREATE TABLE [Agendamento].[Medicos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Crm] varchar(10) NOT NULL,
    [Telefone] varchar(20) NOT NULL,
    CONSTRAINT [PK_Medicos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Agendamento].[Pacientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Telefone] varchar(20) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Pacientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Agendamento].[Agendamentos] (
    [Id] uniqueidentifier NOT NULL,
    [MedicoId] uniqueidentifier NOT NULL,
    [PacienteId] uniqueidentifier NOT NULL,
    [InicioAtendimento] datetime2 NOT NULL,
    [FimAtendimento] datetime2 NOT NULL,
    [Observacao] varchar(1000) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Agendamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agendamentos_Medicos_MedicoId] FOREIGN KEY ([MedicoId]) REFERENCES [Agendamento].[Medicos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Agendamentos_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Agendamento].[Pacientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Agendamentos_MedicoId] ON [Agendamento].[Agendamentos] ([MedicoId]);

GO

CREATE INDEX [IX_Agendamentos_PacienteId] ON [Agendamento].[Agendamentos] ([PacienteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190911232719_Inicial', N'2.2.6-servicing-10079');

GO

