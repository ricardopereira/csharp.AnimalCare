
-- -----------------------------------------------------
-- Table [dbo].[BusinessSector]
-- -----------------------------------------------------
CREATE TABLE [dbo].[BusinessSector] (
  [BusinessSectorID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(100) NOT NULL,
  PRIMARY KEY ([BusinessSectorID]))


-- -----------------------------------------------------
-- Table [dbo].[Countries]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Countries] (
  [CountryID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(45) NOT NULL,
  [ISO3166] INT NULL,
  PRIMARY KEY ([CountryID]))


-- -----------------------------------------------------
-- Table [dbo].[Owners]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Owners] (
  [OwnerID] INT NOT NULL IDENTITY,
  [UserID] UNIQUEIDENTIFIER NOT NULL,
  [Name] VARCHAR(45) NULL,
  [Business] BIT NULL,
  [BusinessSectorID] INT NULL,
  [TaxNumber] VARCHAR(15) NULL,
  [MobileNumber] VARCHAR(20) NULL,
  [FaxNumber] VARCHAR(20) NULL,
  [Inactive] BIT NULL,
  [CountryID] INT NULL,
  PRIMARY KEY ([OwnerID]),
  CONSTRAINT [fk_Owners_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users] ([UserId]),
  CONSTRAINT [fk_Owners_BusinessSector]
    FOREIGN KEY ([BusinessSectorID])
    REFERENCES [dbo].[BusinessSector] ([BusinessSectorID]),
  CONSTRAINT [fk_Owners_Countries]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries] ([CountryID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalSpecies]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalSpecies] (
  [AnimalSpecieID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([AnimalSpecieID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalRaces]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalRaces] (
  [AnimalRaceID] INT NOT NULL IDENTITY,
  [AnimalSpecieID] INT NOT NULL,
  [Name] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([AnimalRaceID]),
  CONSTRAINT [fk_AnimalRaces_AnimalSpecies]
    FOREIGN KEY ([AnimalSpecieID])
    REFERENCES [dbo].[AnimalSpecies] ([AnimalSpecieID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalConditions]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalConditions] (
  [AnimalConditionID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([AnimalConditionID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalHabitats]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalHabitats] (
  [AnimalHabitatID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([AnimalHabitatID]))


-- -----------------------------------------------------
-- Table [dbo].[Cities]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Cities] (
  [CityID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([CityID]))


-- -----------------------------------------------------
-- Table [dbo].[OwnerLocals]
-- -----------------------------------------------------
CREATE TABLE [dbo].[OwnerLocals] (
  [OwnerLocalID] INT NOT NULL IDENTITY,
  [OwnerID] INT NOT NULL,
  [Name] VARCHAR(100) NOT NULL,
  [Address] VARCHAR(80) NOT NULL,
  [ZipCode] VARCHAR(15) NOT NULL,
  [GPS] VARCHAR(25) NULL,
  [CountryID] INT NOT NULL,
  [CityID] INT NOT NULL,
  [Main] BIT NULL,
  PRIMARY KEY ([OwnerLocalID]),
  CONSTRAINT [fk_OwnerLocals_Owners]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Owners] ([OwnerID]),
  CONSTRAINT [fk_OwnerLocals_Countries]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries] ([CountryID]),
  CONSTRAINT [fk_OwnerLocals_Cities]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities] ([CityID]))


-- -----------------------------------------------------
-- Table [dbo].[Animals]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Animals] (
  [AnimalID] INT NOT NULL IDENTITY,
  [OwnerLocalID] INT NOT NULL,
  [Name] VARCHAR(100) NOT NULL,
  [IdentityNumber] VARCHAR(50) NOT NULL,
  [Quantity] INT NOT NULL,
  [AnimalRaceID] INT NULL,
  [AnimalConditionID] INT NULL,
  [AnimalHabitatID] INT NULL,
  [DateBorn] DATETIME NULL,
  [DateDeath] DATETIME NULL,
  [Sex] SMALLINT NULL,
  PRIMARY KEY ([AnimalID]),
  CONSTRAINT [fk_Animals_AnimalRaces]
    FOREIGN KEY ([AnimalRaceID])
    REFERENCES [dbo].[AnimalRaces] ([AnimalRaceID]),
  CONSTRAINT [fk_Animals_AnimalConditions]
    FOREIGN KEY ([AnimalConditionID])
    REFERENCES [dbo].[AnimalConditions] ([AnimalConditionID]),
  CONSTRAINT [fk_Animals_AnimalHabitats]
    FOREIGN KEY ([AnimalHabitatID])
    REFERENCES [dbo].[AnimalHabitats] ([AnimalHabitatID]),
  CONSTRAINT [fk_Animals_OwnerLocals]
    FOREIGN KEY ([OwnerLocalID])
    REFERENCES [dbo].[OwnerLocals] ([OwnerLocalID]),


-- -----------------------------------------------------
-- Table [dbo].[Clinics]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Clinics] (
  [ClinicID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(100) NOT NULL,
  [KinD] SMALLINT NOT NULL,
  [Address] VARCHAR(80) NOT NULL,
  [ZipCode] VARCHAR(15) NOT NULL,
  [GPS] VARCHAR(25) NULL,
  [CityID] INT NOT NULL,
  [PhoneNumber] VARCHAR(25) NULL,
  [FaxNumber] VARCHAR(25) NULL,
  [Email]VARCHAR(80) NULL,
  PRIMARY KEY ([ClinicID]),
  CONSTRAINT [fk_Clinics_Cities]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities] ([CityID]))


-- -----------------------------------------------------
-- Table [dbo].[Professionals]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Professionals] (
  [ProfessionalID] INT NOT NULL IDENTITY,
  [UserID] UNIQUEIDENTIFIER NOT NULL,
  [Name] VARCHAR(100) NOT NULL,
  [CodeWorker] VARCHAR(25) NULL,
  [WorkNumber] VARCHAR(20) NULL,
  [PersonalNumber] VARCHAR(20) NULL,
  PRIMARY KEY ([ProfessionalID]),
  CONSTRAINT [fk_Professionals_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users] ([UserId]))


-- -----------------------------------------------------
-- Table [dbo].[ServiceKinds]
-- -----------------------------------------------------
CREATE TABLE [dbo].[ServiceKinds] (
  [ServiceKindID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(60) NOT NULL,
  PRIMARY KEY ([ServiceKindID]))


-- -----------------------------------------------------
-- Table [dbo].[Services]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Services] (
  [ServiceID] INT NOT NULL IDENTITY,
  [OwnerID] INT NOT NULL,
  [Name] VARCHAR(40) NOT NULL,
  [Description] VARCHAR(100) NULL,
  [DateService] DATETIME NULL,
  [DateConclusion] DATETIME NULL,
  [DateCreated] DATETIME NOT NULL,
  [Observation] VARCHAR(150) NULL,
  [ServiceKindID] INT NOT NULL,
  [AnimalID] INT NULL,
  [ProfessionalID] INT NOT NULL,
  [ClinicID] INT NULL,
  PRIMARY KEY ([ServiceID]),
  CONSTRAINT [fk_Services_Owners]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Owners] ([OwnerID]),
  CONSTRAINT [fk_Services_ServiceKinds]
    FOREIGN KEY ([ServiceKindID])
    REFERENCES [dbo].[ServiceKinds] ([ServiceKindID]),
  CONSTRAINT [fk_Services_Animals]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals] ([AnimalID]),
  CONSTRAINT [fk_Services_Professionals]
    FOREIGN KEY ([ProfessionalID])
    REFERENCES [dbo].[Professionals] ([ProfessionalID]),
  CONSTRAINT [fk_Services_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics] ([ClinicID]))


