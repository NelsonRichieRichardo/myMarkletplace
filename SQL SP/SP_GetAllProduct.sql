USE [myMarketplace]
GO
/****** Object:  StoredProcedure [dbo].[GetAllProduct]    Script Date: 10/11/2024 22.19.40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllProduct]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM products ORDER BY product_id DESC;
END;