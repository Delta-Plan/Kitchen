RESTORE FILELISTONLY
FROM DISK = N'C:\Users\S.rozhin\stady\kitchen\KitchenDb_22.33_15.05.2014.bak'

RESTORE DATABASE KitchenDb 
FROM DISK = 'C:\Users\S.rozhin\stady\kitchen\KitchenDb_22.33_15.05.2014.bak'
WITH 
MOVE 'KitchenDb' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KitchenDb.mdf', 
MOVE 'KitchenDb_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KitchenDb_log.mdf'