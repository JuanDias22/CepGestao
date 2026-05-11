
    -- criação tabela usuários

    CREATE TABLE [dbo].[Usuarios] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Nome]  NVARCHAR (MAX) NOT NULL,
    [User]  NVARCHAR (MAX) NOT NULL,
    [Senha] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

-- criação tabela endereços

CREATE TABLE [dbo].[Enderecos] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Cep]         NVARCHAR (MAX) NOT NULL,
    [Logradouro]  NVARCHAR (MAX) NOT NULL,
    [Complemento] NVARCHAR (MAX) NULL,
    [Bairro]      NVARCHAR (MAX) NOT NULL,
    [Cidade]      NVARCHAR (MAX) NOT NULL,
    [Uf]          NVARCHAR (MAX) NOT NULL,
    [Numero]      NVARCHAR (MAX) NOT NULL,
    [UsuarioId]   INT            NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enderecos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuarios] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Enderecos_UsuarioId]
    ON [dbo].[Enderecos]([UsuarioId] ASC);