-- -----------------------------------------------------
-- Table [dbo].[Schedule]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Schedule] (
  [ScheduleID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(50) NULL,
  [DateEvent] DATETIME NOT NULL,
  [Notified] BIT NULL,
  [Present] BIT NULL,
  [DateCreated] DATETIME NOT NULL,
  [CreatedBy] UNIQUEIDENTIFIER NOT NULL,
  [ServiceKindID] INT NOT NULL,
  [OwnerID] INT NOT NULL,
  [AnimalID] INT NULL,
  [ProfessionalID] INT NOT NULL,
  [Priority] SMALLINT NULL,
  [State] SMALLINT NULL,
  PRIMARY KEY ([ScheduleID]),
  CONSTRAINT [fk_Schedule_ServiceKinds]
    FOREIGN KEY ([ServiceKindID])
    REFERENCES [dbo].[ServiceKinds] ([ServiceKindID]),
  CONSTRAINT [fk_Schedule_Owners]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Owners] ([OwnerID]),
  CONSTRAINT [fk_Schedule_Animals]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals] ([AnimalID]),
  CONSTRAINT [fk_Schedule_Professionals]
    FOREIGN KEY ([ProfessionalID])
    REFERENCES [dbo].[Professionals] ([ProfessionalID]),
  CONSTRAINT [fk_Schedule_Users]
    FOREIGN KEY ([CreatedBy])
    REFERENCES [dbo].[Users] ([UserId]))


