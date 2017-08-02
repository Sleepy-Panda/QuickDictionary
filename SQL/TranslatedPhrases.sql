IF NOT EXISTS (SELECT 1 
			   FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_SCHEMA = N'dbo' AND  TABLE_NAME = N'TranslatedPhrases')
BEGIN
	CREATE TABLE [dbo].[TranslatedPhrases]
	(
		Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
		SourcePhraseId INT NOT NULL,
		Value NVARCHAR(200) NOT NULL,
	)

	-- SourcePhraseId references table dbo.SourcePhrases.
	ALTER TABLE TranslatedPhrases
		ADD CONSTRAINT [FK_TranslatedPhrases_SourcePhrases]
		FOREIGN KEY(SourcePhraseId)
		REFERENCES SourcePhrases (Id)
END
