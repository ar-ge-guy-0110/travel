SELECT voyage.id AS 'Voyage ID', company.id AS 'Company ID', voyage.departure_route_id AS 'DepartureID', 
voyage.arrival_route_id AS 'ArrivalID', voyage.bus_id AS 'BusID', images_company.image AS 'Company Image', 
company.company_name AS 'Company', 
route.route_name AS 'Departure Point', 
route2.route_name AS 'Arrival Point', 
bus.busname AS 'Bus Name', bus.seat_price AS 'Seat Price', voyage.voyage_price AS 'Voyage Price', 
voyage.total_seat_price AS 'Total Travel Price', voyage.voyage_departure_datetime AS 'Departure Time', 
voyage.voyage_arrival_datetime AS 'Arrival Time' FROM voyage 
JOIN route ON route.id = voyage.departure_route_id 
JOIN route AS route2 ON route2.id = voyage.arrival_route_id 
JOIN bus ON voyage.bus_id = bus.id 
JOIN company ON bus.company_id = company.id 
LEFT JOIN images_company ON company.id = images_company.company_id WHERE route.route_name = N'Reyvadin' AND route2.route_name = N'Ankara' AND voyage.voyage_departure_datetime >= '2021-01-20 00:00:00.000'