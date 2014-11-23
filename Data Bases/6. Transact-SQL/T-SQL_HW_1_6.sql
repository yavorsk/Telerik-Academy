--1. Create a database with two tables: 
--Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). 
--Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.

CREATE DATABASE BankAccount
GO

USE BankAccount
CREATE TABLE Persons
(
	Id int IDENTITY,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	SSN int,
	CONSTRAINT PK_PersonId PRIMARY KEY(Id)
)
GO

CREATE TABLE Accounts
(
	Id int IDENTITY,
	PersonId int,
	Balance money,
	CONSTRAINT PK_AccountId PRIMARY KEY(Id),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId) REFERENCES Persons(Id)
)
GO

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Pesho', 'Peshev', 12345667), ('Gosho', 'Goshev', 16548789), ('Checho', 'Chechev', 98713245)

INSERT INTO Accounts(PersonId, Balance)
VALUES (2, 2000), (1, 6000), (3, 452.25)
GO

CREATE PROC usp_SelectPersonNames
AS
  SELECT FirstName + ' ' + LastName AS [Full Name] 
  FROM Persons
GO

EXEC usp_SelectPersonNames
GO

------------------------------------------------------------
--2. Create a stored procedure that accepts a number as a parameter and 
--returns all persons who have more money in their accounts than the supplied number.

CREATE PROC usp_SelectPersonWithMoreMoneyThan (@Balance money)
AS
  SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance 
  FROM Persons p
	INNER JOIN Accounts a
  ON a.PersonId = p.Id
  WHERE a.Balance > @Balance
GO

EXEC usp_SelectPersonWithMoreMoneyThan 3000
GO

------------------------------------------------------------
--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. 
-- Write a SELECT to test whether the function works as expected.

CREATE FUNCTION ufn_CalcNewBalance (@sum money, @yearInterest NUMERIC(4,2), @months int)
	RETURNS money
AS
BEGIN
	RETURN (@yearInterest / 12) * @months * @sum + @sum
END
GO

SELECT dbo.ufn_CalcNewBalance (100, 0.06, 6)
GO

------------------------------------------------------------
--4. Create a stored procedure that uses the function from the previous example 
--to give an interest to a person's account for one month. 
--It should take the AccountId and the interest rate as parameters.

CREATE PROC usp_ApplyInterestToAccount (@acc_id int, @yearlyInterest NUMERIC(4,2))
AS
  UPDATE Accounts
  SET Balance = dbo.ufn_CalcNewBalance(Balance, @yearlyInterest, 1)
  WHERE Id = @acc_id
GO

EXEC usp_ApplyInterestToAccount 1, 0.9
GO

------------------------------------------------------------
--5. Add two more stored procedures WithdrawMoney( AccountId, money) and 
--DepositMoney (AccountId, money) that operate in transactions.

CREATE PROC usp_WithdrawMoney (@acc_id int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE Id = @acc_id
	COMMIT TRAN
GO

CREATE PROC usp_DepositMoney (@acc_id int, @amount money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE Id = @acc_id
	COMMIT TRAN
GO

EXEC usp_WithdrawMoney 1, 400
EXEC usp_WithdrawMoney 2, 400
EXEC usp_DepositMoney 3, 1000
GO

-------------------------------------------------------------
--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs table
--every time the sum on an account changes.

CREATE TABLE Logs
(
	LogId int IDENTITY,
	AccountId int,
	OldSum money,
	NewSum money,
	CONSTRAINT PK_LogId PRIMARY KEY(LogId),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_LogTransactions ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT d.Id, d.Balance, i.Balance
	FROM deleted d
	INNER JOIN inserted i 
		ON d.id = i.Id
GO

EXEC usp_DepositMoney 3, 1000