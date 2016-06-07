--Product
INSERT INTO Product(EAN,Name,Price,Quantity,DailyAverageSales,DaysbtwnShipment)
VALUES (7441001615610,'Caja Leche 1L',575,10,2,2),
       (7441003400207,'Caf� Volio 250g',750,10,2,7),
       (7441036101225,'Bolsa Az�car 1kg',950,10,2,7);
--Customer
INSERT INTO Customer(IDNumber, Name, LastName1, LastName2)
VALUES ('000000000','Dinero','En','Efectivo'),
       ('115020180','David','Cordero','Chavarr�a'),
       ('115020196','Katherine','Rojas','Blanco'),
	   ('658887623','Luis','Ram�rez','Vargas');
-- Branch Office
INSERT INTO BranchOffice(OfficeID,Name,PhoneNumber,Location)
VALUES (1,'Cartago','+50625558080','Oriental, Cartago'),
       (2,'Para�so','+50625558081','Para�so, Cartago');
-- Staff
INSERT INTO Staff(BOfficeID, Name, LastName1, LastName2)
VALUES (1, 'Rodrigo', 'Jim�nez', 'Conejo'),
       (2, 'Jimena', 'Calvo','Garc�a');
-- Sale
INSERT INTO Sale(IDNumber,StaffID,BOfficeID,STARTOF,EOF)
VALUES ('000000000',1001,1,'2016-06-01 6:34:12 AM','2016-06-01 6:40:12 AM'),
       ('115020180',1002,2,'2016-06-01 6:34:12 AM','2016-06-01 6:40:12 AM');
-- Staff Log
INSERT INTO Staff_Log(StaffID, Register, ShiftStart, ShiftEnd, MoneyOnShiftStart, MoneyOnShiftEnd)
VALUES (1001, 7, '2016-06-01 6:34:12 AM', '2016-06-01 6:34:12 PM',15000,235000),
       (1002, 9, '2016-06-01 6:15:00 AM', '2016-06-01 5:30:12 PM',17500,185000);