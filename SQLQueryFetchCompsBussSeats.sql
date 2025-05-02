SELECT company.id AS CompanyID, bus.id AS BusID, bus_seat.id AS BusSeatID FROM company 
JOIN bus ON company.id = bus.company_id 
JOIN bus_seat ON bus.id = bus_seat.bus_id WHERE company_id = 1