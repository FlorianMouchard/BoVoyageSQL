DROP DATABASE BoVoyage 
GO

CREATE DATABASE BoVoyage
GO 
USE [BoVoyage]
GO
/****** Object:  Table [dbo].[AgencesVoyage]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencesVoyage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AgencesVoyage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssurancesAnnulation]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssurancesAnnulation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_AssurancesAnnulation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Civilite] [varchar](50) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Adresse] [varchar](50) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[DateNaissance] [date] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinations]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Continent] [varchar](50) NULL,
	[Pays] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Region] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Destinations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DossiersReservation]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DossiersReservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCarteBancaire] [varchar](50) NOT NULL,
	[PrixTotal] [money] NOT NULL,
	[IdVoyage] [int] NOT NULL,
	[NombreParticipants] [int] NULL,
	[IdAssurance] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[EtatDossier] [varchar](50) NOT NULL,
	[RaisonAnnulation] [varchar](50) NULL,
 CONSTRAINT [PK_DossierReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EtatsDossierReservation]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EtatsDossierReservation](
	[Etat] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EtatsDossierReservation_1] PRIMARY KEY CLUSTERED 
(
	[Etat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Civilite] [varchar](50) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Adresse] [varchar](50) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[DateNaissance] [date] NOT NULL,
	[Reduction] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaisonsAnnulationDossier]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaisonsAnnulationDossier](
	[RaisonAnnulation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RaisonsAnnulationDossier_1] PRIMARY KEY CLUSTERED 
(
	[RaisonAnnulation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voyages]    Script Date: 15/06/2018 17:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voyages](
	[DateAller] [datetime] NOT NULL,
	[DateRetour] [date] NOT NULL,
	[PlacesDisponibles] [int] NOT NULL,
	[TarifToutCompris] [money] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDestination] [int] NOT NULL,
	[IdAgence] [int] NOT NULL,
 CONSTRAINT [PK_Voyages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AgencesVoyage] ON 

INSERT [dbo].[AgencesVoyage] ([Id], [Nom]) VALUES (1, N'AuBoutDuMonde')
INSERT [dbo].[AgencesVoyage] ([Id], [Nom]) VALUES (2, N'JetSwag.com')
INSERT [dbo].[AgencesVoyage] ([Id], [Nom]) VALUES (3, N'WorldTours')
INSERT [dbo].[AgencesVoyage] ([Id], [Nom]) VALUES (4, N'SuperTrip')
INSERT [dbo].[AgencesVoyage] ([Id], [Nom]) VALUES (5, N'GlobalWanderers')
SET IDENTITY_INSERT [dbo].[AgencesVoyage] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [Civilite], [Nom], [Prenom], [Email], [Adresse], [Telephone], [DateNaissance]) VALUES (8, N'Mme', N'Leila', N'Yvatte', N'yvatilleuls@yeahmail.com', N'55 rue des tilleurs', N'547989245', CAST(N'1987-06-23' AS Date))
INSERT [dbo].[Clients] ([Id], [Civilite], [Nom], [Prenom], [Email], [Adresse], [Telephone], [DateNaissance]) VALUES (9, N'Mr ', N'John', N'Travolta', N'lemail@mail.ok', N'98 rue du petit pont', N'0135648265124', CAST(N'1999-03-08' AS Date))
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Destinations] ON 

INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (1, N'Afrique', N'Benin', NULL, N'Afrique de l''Ouest')
INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (2, N'Amérique', N'Guatemala', NULL, N'Amerique Centrale')
INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (3, N'Asie', N'Birmanie', N'Moins touristique que la Thailande', N'Asie du Sud-Est')
INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (4, N'Europe', N'Suede', N'', N'Scandinavie')
INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (5, N'Amerique', N'Canada', N'', N'Amerique du Nord')
INSERT [dbo].[Destinations] ([Id], [Continent], [Pays], [Description], [Region]) VALUES (6, N'Asie', N'Nouvelle Zelande', NULL, N'Pacifique')
SET IDENTITY_INSERT [dbo].[Destinations] OFF
INSERT [dbo].[EtatsDossierReservation] ([Etat]) VALUES (N'Accepte')
INSERT [dbo].[EtatsDossierReservation] ([Etat]) VALUES (N'EnAttente')
INSERT [dbo].[EtatsDossierReservation] ([Etat]) VALUES (N'EnCours')
INSERT [dbo].[EtatsDossierReservation] ([Etat]) VALUES (N'Refuse')
INSERT [dbo].[RaisonsAnnulationDossier] ([RaisonAnnulation]) VALUES (N'Client')
INSERT [dbo].[RaisonsAnnulationDossier] ([RaisonAnnulation]) VALUES (N'PlacesInsuffisantes')
SET IDENTITY_INSERT [dbo].[Voyages] ON 

INSERT [dbo].[Voyages] ([DateAller], [DateRetour], [PlacesDisponibles], [TarifToutCompris], [Id], [IdDestination], [IdAgence]) VALUES (CAST(N'2018-06-19T00:00:00.000' AS DateTime), CAST(N'2018-06-30' AS Date), 3, 456.0000, 5, 2, 2)
INSERT [dbo].[Voyages] ([DateAller], [DateRetour], [PlacesDisponibles], [TarifToutCompris], [Id], [IdDestination], [IdAgence]) VALUES (CAST(N'2018-07-07T00:00:00.000' AS DateTime), CAST(N'2018-07-16' AS Date), 3, 256.0000, 6, 3, 3)
INSERT [dbo].[Voyages] ([DateAller], [DateRetour], [PlacesDisponibles], [TarifToutCompris], [Id], [IdDestination], [IdAgence]) VALUES (CAST(N'2018-06-26T00:00:00.000' AS DateTime), CAST(N'2018-07-05' AS Date), 5, 654.0000, 8, 4, 4)
INSERT [dbo].[Voyages] ([DateAller], [DateRetour], [PlacesDisponibles], [TarifToutCompris], [Id], [IdDestination], [IdAgence]) VALUES (CAST(N'2018-06-15T00:00:00.000' AS DateTime), CAST(N'2018-07-19' AS Date), 1, 2500.0000, 12, 6, 2)
SET IDENTITY_INSERT [dbo].[Voyages] OFF
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_AssurancesAnnulation] FOREIGN KEY([IdAssurance])
REFERENCES [dbo].[AssurancesAnnulation] ([Id])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_AssurancesAnnulation]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_Clients]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_EtatsDossierReservation] FOREIGN KEY([EtatDossier])
REFERENCES [dbo].[EtatsDossierReservation] ([Etat])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_EtatsDossierReservation]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_Participants] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Participants] ([Id])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_Participants]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_RaisonsAnnulationDossier] FOREIGN KEY([RaisonAnnulation])
REFERENCES [dbo].[RaisonsAnnulationDossier] ([RaisonAnnulation])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_RaisonsAnnulationDossier]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_Voyages] FOREIGN KEY([IdVoyage])
REFERENCES [dbo].[Voyages] ([Id])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_Voyages]
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD  CONSTRAINT [FK_Voyages_AgencesVoyage] FOREIGN KEY([IdAgence])
REFERENCES [dbo].[AgencesVoyage] ([Id])
GO
ALTER TABLE [dbo].[Voyages] CHECK CONSTRAINT [FK_Voyages_AgencesVoyage]
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD  CONSTRAINT [FK_Voyages_Destinations] FOREIGN KEY([IdDestination])
REFERENCES [dbo].[Destinations] ([Id])
GO
ALTER TABLE [dbo].[Voyages] CHECK CONSTRAINT [FK_Voyages_Destinations]
GO
