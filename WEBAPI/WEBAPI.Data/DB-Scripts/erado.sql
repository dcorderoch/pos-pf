-- Product in Sale
IF OBJECT_ID (N'dbo.ProductInSale', N'U') IS NOT NULL
DROP TABLE dbo.ProductInSale ;

-- Sale
IF OBJECT_ID (N'dbo.Sale', N'U') IS NOT NULL
DROP TABLE dbo.Sale ;

-- Staff Log
IF OBJECT_ID (N'dbo.Staff_Log', N'U') IS NOT NULL
DROP TABLE dbo.Staff_Log ;

-- Product
IF OBJECT_ID (N'dbo.Product', N'U') IS NOT NULL
DROP TABLE dbo.Product ;

--Customer
IF OBJECT_ID (N'dbo.Customer', N'U') IS NOT NULL
DROP TABLE dbo.Customer ;

-- Staff
IF OBJECT_ID (N'dbo.Staff', N'U') IS NOT NULL
DROP TABLE dbo.Staff ;

-- Branch Office
IF OBJECT_ID (N'dbo.BranchOffice', N'U') IS NOT NULL
DROP TABLE dbo.BranchOffice;

-- Supplier
IF OBJECT_ID (N'dbo.Supplier', N'U') IS NOT NULL
DROP TABLE dbo.Supplier;


-- STORED PROCEDURES
IF OBJECT_ID(N'dbo.ENDSALE', N'P') IS NOT NULL
DROP PROCEDURE dbo.ENDSALE;
IF OBJECT_ID(N'dbo.STARTSALE', N'P') IS NOT NULL
DROP PROCEDURE dbo.STARTSALE;
IF OBJECT_ID(N'dbo.ENDSHIFT', N'P') IS NOT NULL
DROP PROCEDURE dbo.ENDSHIFT;
IF OBJECT_ID(N'dbo.STARTSHIFT', N'P') IS NOT NULL
DROP PROCEDURE dbo.STARTSHIFT;