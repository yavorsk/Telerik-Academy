USE Company

SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.YearSalary
FROM Employees e
WHERE 100000 <= e.YearSalary AND e.YearSalary <= 150000
ORDER BY e.YearSalary