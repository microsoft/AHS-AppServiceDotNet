CREATE TABLE [dbo].[Bookings] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [From]         DATETIME       NOT NULL,
    [To]           DATETIME       NOT NULL,
    [CustomerId]   NVARCHAR (MAX) NULL,
    [CustomerName] NVARCHAR (MAX) NULL,
    [Passport]     NVARCHAR (MAX) NULL,
    [Address]      NVARCHAR (MAX) NULL,
    [Amount]       INT            NOT NULL,
    [Total]        INT            NOT NULL,
    CONSTRAINT [PK_dbo.Bookings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

