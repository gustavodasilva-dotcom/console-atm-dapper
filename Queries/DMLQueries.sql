USE ATM
GO

-- Queries utilizadas para testagem da aplicação.

INSERT INTO Client
VALUES
(
	'2b7bd79e-c424-4479-865d-23c3ce6bf203',
	'First Name',
	'Middle Name',
	'Last Name',
	'12345678910'
);

INSERT INTO Contacts
VALUES
(
	'82362ef3-c709-4861-808d-8374d783f403',
	'email@email.com',
	'11912345678',
	'2b7bd79e-c424-4479-865d-23c3ce6bf203'
);

INSERT INTO Address
VALUES
(
	'41b657dd-99bb-4690-8250-afd8c8995e44',
	'1234 Address',
	'City',
	'St',
	'Country',
	'12345678',
	'2b7bd79e-c424-4479-865d-23c3ce6bf203'
);

-- Selecionando as informações de cadastro do cliente.
SELECT		*
FROM		Client		AS CL
INNER JOIN	Contacts	AS CT ON CL.ClientId = CT.ClientId
INNER JOIN	Address		AS AD ON CL.ClientId = AD.ClientId


INSERT INTO CheckingAccount
VALUES
(
	'85735971-7ffe-45e7-94fd-55ce095a2ce5',
	100001,
	0,
	123456,
	'2b7bd79e-c424-4479-865d-23c3ce6bf203'
);


-- Selecionando nome, saldo e o nome do cliente, através da senha.
SELECT		Number, Balance, FirstName, LastName
FROM		CheckingAccount		AS CA
INNER JOIN	Client				AS CL ON CA.ClientId = CL.ClientId
WHERE		CA.Password = 123456


-- Selecionando nome, saldo e o nome do cliente, através do número da conta.
SELECT		Number, Balance, FirstName, LastName
FROM		CheckingAccount		AS CA
INNER JOIN	Client				AS CL ON CA.ClientId = CL.ClientId
WHERE		CA.Number = 100001


-- Inserindo, na tabela Operations, as duas operações permitidas.
INSERT INTO Operations VALUES ('Deposit');
INSERT INTO Operations VALUES ('Take out');