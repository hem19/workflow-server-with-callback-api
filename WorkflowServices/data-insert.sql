INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'8d378ebe-0666-46b3-b7ab-1a52480fd12a', N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'412174c2-0490-4101-a7b3-830de90bcaa0', N'Manager')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'71fffb5b-b707-4b3c-951c-c37fdfcc8dfb', N'User')

INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'e41b48e3-c03d-484f-8764-1711248c4f8a', N'Arun', N'412174c2-0490-4101-a7b3-830de90bcaa0')
INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'bbe686f8-8736-48a7-a886-2da25567f978', N'Saurabh', N'8d378ebe-0666-46b3-b7ab-1a52480fd12a')
INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'81537e21-91c5-4811-a546-2dddff6bf409', N'Hemendra', N'71fffb5b-b707-4b3c-951c-c37fdfcc8dfb')
INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'b0e6fd4c-2db9-4bb6-a62e-68b6b8999905', N'Hemant', N'71fffb5b-b707-4b3c-951c-c37fdfcc8dfb')
INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'deb579f9-991c-4db9-a17d-bb1eccf2842c', N'Arpit', N'71fffb5b-b707-4b3c-951c-c37fdfcc8dfb')
INSERT [dbo].[Employee] ([Id], [Name], [RoleId]) VALUES (N'91f2b471-4a96-4ab7-a41a-ea4293703d16', N'Rohit', N'71fffb5b-b707-4b3c-951c-c37fdfcc8dfb')

