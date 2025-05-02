SELECT company.id AS CompanyID, bus.id AS BusID, voyage.id AS VoyageID FROM company 
JOIN bus ON company.id = bus.company_id 
JOIN voyage ON bus.id = voyage.bus_id WHERE company_id = 1