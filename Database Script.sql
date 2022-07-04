
CREATE TABLE Customer (
Customer_ID VARCHAR (12) NOT NULL PRIMARY KEY,
Customer_Name VARCHAR (30) NOT NULL,
Customer_Address VARCHAR (120) NOT NULL
); 
DROP TABLE Customer;
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Employee (
Employee_ID VARCHAR (12) NOT NULL PRIMARY KEY,
Employee_Name VARCHAR (30) NOT NULL,
);

Drop TABLE Employee
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Job_Type (
Job_Type_ID VARCHAR (30) NOT NULL PRIMARY KEY,
Daily_Rate FLOAT NOT NULL,
);

DROP TABLE Job_Type;

------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Invoice_Material (
Invoice_Material_ID VARCHAR (12) NOT NULL PRIMARY KEY,
Invoice_Line_Material VARCHAR (60) NOT NULL
);
DROP TABLE Invoice_Material;
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Storage (
Material_ID VARCHAR (12) NOT NULL PRIMARY KEY,
Material_Name VARCHAR (30) NOT NULL,
Material_Amount INT NOT NULL
);
DROP TABLE Storage;
------------------------------------------------------------------------------------------------------------------------
--Dependant Tables--
--Foreign key enteries can be repeated--
--primary key on dependant table JOB CARD--

CREATE TABLE Job (
Job_Card VARCHAR (12) NOT NULL PRIMARY KEY,
Job_Type_ID VARCHAR (30) NOT NULL FOREIGN KEY REFERENCES Job_Type (Job_Type_ID),
Days_For_Job INT NOT NULL
);
DROP TABLE Job;
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Employee_Job (
Employee_ID VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Employee (Employee_ID),
Job_Card VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Job (Job_Card)
);

DROP TABLE Employee_Job;
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Materials (
Material_ID VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Storage (Material_ID),
Invoice_Material_ID VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Invoice_Material (Invoice_Material_ID),
Material_Used VARCHAR (120) NOT NULL
);
DROP TABLE Materials;
------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Invoice (
Invoice_ID VARCHAR (12) NOT NULL PRIMARY KEY,
Invoice_Material_ID VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Invoice_Material (Invoice_Material_ID),
Customer_ID VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Customer (Customer_ID),
Job_Card VARCHAR (12) NOT NULL FOREIGN KEY REFERENCES Job (Job_Card)
);
DROP TABLE Invoice;
------------------------------------------------------------------------------------------------------------------------

INSERT INTO Customer (Customer_ID, Customer_Name, Customer_Address)
VALUES	('C001','Tendai Ndoro','3 Leos Place 457 Church Str PRETORIA, 0002'),
		('C002','Donald Puttingh','408 Oubos 368 Prinsloo Street PRETORIA, 0001'),
		('C003','Tracy Samson','206 Albertros 269 Stead Avenue PRETORIA, 0186'),
		('C004','Jacob Smith','A201 Ocerton 269 Debouvlrde Str PRETORIA, 0002'),
		('C005','Thato Molepo','11 Luttig Court 289 MALTZAN Str PRETORIA, 0001'),
		('C006','Dakalo Mudau','1182 CEBINIA Str PRETORIA, 0082'),
		('C007','Sfiso Myeni','503 Hamilton Gardens 337 Visagie Str PRETORIA, 0001'),
		('C008','Ricardo Keyl','10 Silville 614 Jasmyn Str PRETORIA, 0184'),
		('C009','Smallboy Mtshali','307 FEORA East PRETORIA-WEST, 0183'),
		('C010','Wilson Jansen','701 Monticchico Flat 251 Jacob Mare Str PRETORIA, 0002');

------------------------------------------------------------------------------------------------------------------------

INSERT INTO Employee (Employee_ID, Employee_Name)
VALUES	('EMP100','Albert Malose'),
		('EMP920','Chris Byne'),
		('EMP010','John Hendricks'),
		('EMP771','Smallboy Modipa'),
		('EMP681','Stanley Jacobs');

------------------------------------------------------------------------------------------------------------------------

INSERT INTO Job_Type (Job_Type_ID, Daily_Rate)
VALUES	('Full Conversion', 1200),
		('Semi Conversion', 1080),
		('Floor Boarding', 900);

