CREATE DATABASE ATM
GO

USE ATM
GO

CREATE TABLE Client
(
	ClientId	UNIQUEIDENTIFIER	NOT NULL,
	FirstName	VARCHAR(255)		NOT NULL,
	MiddleName	VARCHAR(255)		NOT NULL,
	LastName	VARCHAR(255)		NOT NULL,
	Cpf			VARCHAR(11)			NOT NULL

	CONSTRAINT PK_ClientId PRIMARY KEY(ClientId)
);

CREATE TABLE Contacts
(
	ContactsId	UNIQUEIDENTIFIER	NOT NULL,
	Email		VARCHAR(255)		NOT NULL,
	Phone		VARCHAR(11)			NOT NULL,
	ClientId	UNIQUEIDENTIFIER	NOT NULL

	CONSTRAINT PK_ContactsId PRIMARY KEY(ContactsId),

	CONSTRAINT FK_ContactsId_ClientId FOREIGN KEY(ClientId)
	REFERENCES Client(ClientId)
);

CREATE TABLE Address
(
	AddressId	UNIQUEIDENTIFIER	NOT NULL,
	Street		VARCHAR(255)		NOT NULL,
	City		VARCHAR(255)		NOT NULL,
	State		VARCHAR(2)			NOT NULL,
	Country		VARCHAR(255)		NOT NULL,
	ZipCode		VARCHAR(8)			NOT NULL,
	ClientId	UNIQUEIDENTIFIER	NOT NULL

	CONSTRAINT PK_Address PRIMARY KEY(AddressId),

	CONSTRAINT FK_AddressId_ClientId FOREIGN KEY(ClientId)
	REFERENCES Client(ClientId)
);

CREATE TABLE CheckingAccount
(
	CheckingAccountId	UNIQUEIDENTIFIER	NOT NULL,
	Number				INT					NOT NULL,
	Balance				FLOAT(2)			NOT NULL,
	Password			INT					NOT NULL,
	ClientId			UNIQUEIDENTIFIER	NOT NULL

	CONSTRAINT PK_CheckingAccountId PRIMARY KEY (CheckingAccountId)

	CONSTRAINT FK_CheckingAccountId_ClientId FOREIGN KEY(ClientId)
	REFERENCES Client(ClientId)
);

CREATE TABLE DebitCard
(
	DebitCardId			UNIQUEIDENTIFIER	NOT NULL,
	Number				VARCHAR(255)		NOT NULL,
	Expiration			VARCHAR(255)		NOT NULL,
	Cvvs				INT					NOT NULL,
	CardType			VARCHAR(255)		NOT NULL,
	CheckingAccountId	UNIQUEIDENTIFIER	NOT NULL

	CONSTRAINT PK_DebitCardId PRIMARY KEY(DebitCardId),

	CONSTRAINT FK_DebitCardId_CheckingAccountId FOREIGN KEY(CheckingAccountId)
	REFERENCES CheckingAccount(CheckingAccountId)
)

CREATE TABLE Operations
(
	OperationId			INT				NOT NULL	IDENTITY(1, 1),
	Description			VARCHAR(255)	NOT NULL	CHECK
	(
		Description		IN
		(
			'Deposit',
			'Take out'
		)
	)
	
	CONSTRAINT PK_OperationId PRIMARY KEY (OperationId)
)

CREATE TABLE OperationLogs
(
	OperationLogId		INT					NOT NULL	IDENTITY(1, 1),
	OperationId			INT					NOT NULL,
	CheckingAccountId	UNIQUEIDENTIFIER	NOT NULL,
	Description			VARCHAR(255)		NOT NULL,
	Date				DATE				NOT NULL

	CONSTRAINT PK_OperationLogId PRIMARY KEY(OperationLogId),

	CONSTRAINT FK_OperationLogId_OperationId FOREIGN KEY(OperationId)
	REFERENCES Operations(OperationId),

	CONSTRAINT Fk_OperationLogId_CheckingAccountId FOREIGN KEY(CheckingAccountId)
	REFERENCES CheckingAccount(CheckingAccountId)
)