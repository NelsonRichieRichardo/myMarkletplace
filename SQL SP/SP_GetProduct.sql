USE [myMarketplace]
GO
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 10/11/2024 22.20.01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetProduct]
    @product_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM products WHERE product_id = @product_id;
END;
