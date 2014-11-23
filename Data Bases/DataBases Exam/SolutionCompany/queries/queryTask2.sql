USE Company

SELECT d.Name AS [Department Name], COUNT(*) AS [Count Of Employees]
FROM Departments d 
INNER JOIN Employees e
ON e.DepartmentID = d.Id
GROUP BY d.Name
ORDER BY [Count Of Employees] DESC