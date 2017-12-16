CREATE TABLE [dbo].[ProducerTrack]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProducerId] INT NOT NULL, 
    [TrackId] INT NOT NULL, 
    CONSTRAINT [FK_ProducerTrack_Producer] FOREIGN KEY ([ProducerId]) REFERENCES [Producer]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_ProducerTrack_Track] FOREIGN KEY ([TrackId]) REFERENCES [Track]([Id])
)
