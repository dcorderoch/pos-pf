-- Product
ALTER TABLE Product
ADD CONSTRAINT PK_Product
PRIMARY KEY (EAN);
--Customer
ALTER TABLE Customer
ADD CONSTRAINT PK_Customer
PRIMARY KEY (IDNumber);
-- Branch Office
ALTER TABLE BranchOffice
ADD CONSTRAINT PK_BranchOffice
PRIMARY KEY (OfficeID);
-- Staff
ALTER TABLE Staff
ADD CONSTRAINT PK_Staff
PRIMARY KEY (StaffID);

ALTER TABLE Staff
ADD CONSTRAINT FK_Staff_BOffice
FOREIGN KEY (BOfficeID)
REFERENCES BranchOffice(OfficeID);
-- Sale
ALTER TABLE Sale
ADD CONSTRAINT PK_Sale
PRIMARY KEY (SaleID);

ALTER TABLE Sale
ADD CONSTRAINT FK_Sale_Customer
FOREIGN KEY (IDNumber)
REFERENCES Customer(IDNumber);

ALTER TABLE Sale
ADD CONSTRAINT FK_Sale_Staff
FOREIGN KEY (StaffID)
REFERENCES Staff(StaffID);

ALTER TABLE Sale
ADD CONSTRAINT FK_Sale_BranchOffice
FOREIGN KEY(BOfficeID)
REFERENCES BranchOffice(OfficeID);
-- Product in Sale
ALTER TABLE ProductInSale
ADD CONSTRAINT PK_ProductInSale
PRIMARY KEY (EAN, SaleID);

ALTER TABLE ProductInSale
ADD CONSTRAINT FK_ProductInSale_Sale
FOREIGN KEY (SaleID)
REFERENCES Sale(SaleID);

ALTER TABLE ProductInSale
ADD CONSTRAINT FK_ProductInSale_Product
FOREIGN KEY (EAN)
REFERENCES Product(EAN);
-- Staff Log
ALTER TABLE Staff_Log
ADD CONSTRAINT PK_Staff_Log
PRIMARY KEY (LogID);

ALTER TABLE Staff_Log
ADD CONSTRAINT FK_Staff_Log_Staff
FOREIGN KEY (StaffID)
REFERENCES Staff(StaffID);

-- Supplier
ALTER TABLE Supplier
ADD CONSTRAINT PK_Supplier
PRIMARY KEY (SupplerID);