------------------------------------------------------------------------------------------------------------------------

INSERT INTO Invoice_Material (Invoice_Material_ID, Invoice_Line_Material)
VALUES	('L01','LM01'),
		('L02','LM02'),
		('L03','LM03'),
		('L04','LM04'),
		('L05','LM05'),
		('L06','LM06'),
		('L07','LM07'),
		('L08','LM08'),
		('L09','LM09'),
		('L10','LM10');

------------------------------------------------------------------------------------------------------------------------
		
INSERT INTO Storage (Material_ID, Material_Name, Material_Amount)
VALUES	('M01', 'standard floor boards', 1200),
		('M02', 'power points', 1000),
		('M03', 'standard electrical wiring', 1100),
		('M04', 'Standard stairs pack', 1000);

------------------------------------------------------------------------------------------------------------------------

INSERT INTO Job (Job_Card, Job_Type_ID , Days_For_Job)
VALUES	('11000','Full Conversion', 7),
		('10478','Semi Conversion', 2),
		('14253','Floor Boarding', 2),
		('11258','Full Conversion', 8),
		('12058','Semi Conversion', 3),
		('13697','Full Conversion', 7),
		('10211','Full Conversion', 7),
		('10471','Semi Conversion', 2),
		('13521','Semi Conversion', 3),
		('10102','Floor Boarding', 2);

------------------------------------------------------------------------------------------------------------------------

INSERT INTO Employee_Job (Job_Card, Employee_ID)
VALUES	('11000', 'EMP100'),
		('11000', 'EMP920'),
		('11000', 'EMP010'),
		('10478', 'EMP920'),
		('14253', 'EMP771'),
		('11258', 'EMP681'),
		('11258', 'EMP010'),
		('11258', 'EMP771'),
		('12058', 'EMP681');
	
------------------------------------------------------------------------------------------------------------------------

INSERT INTO Materials (Material_ID ,Invoice_Material_ID, Material_Used)
VALUES	
		--1--
		('M01','L01','90'),
		('M02','L01','3'),
		('M03','L01','20 meters'),
		('M04','L01','1'),
		--2--
		('M01','L02','50'),
		('M02','L02','1'),
		('M03','L02','10 meters'),
		--3--
		('M01','L03','40'),
		--4--
		('M01','L04','80'),
		('M02','L04','3'),
		('M03','L04','20 meters'),
		('M04','L04','1'),
		--5--
		('M01','L05','60'),
		('M02','L05','2'),
		('M03','L05','15 meters'),
		--6--
		('M01','L06','80'),
		('M02','L06','4'),
		('M03','L06','40 meters'),
		('M04','L06','1'),
		--7--
		('M01','L07','100'),
		('M02','L07','5'),
		('M03','L07','30 meters'),
		('M04','L07','1'),
		--8--
		('M01','L08','40'),
		('M02','L08','1'),
		('M03','L08','8 meters'),
		--9--
		('M01','L09','65'),
		('M02','L09','3'),
		('M03','L09','18 meters'),
		--10--
		('M01','L10','70');


------------------------------------------------------------------------------------------------------------------------

INSERT INTO Invoice (Invoice_ID, Invoice_Material_ID, Customer_ID, Job_Card)
VALUES	('In001','L01', 'C001', '11000'),
		('In002','L02', 'C002', '10478'),
		('In003','L03', 'C003', '14253'),
		('In004','L04', 'C004', '11258'),
		('In005','L05', 'C005', '12058'),
		('In006','L06', 'C006', '13697'),
		('In007','L07', 'C007', '10211'),
		('In008','L08', 'C008', '10471'),
		('In009','L09', 'C009', '13521'),
		('In010','L10', 'C010', '10102');

------------------------------------------------------------------------------------------------------------------------

--Queries--

------------------------------------------------------------------------------------------------------------------------

--Write a query that selects all the job cards and which employees have worked on them.--
--(5)--

SELECT Employee.Employee_ID, Employee.Employee_Name, Job_Card
FROM Employee_Job, Employee
WHERE Employee.Employee_ID = Employee_Job.Employee_ID;

------------------------------------------------------------------------------------------------------------------------

-- Write a query that selects the materials that have been used on job cards of type ‘Full Conversion’. --
--(6)--

