CREATE TABLE [dbo].[Carts] (
    [CartId]        INT            IDENTITY (1, 1) NOT NULL,
    [ProductCartId] INT            NOT NULL,
    [UserId]        NVARCHAR (450) NULL,
    CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED ([CartId] ASC),
    CONSTRAINT [FK_Carts_ProductCart_ProductCartId] FOREIGN KEY ([ProductCartId]) REFERENCES [dbo].[ProductCarts] ([ProductCartId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Carts_UserId]
    ON [dbo].[Carts]([UserId] ASC);

