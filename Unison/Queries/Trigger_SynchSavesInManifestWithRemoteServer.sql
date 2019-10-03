set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER TRIGGER [ManifestUpdate] ON [dbo].[MANIFEST]
FOR INSERT, UPDATE
AS
begin
SET XACT_ABORT ON
insert into ntsrvr.[TOP].dbo.Manifest select m.* from Manifest m, inserted i where m.rowid = i.rowid
end