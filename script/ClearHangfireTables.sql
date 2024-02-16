TRUNCATE TABLE [HangFire].[AggregatedCounter];
TRUNCATE TABLE [HangFire].[Counter];
TRUNCATE TABLE [HangFire].[Hash];

TRUNCATE TABLE [HangFire].[JobParameter];
TRUNCATE TABLE [HangFire].[JobQueue];
TRUNCATE TABLE [HangFire].[List];
TRUNCATE TABLE [HangFire].[Schema];
TRUNCATE TABLE [HangFire].[Server];
TRUNCATE TABLE [HangFire].[Set];
TRUNCATE TABLE [HangFire].[State];

DELETE FROM [HangFire].[Job] WHERE 1=1;