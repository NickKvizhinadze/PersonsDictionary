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