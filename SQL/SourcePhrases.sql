IF NOT EXISTS (SELECT 1 
			   FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = N'dbo' AND  TABLE_NAME = N'SourcePhrases')
BEGIN
	CREATE TABLE [dbo].[SourcePhrases]
	(
		Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
		DictionaryId INT NOT NULL,
		Value NVARCHAR(200) NOT NULL,
		CreatedAt DATETIME NOT NULL,
		UpdatedAt DATETIME NULL,
	)

	-- DictionaryId references table dbo.Dictionaries.
	ALTER TABLE SourcePhrases
		ADD CONSTRAINT [FK_SourcePhrases_Dictionaries]
		FOREIGN KEY(DictionaryId)
		REFERENCES Dictionaries (Id)
END
