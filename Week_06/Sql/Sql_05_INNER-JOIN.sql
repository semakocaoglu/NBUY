-- Products tablosunu Unit Price kolonuna g�re b�y�kten k����e s�ralay�n�z.

--USE Northwind
--SELECT * FROM Products
--ORDER BY UnitPrice DESC

-- UnitPrice'� 100 ve �zerinde olan �r�nleri listele
--USE Northwind
--SELECT * FROM Products
--WHERE  UnitPrice >=100

-- Kategorisi 7 ve 8 olan �r�nleri listeleyiniz.
--USE Northwind
--SELECT * FROM Products
--WHERE CategoryID = 7 OR CategoryID = 8

-- Kategorisi 7 ve 8 olanlardan stok miktar� (UnitsInStock) 10 olan �r�nleri listeleyiniz.
--USE Northwind
--SELECT * FROM Products
--WHERE (CategoryID = 7 OR CategoryID = 8) AND UnitsInStock <= 10

-- Kategorisi 7 ve 8 olanlardan stok miktar� (UnitsInStock) 10 olan �r�nlerin say�s�.
--USE Northwind
--SELECT COUNT(*) FROM Products
--WHERE (CategoryID = 7 OR CategoryID = 8) AND UnitsInStock <= 10
--WHERE (CategoryID = 9 OR CategoryID = 3) AND UnitsInStock <= 50

-----------------------INNER JOIN-------------------
--SELECT Products.ProductName, Categories.CategoryName FROM Products INNER JOIN Categories
--	ON Products.CategoryID = Categories.CategoryID

--SELECT P.ProductName, C.CategoryName 
--FROM Products P INNER JOIN Categories C
--ON P.CategoryID = C.CategoryID
--WHERE CategoryName = 'Beverages' AND P.UnitPrice <= 40
--ORDER BY P.UnitPrice DESC

--Product Name ve Supplier Company Name'i g�steren bir sorgu yaz�n�z.
--SELECT P.ProductName, S.City
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID

--Germany'den tedarik edilen �r�nlerin Product Name listesi
--SELECT P.ProductName
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID
--WHERE  S.Country = 'Germany'

--Germany'den tedarik edilen �r�nlerin toplam tutar�
--SELECT SUM(P.UnitPrice * P.UnitsInStock) as 'Toplam Tutar'
--FROM Products P INNER JOIN Suppliers S
--ON P.SupplierID = S.SupplierID
--WHERE  S.Country = 'Germany'

--Chai sat��lar�n�n toplam tutar�
--SELECT SUM(OD.UnitPrice * OD.Quantity)
--FROM Products P INNER JOIN [Order Details] OD
--ON P.ProductID = OD.ProductID
--WHERE P.ProductName = 'Chai'

--Germany'e yap�lm�� olan Chai sat��lar�n�n toplam tutar�
--SELECT SUM(OD.UnitPrice * OD.Quantity)
--FROM ORDERS O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID INNER JOIN Products P
--ON OD.ProductID = P.ProductID
--WHERE P.ProductName = 'Chai' AND O.ShipCountry = 'Germany'

--Ernst Handel adl� m��terisine yap�lan sat�� tutar�n�n toplam�
SELECT SUM(OD.UnitPrice* OD.Quantity) 
FROM [Order Details] OD INNER JOIN Orders O
ON OD.OrderID = O.OrderID INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
WHERE C.CompanyName = 'Ernst Handel'
