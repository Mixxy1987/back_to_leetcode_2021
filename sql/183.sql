select Name as Customers from customers c
left join orders o ON(o.CustomerId = c.Id)
where o.Id is null