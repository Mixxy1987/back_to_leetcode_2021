select e1.Name as Employee 
from Employee as e1
join Employee as e2 ON(e2.Id = e1.ManagerId)
where e1.Salary > e2.Salary