-- -----------------------------------------------------
-- Table [dbo].[AppointmentTypes]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AppointmentTypes] (
  [AppointmentTypeID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(60) NOT NULL,
  PRIMARY KEY ([AppointmentTypeID]))


-- -----------------------------------------------------
-- Table [dbo].[Appointments]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Appointments] (
  [AppointmentID] INT NOT NULL IDENTITY,
  [OwnerID] INT NOT NULL,
  [AnimalID] INT NULL,
  [AppointmentTypeID] INT NOT NULL,
  [DateAppointment] DATETIME NOT NULL,
  [DateCreated] DATETIME NOT NULL,
  [Reason] VARCHAR(45) NULL,
  [Detail] VARCHAR(45) NULL,
  [Urgent] BIT NULL,
  [State] SMALLINT NULL,
  PRIMARY KEY ([AppointmentID]),
  CONSTRAINT [fk_Appointments_Owners]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Owners] ([OwnerID]),
  CONSTRAINT [fk_Appointments_AppointmentTypes]
    FOREIGN KEY ([AppointmentTypeID])
    REFERENCES [dbo].[AppointmentTypes] ([AppointmentTypeID]),
  CONSTRAINT [fk_Appointments_Animals]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals] ([AnimalID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalDiaryTypes]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalDiaryTypes] (
  [AnimalDiaryTypeID] INT NOT NULL IDENTITY,
  [Description] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([AnimalDiaryTypeID]))


-- -----------------------------------------------------
-- Table [dbo].[AnimalDiary]
-- -----------------------------------------------------
CREATE TABLE [dbo].[AnimalDiary] (
  [AnimalDiaryID] INT NOT NULL IDENTITY,
  [AnimalID] INT NOT NULL,
  [AnimalDiaryTypeID] INT NOT NULL,
  [DateDiaryStart] DATETIME NOT NULL,
  [DateDiaryEnd] DATETIME NULL,
  [DateCreated] DATETIME NOT NULL,
  [Value] DECIMAL(18,9) NOT NULL,
  [Observation] VARCHAR(45) NULL,
  [ServiceID] INT NULL,
  PRIMARY KEY ([AnimalDiaryID]),
  CONSTRAINT [fk_AnimalDiary_AnimalDiaryTypes]
    FOREIGN KEY ([AnimalDiaryTypeID])
    REFERENCES [dbo].[AnimalDiaryTypes] ([AnimalDiaryTypeID]),
  CONSTRAINT [fk_AnimalDiary_Animals]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals] ([AnimalID]),
  CONSTRAINT [fk_AnimalDiary_Services]
    FOREIGN KEY ([ServiceID])
    REFERENCES [dbo].[Services] ([ServiceID]))


-- -----------------------------------------------------
-- Table [dbo].[Expertises]
-- -----------------------------------------------------
CREATE TABLE [dbo].[Expertises] (
  [ExpertiseID] INT NOT NULL IDENTITY,
  [Name] VARCHAR(120) NOT NULL,
  PRIMARY KEY ([ExpertiseID]))


-- -----------------------------------------------------
-- Table [dbo].[ExpertiseProfessionalsRelation]
-- -----------------------------------------------------
CREATE TABLE [dbo].[ExpertiseProfessionalsRelation] (
  [ExpertiseID] INT NOT NULL,
  [ProfessionalID] INT NOT NULL,
  PRIMARY KEY ([ExpertiseID], [ProfessionalID]),
  CONSTRAINT [fk_ExpertiseProfessionalsRelation_Expertise]
    FOREIGN KEY ([ExpertiseID])
    REFERENCES [dbo].[Expertises] ([ExpertiseID]),
  CONSTRAINT [fk_ExpertiseProfessionalsRelation_Professionals]
    FOREIGN KEY ([ProfessionalID])
    REFERENCES [dbo].[Professionals] ([ProfessionalID]))


-- -----------------------------------------------------
-- Table [dbo].[ClinicProfessionalsRelation]
-- -----------------------------------------------------
CREATE TABLE [dbo].[ClinicProfessionalsRelation] (
  [ClinicID] INT NOT NULL,
  [ProfessionalID] INT NOT NULL,
  PRIMARY KEY ([ClinicID], [ProfessionalID]),
  CONSTRAINT [fk_ClinicProfessionalsRelation_Clinics]
    FOREIGN KEY ([ClinicID])
    REFERENCES [dbo].[Clinics] ([ClinicID]),
  CONSTRAINT [fk_ClinicProfessionalsRelation_Professionals]
    FOREIGN KEY ([ProfessionalID])
    REFERENCES [dbo].[Professionals] ([ProfessionalID]))



-- -----------------------------------------------------
-- Table [dbo].[OwnerAnimalsRelation]
-- -----------------------------------------------------
CREATE TABLE [dbo].[OwnerAnimalsRelation] (
  [OwnerID] INT NOT NULL,
  [AnimalID] INT NOT NULL,
  [Active] BIT NULL,
  PRIMARY KEY ([OwnerID], [AnimalID]),
  CONSTRAINT [fk_Owners_has_Animals_Owners1]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Owners] ([OwnerID]),
  CONSTRAINT [fk_Owners_has_Animals_Animals1]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals] ([AnimalID]))