﻿IF EXISTS (SELECT * 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Recipes' AND COLUMN_NAME = 'RecipeTypeId')
BEGIN
	ALTER TABLE Recipes
	DROP COLUMN RecipeTypeId
END

ALTER TABLE Recipes
ADD RecipeTypeId int 