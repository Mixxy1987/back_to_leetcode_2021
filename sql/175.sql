select FirstName, LastName, City, State
from Person p
left join Address a on(a.PersonId = p.PersonId)