SELECT Job.Job_Card, Storage.Material_Name, Job_Type.Job_Type_ID
FROM Job, Job_Type, Storage
WHERE Job_Type.Job_Type_ID = Job.Job_Type_ID AND Job_Type.Job_Type_ID = 'Full Conversion';



------------------------------------------------------------------------------------------------------------------------

--Write a query that selects all the job cards that Chris Byne has worked on.--
--(7)--

SELECT Employee_Job.Job_Card
FROM Employee_Job
LEFT JOIN Employee ON Employee_Job.Employee_ID = Employee.Employee_ID
WHERE Employee_Name LIKE '%Byne';


------------------------------------------------------------------------------------------------------------------------

--Write a query that shows all job cards that have taken place in addresses that contain ‘0001’ or ‘0002’.--
--(8)--

SELECT Invoice.Job_Card
FROM Invoice
LEFT JOIN Customer ON Invoice.Customer_ID = Customer.Customer_ID
WHERE Customer_Address LIKE '%0001' OR Customer_Address LIKE '%0002';


------------------------------------------------------------------------------------------------------------------------

--Write a query that counts the number of jobs that have used electrical wiring.--
--(9)--

SELECT COUNT (Materials.Material_ID) AS Jobs_That_Use_Electrical_Wiring
FROM Materials
WHERE Material_ID LIKE 'M03';

------------------------------------------------------------------------------------------------------------------------

--Write a query that produces the output that could be used to prepare an invoice. This should include a calculation for VAT charged on a job card (calculated at 14% of total cost of the job card).--
--(10)--
--**THE WHERE CLAUSES WOULD BE CHANGED DEPENDING ON SITUATION**--
--**OUTPUT WILL BE DIFFERENT IF THE RATE IS UPDATED**--


SELECT Job.Job_Card,Customer.Customer_Name, Customer.Customer_Address, Employee.Employee_ID, Employee.Employee_Name , Job.Job_Type_ID,Materials.Material_Used ,Storage.Material_Name , Job_Type.Daily_Rate, Job.Days_For_Job,
(Job_Type.Daily_Rate * Job.Days_For_Job) AS Subtotal,
((Job_Type.Daily_Rate * Job.Days_For_Job) * 0.14) AS [VAT Amount (14%)], 
(((Job_Type.Daily_Rate * Job.Days_For_Job) * 0.14) + (Job_Type.Daily_Rate * Job.Days_For_Job)) AS Total
FROM Job, Job_Type, Customer, Invoice, Employee, Employee_Job, Storage, Materials, Invoice_Material
WHERE Customer.Customer_ID = Invoice.Customer_ID
AND Invoice.Job_Card = Job.Job_Card
AND Job_Type.Job_Type_ID = Job.Job_Type_ID
AND Employee.Employee_ID = Employee_Job.Employee_ID
AND Employee_Job.Job_Card = Job.Job_Card
AND Storage.Material_ID = Materials.Material_ID
AND Materials.Invoice_Material_ID = Invoice_Material.Invoice_Material_ID
AND Invoice_Material.Invoice_Material_ID = Invoice.Invoice_Material_ID
ORDER BY Job.Job_Card , Employee.Employee_ID; 


------------------------------------------------------------------------------------------------------------------------

--Update the daily rate of pay for a Full Conversion to R1 440.00.--

UPDATE Job_Type
SET Daily_Rate = 1440
WHERE Job_Type_ID = 'Full Conversion';

-- Check if its updated.--
SELECT * 
FROM Job_Type;

------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------
--Stored procedures--
--Creating new Job_Cards--
CREATE PROCEDURE dbo.Create_New_Job_Card
(
@Job_Card VARCHAR (12),
@Job_Type_ID VARCHAR (30),
@Days_For_Job INT
)
AS
BEGIN
INSERT INTO Job VALUES (@Job_Card, @Job_Type_ID, @Days_For_Job)
END

DROP PROCEDURE dbo.Create_New_Job_Card;
------------------------------------------------------------------------------------------------------------------------
--View all Job_Cards--

CREATE PROCEDURE dbo.View_All_Job_Cards
AS
BEGIN
SELECT Job.Job_Card, Job_Type.Job_Type_ID, Job_Type.Daily_Rate, Job.Days_For_Job
FROM Job, Job_Type
WHERE Job_Type.Job_Type_ID = Job.Job_Type_ID
END


