------------------------------------------------------------
-- 7. Define a function in the database TelerikAcademy that returns 
-- all Employee's names (first or middle or last name) and 
-- all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy
GO

CREATE FUNCTION ufn_SetOfLettersContainWord (@word nvarchar(20), @letters nvarchar(20))
	RETURNS bit
AS
BEGIN
	DECLARE @result bit = 0
	DECLARE @wordLength int = LEN(@word)
	DECLARE @counter int = 1
	DECLARE @matches int = 0
	DECLARE @currentChar nvarchar(1)

	WHILE (@counter <= @wordLength)
		BEGIN
			SET @currentChar = SUBSTRING(@word, @counter, 1)
			IF(CHARINDEX(@currentChar, @letters) > 0)
			BEGIN
				SET @matches += 1
			END
			SET @counter += 1
		END

		IF (@matches = @wordLength)
		BEGIN
			SET @result = 1
		END
		ELSE
		BEGIN
			SET @result = 0
		END

	RETURN @result
END
GO

CREATE PROC usp_SelectEmployeesAndTownsThatMachPattern (@pattern nvarchar(20))
AS
	SELECT e.FirstName FROM Employees e
		WHERE dbo.ufn_SetOfLettersContainWord(e.FirstName, @pattern) = 1
	UNION
	SELECT e.LastName FROM Employees e
		WHERE dbo.ufn_SetOfLettersContainWord(e.LastName, @pattern) = 1
	UNION
	SELECT t.Name FROM Towns t
		WHERE dbo.ufn_SetOfLettersContainWord(t.Name, @pattern) = 1
GO

EXEC usp_SelectEmployeesAndTownsThatMachPattern 'oistmiahf'
GO

-----------------------------------------------------------------------------
--8. Using database cursor write a T-SQL script that scans all employees and their addresses
-- and prints all pairs of employees that live in the same town.

DECLARE empCursor CURSOR READ_ONLY FOR

SELECT e.FirstName, e.LastName, t.Name, m.FirstName, m.LastName
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID
	INNER JOIN Addresses d
	ON d.TownID = t.TownID
	INNER JOIN Employees m
	ON d.AddressID = m.AddressID
		WHERE e.EmployeeID <> m.EmployeeID

OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)

FETCH NEXT FROM empCursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstName1 + ' ' + @lastName1 + ' and ' + @firstName2 + ' ' + @lastName2 +
                        ' live in ' + @town + '.'
		FETCH NEXT FROM empCursor
                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
	END

CLOSE empCursor
DEALLOCATE empCursor

-----------------------------------------------------------------------------
--9.* Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
-- ...

DECLARE townsCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns

OPEN townsCursor
DECLARE @townName VARCHAR(50), @userNames VARCHAR(MAX)
FETCH NEXT FROM townsCursor INTO @townName

WHILE @@FETCH_STATUS = 0
	BEGIN
		
		DECLARE nameCursor CURSOR READ_ONLY FOR
		SELECT e.FirstName, e.LastName
		FROM Employees e
			INNER JOIN Addresses a
			ON e.AddressID = a.AddressID
			INNER JOIN Towns t
			ON a.TownID = t.TownID
				WHERE t.Name = @townName

		OPEN nameCursor
		DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50)
		FETCH NEXT FROM nameCursor INTO @firstName,  @lastName

		WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @userNames = CONCAT(@userNames, @firstName, ' ', @lastName, ', ')
				FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
			END

		CLOSE nameCursor
		DEALLOCATE nameCursor
		
		SET @userNames = LEFT(@userNames, LEN(@userNames) - 1)

		PRINT @townName + ' --> ' + @userNames
		SET @userNames = ''
		FETCH NEXT FROM townsCursor INTO @townName

	END

CLOSE townsCursor
DEALLOCATE townsCursor
GO