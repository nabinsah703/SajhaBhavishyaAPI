USE SajhaBhavishya;
GO


select * from dbo.Members
CREATE TABLE Members
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Mobile NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL
);

alter PROCEDURE usp_CreateMember
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Mobile NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @MemberId INT OUTPUT
AS
BEGIN
    INSERT INTO Members (FirstName, LastName, Mobile, Email)
    VALUES (@FirstName, @LastName, @Mobile, @Email);

    SET @MemberId = SCOPE_IDENTITY();
END

IF OBJECT_ID('dbo.usp_CreateMember', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_CreateMember;
GO

CREATE PROCEDURE dbo.usp_CreateMember
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @JoinedDate DATE,
    @Mobile NVARCHAR(20) = NULL,
    @Email NVARCHAR(200) = NULL,
    @MemberId INT OUTPUT   -- OUTPUT parameter to return created MemberId
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Optional check: ensure mobile uniqueness if provided
        IF (@Mobile IS NOT NULL AND EXISTS(SELECT 1 FROM dbo.Member WHERE Mobile = @Mobile))
        BEGIN
            RAISERROR('A member with mobile %s already exists.', 16, 1, @Mobile);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO dbo.Member (FirstName, LastName, JoinedDate, Mobile, Email)
        VALUES (@FirstName, @LastName, @JoinedDate, @Mobile, @Email);

        -- get the inserted MemberId
        SET @MemberId = CAST(SCOPE_IDENTITY() AS INT);

        -- create the savings account for the member
        INSERT INTO dbo.SavingsAccount (MemberId, Balance, LastUpdated)
        VALUES (@MemberId, 0.00, SYSUTCDATETIME());

        -- Audit (optional)
        INSERT INTO dbo.AuditLog (EventType, EventBy, EventData)
        VALUES ('CreateMember', NULL, CONCAT('MemberId=', @MemberId, ',Name=', @FirstName, ' ', @LastName));

        COMMIT TRANSACTION;

        -- return the id as a resultset as well (helpful for ExecuteReader usage)
        SELECT @MemberId AS MemberId;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrNum INT = ERROR_NUMBER();
        DECLARE @ErrState INT = ERROR_STATE();

        -- Log the error to AuditLog (optional)
        BEGIN TRY
            INSERT INTO dbo.AuditLog (EventType, EventBy, EventData)
            VALUES ('CreateMemberError', NULL, CONCAT('ErrorNo=', @ErrNum, ';State=', @ErrState, ';Msg=', @ErrMsg));
        END TRY
        BEGIN CATCH
            -- ignore logging failure
        END CATCH;

        -- rethrow a readable error
        RAISERROR('Error in usp_CreateMember: %s', 16, 1, @ErrMsg);
        RETURN;
    END CATCH
END
GO
