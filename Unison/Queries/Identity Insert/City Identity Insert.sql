SET IDENTITY_INSERT unison.dbo.city ON;
INSERT      INTO UNISON.DBO.CITY(ID, NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE)
            SELECT     ID, NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE
                                                       FROM         Backups.dbo.CITY AS CITY_1
                                          WHERE     (STATECODE = 'WA') AND (ZIPCODE = '98104');
SET              IDENTITY_INSERT unison.dbo.city OFF;