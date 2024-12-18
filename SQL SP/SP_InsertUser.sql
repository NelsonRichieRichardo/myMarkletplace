CREATE PROCEDURE InsertUser
    @user_name VARCHAR(20),
    @user_phone INT,
    @user_email VARCHAR(MAX),
    @user_password VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO users (user_name, user_phone, user_email, user_password)
    VALUES (@user_name, @user_phone, @user_email, @user_password);
END;
