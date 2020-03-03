/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM [dbo].[Permissions]
DELETE FROM [dbo].[Examiners]
DELETE FROM [dbo].[Examinees]
DELETE FROM [dbo].[Addresses]

DBCC CHECKIDENT ('[dbo].[Permissions]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Examiners]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Examinees]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Addresses]', RESEED, 0);

:r .\InitialValues\AddAddresses.sql
:r .\InitialValues\AddExaminees.sql
:r .\InitialValues\AddExaminers.sql
:r .\InitialValues\AddPermissions.sql

