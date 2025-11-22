CREATE TABLE MemberTransactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MemberId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Date DATETIME NOT NULL,
    FOREIGN KEY (MemberId) REFERENCES Members(Id)
);