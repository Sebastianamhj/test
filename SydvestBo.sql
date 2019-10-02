USE [master]
GO
 
IF EXISTS(SELECT * FROM sys.DATABASES WHERE name = 'SydvestDB')
BEGIN
    DROP DATABASE SydvestDB
    print 'Drop database'
END
GO
 
CREATE DATABASE SydvestDB
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'SydvestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.H1SOMMER\MSSQL\DATA\SydvestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON
( NAME = N'SydvestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.H1SOMMER\MSSQL\DATA\SydvestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
 
USE SydvestDB;
 
CREATE TABLE PostNrby
(
    postNr SMALLINT CHECK (postNr > 999 AND postNr < 10000),
    ByNavn nvarchar(50) NOT NULL,
	CONSTRAINT PK_PostNrby_postNr PRIMARY KEY (postNr)
 
)
GO
 
CREATE TABLE konsulenter
(
    konsulenterID INT IDENTITY(1,1),
    Fornavn nvarchar(50) NOT NULL,
    Efternavn nvarchar(100) NOT NULL,
    Adresse nvarchar(255) NOT NULL,
    Telefon INT,
    PostNr SMALLINT NOT NULL,
    Område SMALLINT NOT NULL,

	CONSTRAINT PK_konsulenter_konsulenterID PRIMARY KEY (konsulenterID),
	CONSTRAINT FK_konsulenter_PostNr FOREIGN KEY (PostNr) REFERENCES PostNrby (postNr),
	CONSTRAINT FK_konsulenter_Område FOREIGN KEY (Område) REFERENCES PostNrby (postNr),
)
GO
 
 
 
CREATE TABLE Ejer
(
    EjerID INT IDENTITY(1,1),
    Fornavn nvarchar(50) NOT NULL,
    Efternavn nvarchar(100) NOT NULL,
    AdresseEjer nvarchar(255) NOT NULL,
    PostNr SMALLINT NOT NULL,
    Telefon INT

	CONSTRAINT PK_Ejer_EjerID PRIMARY KEY (EjerID),
	CONSTRAINT FK_Ejer_PostNr FOREIGN KEY (PostNr) REFERENCES PostNrby (postNr),
)
GO
 
 
 
CREATE TABLE SommerHuse
(
    SommerHusID INT IDENTITY(1,1),
    PostNr SMALLINT NOT NULL,
    Adresse nvarchar(255) NOT NULL,
    Senge SMALLINT NOT NULL,
    Stoerrelse SMALLINT NOT NULL,
    Klassificering nvarchar(10), --Må gerne være null, hvis den ikke er blevet kvalificeret
    StandardUgePris SMALLINT NOT NULL,
    Opsynsmand nvarchar(255) NOT NULL,
    Godkendt nvarchar(50) NOT NULL,
    EjerID INT NOT NULL,

	CONSTRAINT PK_SommerHuse_SommerHusID PRIMARY KEY (SommerHusId),
	CONSTRAINT FK_SommerHuse_PostNr FOREIGN KEY (PostNr) REFERENCES PostNrby (postNr),
	CONSTRAINT FK_SommerHuse_EjerId FOREIGN KEY (EjerID) REFERENCES Ejer (EjerID),
)
GO
 
 
 
CREATE TABLE Reservationer
(
    ReservationID INT IDENTITY(1,1),
    SommerhusID INT NOT NULL,
    Dage nvarchar(150) NOT NULL,
    StartDato nvarchar(100) NOT NULL,
    Sæson nvarchar(100) NOT NULL,
    KundeTelefon INT,
    Kundenavn nvarchar(255) NOT NULL,
    Salgspris INT NOT NULL,

	CONSTRAINT PK_Reservationer_ReservationID PRIMARY KEY (ReservationID),
	CONSTRAINT FK_Reservationer_SommerhusID FOREIGN KEY (SommerhusID) REFERENCES SommerHuse (SommerHusID)
)
GO
 
INSERT INTO PostnrBy VALUES (4000, 'Roskilde'),
                            (2750, 'Ballerup'),
                            (5000, 'Odense'  ),
                            (2730, 'Herlev'  ),
                            (7300, 'Jelling' ),
                            (8600, 'Silkeborg'),
                            (2000, 'Frederiksberg'),
                            (2400, 'København NV')
GO
 
 
INSERT INTO Ejer VALUES ('Gunnar', 'Bo', 'Fuglebakken 88', 2730, 91929394),
                        ('Lars', 'Hjortshøj', 'Strandvænget 22', 2750, 20304050),
                        ('Kim', 'Hansen', 'Sortepervej 54', 2750, 30405060)        
GO
 
 
INSERT INTO SommerHuse VALUES (2730, 'Solsortevej 24', 4, 70, 'Hustle', 4000, 'Jens karlsen', 'Godkendt',1),
                        (2750, 'Rentemestervej 77', 10, 250, 'Luksus', 10000, 'Peter Jensen', 'Godkendt',3),
                        (8600, 'Silkeborgvej 63', 6, 110, 'Budget', 2600, 'Hans Bo', 'Ikke Godkendt',3)        
GO
 
 
INSERT INTO Reservationer VALUES (2, 5, '27-07-2019', 'Super', 23124376, 'bente Larsen', 2000),
                                 (3, 10, '13-07-2019', 'Super', 58736871, 'Klaus bentsen', 3000),
                                 (1, 5, '17-06-2019', 'Høj', 53807266,'Emil Dalange', 16000),
                                 (3, 5, '10-02-2019', 'Lav', 76832658,'Daniel hansen', 5000)
GO
 
 
INSERT INTO konsulenter VALUES ('Søren','Pedersen','Smøralle 189', 85473921, 2730, 7300),
                               ('Rasmus','Jensen','Nattergalevej 64', 73254323, 2000, 2400),
                               ('Hanne','Larsen','Guldbergsgade 12', 29253446, 2400, 2000),
                               ('Hans', 'Andersen', 'Ligustervænget 42', 01020304, 2730, 2750),
                               ('Bent', 'Olesen', 'Solvej 27', 50607080, 5000, 4000),
                               ('Lise', 'Pedersen', 'Nattergalevej 13', 10203040, 7300, 8600)
GO