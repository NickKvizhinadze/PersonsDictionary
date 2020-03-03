CREATE DATABASE PersonsDictionary
GO

CREATE TABLE PersonsDictionary.dbo.Cities (
  Id int IDENTITY,
  Name nvarchar(50) NOT NULL
)
ON [PRIMARY]
GO

CREATE TABLE PersonsDictionary.dbo.Persons (
  Id int IDENTITY,
  FirstName nvarchar(50) NOT NULL,
  LastName nvarchar(50) NOT NULL,
  PersonalId nvarchar(50) NOT NULL,
  Gender int NOT NULL,
  BirthDate date NOT NULL,
  CityId int NOT NULL,
  ImageUrl nvarchar(1000) NULL
)
ON [PRIMARY]
GO

ALTER TABLE PersonsDictionary.dbo.Persons
  ADD CONSTRAINT FK_Persons_CityId FOREIGN KEY (CityId) REFERENCES dbo.Cities (Id)
GO

CREATE TABLE PersonsDictionary.dbo.PhoneNumbers (
  Id int IDENTITY,
  PersonId int NOT NULL,
  Value nvarchar(20) NOT NULL,
  Type int NOT NULL
)
ON [PRIMARY]
GO

ALTER TABLE PersonsDictionary.dbo.PhoneNumbers
  ADD CONSTRAINT FK_MobileNumbers_PersonId FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id) ON DELETE CASCADE
GO

CREATE TABLE PersonsDictionary.dbo.PersonRelations (
  Id int IDENTITY,
  PersonId int NOT NULL,
  RelatedPersonId int NOT NULL,
  Type int NULL
)
ON [PRIMARY]
GO

ALTER TABLE PersonsDictionary.dbo.PersonRelations
  ADD CONSTRAINT FK_PersonRelations_PersonId FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id)
GO

ALTER TABLE PersonsDictionary.dbo.PersonRelations
  ADD CONSTRAINT FK_PersonRelations_RelatedPersonId FOREIGN KEY (RelatedPersonId) REFERENCES dbo.Persons (Id)
GO

CREATE VIEW [dbo].[vGetPersonsRelationsCountByType]
AS
SELECT        p.Id AS PersonId, p.FirstName, p.LastName, p.PersonalId, r.Type, COUNT(r.Id) AS Count
FROM            dbo.Persons AS p INNER JOIN
                         dbo.PersonRelations AS r ON r.PersonId = p.Id
GROUP BY r.Type, p.Id, p.FirstName, p.LastName, p.PersonalId
GO
