--Product
INSERT INTO Product(EAN,Name,Price)
VALUES (7441001615610,'Caja Leche 1L',575),
       (7441003400207,'Café Volio 250g',750),
       (7441036101225,'Bolsa Azúcar 1kg',950);
--Customer
INSERT INTO Customer(IDNumber, Name, LastName1, LastName2)
VALUES ('000000000','Dinero','En','Efectivo'),
       ('115020180','David','Cordero','Chavarría'),
       ('115020196','Katherine','Rojas','Blanco'),
	   ('658887623','Luis','Ramírez','Vargas');
-- Branch Office
INSERT INTO BranchOffice(OfficeID,Name,PhoneNumber,Location)
VALUES (1,'Cartago','+50625558080','Oriental, Cartago'),
       (2,'Paraíso','+50625558081','Paraíso, Cartago');
-- Staff
INSERT INTO Staff(BOfficeID, Name, LastName1, LastName2)
VALUES (1, 'Rodrigo', 'Jiménez', 'Conejo'),
       (2, 'Jimena', 'Calvo','García');
-- Sale
INSERT INTO Sale(IDNumber,BOfficeID,STARTOF,EOF)
VALUES ('000000000',1,'2016-06-01 6:34:12 AM','2016-06-01 6:40:12 AM'),
       ('115020180',2,'2016-06-01 6:34:12 AM','2016-06-01 6:40:12 AM');
-- Staff Log
INSERT INTO Staff_Log(StaffID, BOfficeID, Register, Start, EndOfShift, MoneyOnStart, MoneyOnExit)
VALUES (1001, 1, 7, '2016-06-01 6:34:12 AM', '2016-06-01 6:34:12 PM',15000,235000),
       (1002, 2, 9, '2016-06-01 6:15:00 AM', '2016-06-01 5:30:12 PM',17500,185000);