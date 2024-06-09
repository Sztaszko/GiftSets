DROP TABLE IF EXISTS dbo.[Products]

CREATE TABLE [dbo].[Products] (
    [ProductID] INT          NOT NULL IDENTITY(1,1),
    [name]      VARCHAR (50) NULL,
    [price]     DECIMAL (18) NULL,
    [vendor]    VARCHAR (50) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);


GO

