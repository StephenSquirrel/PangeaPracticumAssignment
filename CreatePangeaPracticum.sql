CREATE DATABASE [PangeaPracticum];
GO

USE [PangeaPracticum];
GO

CREATE TABLE [PangeaRecords](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [jsonData] [nvarchar](max) NULL,
    [xmlData] [nvarchar](max) NULL,
);
GO
