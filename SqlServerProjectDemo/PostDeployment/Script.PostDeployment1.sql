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
IF EXISTS (SELECT 1 FROM T_Custom)
BEGIN
  PRINT 'Data already exists in T_Custom';
END
ELSE
BEGIN
  PRINT 'excute InitalCustomer.sql';
  :r .\InitialCustomer.sql
END

IF EXISTS (SELECT 1 FROM T_Product)
BEGIN
  PRINT 'Data already exists in T_Product';
END
ELSE
BEGIN
  PRINT 'excute InitialProduct.sql';
  :r .\InitialProduct.sql
END

IF EXISTS (SELECT 1 FROM T_Order)
BEGIN
  PRINT 'Data already exists in T_Order';
END
ELSE
BEGIN
  PRINT 'excute InitialOrder.sql';
  :r .\InitialOrder.sql
END

