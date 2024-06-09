DROP TABLE IF EXISTS dbo.[Sets]

CREATE TABLE [dbo].[Sets] (
    [SetID]       INT          NOT NULL IDENTITY(1,1),
    [name]        VARCHAR (50) NOT NULL,
    [product1ID]  INT          NULL,
    [product2ID]  INT          NULL,
    [product3ID]  INT          NULL,
    [product4ID]  INT          NULL,
    [product5ID]  INT          NULL,
    [product6ID]  INT          NULL,
    [product7ID]  INT          NULL,
    [product8ID]  INT          NULL,
    [product9ID]  INT          NULL,
    [product10ID] INT          NULL,
    CONSTRAINT [PK_Sets] PRIMARY KEY CLUSTERED ([SetID] ASC),
    CONSTRAINT [FK_Sets_Products1] FOREIGN KEY ([product1ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products10] FOREIGN KEY ([product10ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products2] FOREIGN KEY ([product2ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products3] FOREIGN KEY ([product3ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products4] FOREIGN KEY ([product4ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products5] FOREIGN KEY ([product5ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products6] FOREIGN KEY ([product6ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products7] FOREIGN KEY ([product7ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products8] FOREIGN KEY ([product8ID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Sets_Products9] FOREIGN KEY ([product9ID]) REFERENCES [dbo].[Products] ([ProductID])
);


GO

