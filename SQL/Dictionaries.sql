IF NOT EXISTS (SELECT 1 
			   FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = N'dbo' AND  TABLE_NAME = N'Dictionaries')
BEGIN
	CREATE TABLE [dbo].[Dictionaries]
	(
		Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
		SourceLanguageId INT NOT NULL,
		TargetLanguageId INT NOT NULL,
		Name NVARCHAR(50) NOT NULL,
		Description NVARCHAR(200) NULL,
		CreatedAt DATETIME NOT NULL,
		UpdatedAt DATETIME NULL,
	)

	-- SourceLanguageId references table dbo.Languages.
	ALTER TABLE Dictionaries
		ADD CONSTRAINT [FK_Dictionaries_Languages_1]
		FOREIGN KEY(SourceLanguageId)
		REFERENCES Languages (Id)

	-- TargetLanguageId references table dbo.Languages.
	ALTER TABLE Dictionaries
		ADD CONSTRAINT [FK_Dictionaries_Languages_2]
		FOREIGN KEY(TargetLanguageId)
		REFERENCES Languages (Id)
END