DROP PROCEDURE dbo.View_All_Job_Cards;
------------------------------------------------------------------------------------------------------------------------
--Delete Job_Cards--

CREATE PROCEDURE dbo.DeleteJob_CardbyID
(
@Job_Card VARCHAR (12)
)
AS
BEGIN
DELETE FROM Job WHERE Job_Card = @Job_Card
END

DROP PROCEDURE dbo.DeleteJob_CardbyID
------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------
--Creating new Invoices--

CREATE PROCEDURE dbo.Create_New_Invoices
(
@Invoice_ID VARCHAR (12),
@Invoice_Material_ID VARCHAR (12),
@Customer_ID VARCHAR (12),
@Job_Card VARCHAR (12)
)
AS
BEGIN
INSERT INTO Invoice VALUES (@Invoice_ID, @Invoice_Material_ID, @Customer_ID, @Job_Card)
END


DROP PROCEDURE dbo.Create_New_Invoices;
------------------------------------------------------------------------------------------------------------------------
--Retrieve Invoices--

CREATE PROCEDURE dbo.View_All_Invoices
AS
BEGIN
SELECT Invoice.Invoice_ID, Invoice_Material.Invoice_Material_ID, Customer.Customer_ID, Job.Job_Card
FROM Invoice, Invoice_Material, Customer, Job
WHERE Invoice_Material.Invoice_Material_ID = Invoice.Invoice_Material_ID
AND Customer.Customer_ID = Invoice.Customer_ID
AND Job.Job_Card = Invoice.Job_Card
END

DROP PROCEDURE dbo.View_All_Invoices;
------------------------------------------------------------------------------------------------------------------------
--Delete Invoices--

CREATE PROCEDURE dbo.DeleteInvoicebyID
(
@Invoice_ID VARCHAR (12)
)
AS
BEGIN
DELETE FROM Invoice WHERE Invoice_ID = @Invoice_ID
END

DROP PROCEDURE dbo.DeleteInvoicebyID

------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------
--Create Employees--

CREATE PROCEDURE dbo.Create_Employees
(
@Employee_ID VARCHAR (12),
@Employee_Name VARCHAR (30)
)
AS
BEGIN
INSERT INTO Employee VALUES (@Employee_ID, @Employee_name)
END

DROP PROCEDURE dbo.Create_Employees;
------------------------------------------------------------------------------------------------------------------------
--View Employees--

CREATE PROCEDURE dbo.Update_Employee
(
@Employee_ID VARCHAR (12),
@Employee_Name VARCHAR (30)
)
AS
BEGIN
UPDATE Employee
SET
Employee_Name = @Employee_Name
WHERE Employee_ID = @Employee_ID
END

DROP PROCEDURE dbo.Update_Employee;
------------------------------------------------------------------------------------------------------------------------
--Retrieve All Employees--
CREATE PROCEDURE dbo.View_All_Employees
AS 
BEGIN
SELECT * FROM Employee
END

DROP PROCEDURE dbo.View_All_Employees;
------------------------------------------------------------------------------------------------------------------------
--Delete Employees--
CREATE PROCEDURE dbo.DeleteEmployeebyID
(
@Employee_ID VARCHAR (12)
)
AS
BEGIN
DELETE FROM Employee WHERE Employee_ID = @Employee_ID
END

DROP PROCEDURE dbo.DeleteEmployeebyID;
------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------


------------------------------------------------------------------------------------------------------------------------
--View all job Types--
CREATE PROCEDURE dbo.View_All_Job_Types
AS
BEGIN
SELECT Job_Type.Job_Type_ID, Job_Type.Daily_Rate FROM Job_Type
END

DROP PROCEDURE dbo.View_All_Job_Types
------------------------------------------------------------------------------------------------------------------------
--Update job_type daily rate--
CREATE PROCEDURE dbo.Update_Job_Type
(
@Job_Type_ID VARCHAR (12),
@Daily_Rate FLOAT
)
AS
BEGIN
UPDATE Job_Type
SET 
Daily_Rate = @Daily_Rate
WHERE Job_Type_ID = @Job_Type_ID
END

DROP PROCEDURE dbo.Update_Job_Type;
------------------------------------------------------------------------------------------------------------------------
