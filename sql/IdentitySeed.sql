USE [EuvicIdentity]
GO
INSERT [dbo].[AspNetUsers] ([Id], [AttendeeId], [LecturerId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'59319402-696b-4509-ba9c-e58efb6ced75', 3, 3, N'kamil.paszkowski@euvic.pl', N'KAMIL.PASZKOWSKI@EUVIC.PL', N'kamil.paszkowski@euvic.pl', N'KAMIL.PASZKOWSKI@EUVIC.PL', 1, N'AQAAAAEAACcQAAAAEJIjzVDisnaZUR+ocDikwWTu+W44+fl4ptZ+5JWYSrmW5wHnASSCZd7hbJ37Ga9opw==', N'LV3IYJFAEA7QYTNHNHM64ZSDHE6IMFS7', N'4631db15-f4fc-4f78-bc70-edbd62d856f7', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [AttendeeId], [LecturerId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6195d55d-b868-4818-b02f-2e91514fed51', 20013, NULL, N'hr@euvic.pl', N'HR@EUVIC.PL', N'hr@euvic.pl', N'HR@EUVIC.PL', 1, N'AQAAAAEAACcQAAAAEGJ78F+T1x+qTi86kOPCRfCK+tMFqjclw8NAkV8736bH6Jv3YfJpCRTxgRjerYI2rw==', N'MSGNS6M72I6VX2YTQIWVNGTWWRRWOGVX', N'22c12b3c-45ad-445e-98a6-33b33566ae59', NULL, 0, 0, NULL, 1, 0)
GO

DECLARE @attendeeRoleId nvarchar(450);
DECLARE @lecturerRoleId nvarchar(450);
DECLARE @hrRoleId nvarchar(450);

SET @attendeeRoleId = (SELECT Id FROM [dbo].[AspNetRoles] where Name = 'Attendee')
SET @hrRoleId = (SELECT Id FROM [dbo].[AspNetRoles] where Name = 'HR')
SET @lecturerRoleId = (SELECT Id FROM [dbo].[AspNetRoles] where Name = 'Lecturer')

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'59319402-696b-4509-ba9c-e58efb6ced75', @attendeeRoleId)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6195d55d-b868-4818-b02f-2e91514fed51', @attendeeRoleId)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'59319402-696b-4509-ba9c-e58efb6ced75', @lecturerRoleId)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6195d55d-b868-4818-b02f-2e91514fed51', @hrRoleId)
