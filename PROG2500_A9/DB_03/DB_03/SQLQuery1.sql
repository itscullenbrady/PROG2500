
DROP TABLE IF EXISTS [dbo].Person;

CREATE TABLE [dbo].Person
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fname] NCHAR(10) NOT NULL, 
    [lname] NCHAR(10) NOT NULL, 
    [address] NCHAR(10) NOT NULL
);

INSERT INTO Person  (fname ,lname , address )  VALUES ('Cullen', 'Murphy', 'Amherst');
