INSERT INTO UN_Rights
SELECT     'TPC' AS Company_Code, 'ALI' AS USERID, Obj_Name, Obj_Type, 1 AS [view], 1 AS Edit, 1 AS [Delete], 1 AS [Print]
FROM         UN_Objects o

SELECT     r.*, o.Obj_ID AS Obj_ID
FROM         UN_Rights r LEFT OUTER JOIN
                      UN_Objects o ON r.Obj_Name = o.Obj_Name
ORDER BY o.Obj_ID



SELECT Obj_Name, SUM([View]) AS [VIEW], SUM(Edit) AS Edit, SUM([Delete]) AS [DELETE], SUM([Print]) AS [PRINT]
FROM (SELECT  *  FROM UN_Rights WHERE userid = 'ALI'
      UNION
      SELECT *  FROM  UN_Rights WHERE userid IN  (SELECT Group_Code   FROM  UN_UserMemberships   WHERE  UserID = 'ALI')) u
GROUP BY Obj_Name
ORDER BY Obj_Name



