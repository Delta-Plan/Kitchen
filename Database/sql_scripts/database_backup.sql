declare @path nvarchar(200)
declare @fullPath nvarchar(200)
set @path = 'C:\Users\S.rozhin\stady\kitchen\KitchenDb_'
set @fullPath = CONCAT (@path,CONVERT (date, GETDATE()),'.bak')

BACKUP DATABASE KitchenDb
TO DISK = @fullPath
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of KitchenDb 2014';
