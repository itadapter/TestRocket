﻿CREATE TABLE [dbo].[ROWID_BODY]
(
  [GDID] [binary](12) NOT NULL,
  [ROWID] [bigint] IDENTITY(1,1) NOT NULL,
  [BODY] NVARCHAR(MAX)  NULL,
  CONSTRAINT [PK_ROWID_BODY] PRIMARY KEY CLUSTERED
  (
    [ROWID] ASC
  )
)
