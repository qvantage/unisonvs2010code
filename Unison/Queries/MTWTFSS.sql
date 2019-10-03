select 
(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 1), 0) when '1' then 'Y' else 'N' end) as M 
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 2), 0) when '2' then 'Y' else 'N' end) as T 
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 3), 0) when '3' then 'Y' else 'N' end) as W
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 4), 0) when '4' then 'Y' else 'N' end) as Th
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 5), 0) when '5' then 'Y' else 'N' end) as F
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 6), 0) when '6' then 'Y' else 'N' end) as Sa
,(case isnull((SELECT m.day FROM ServiceSchedules m where m.AccountID = z.AccountID and m.sid = z.id and m.day = 7), 0) when '7' then 'Y' else 'N' end) as Su
from AccountServices z where z.AccountID = 21119 and z.id = 3