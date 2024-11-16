CREATE FUNCTION CalculateTotalInventoryValue()
RETURNS decimal(18,2)
AS
BEGIN
    DECLARE @TotalValue decimal(18,2)
    
    SELECT @TotalValue = SUM(CAST(product_price as decimal(18,2)) * CAST(product_stock as decimal(18,2)))
    FROM Products
    
    RETURN ISNULL(@TotalValue, 0)
END