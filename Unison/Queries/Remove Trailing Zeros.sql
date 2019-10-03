SELECT ID, REVERSE(REPLACE(RTRIM(REPLACE(REVERSE(ID), '0', ' ')), ' ', '0'))
FROM ROUTES


=========================================

;Add OfficID. Route should be 2 chars so 1 = 01

UPDATE routes
SET ID = CONVERT(varchar, OfficeID) + ISNULL(REPLICATE('0', 2 - len(id)), '') + id