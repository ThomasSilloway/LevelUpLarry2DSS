SELECT AmountType, EarnedAmount FROM

(SELECT 'Bits' AS AmountType, FLOOR(SUM(Bits)/100) AS EarnedAmount FROM Twitch_Bits) AS cc

UNION

(SELECT 'Subs' AS AmountType, SUM(Tier * 2.5) AS EarnedAmount
FROM 
(SELECT CASE 
WHEN Tier = 0 OR TIER = 1 THEN 1
ELSE Tier
END AS Tier
FROM Twitch_Subscriptions) AS aa);

SELECT * FROM Twitch_Bits;
SELECT * FROM Twitch_Subscriptions;