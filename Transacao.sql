CREATE DATABASE sqlapistreamfriends;
GO 
	use Transacao
	GO
		CREATE TABLE Transacao (
			id INT PRIMARY KEY IDENTITY (1, 1),
			codigoTransacao VARCHAR (50) NOT NULL,
			descricaoTransacao VARCHAR (50) NOT NULL,
			endPoint VARCHAR (50) NOT NULL,
			enderecoFila VARCHAR (50) NOT NULL,
			topicoFila VARCHAR (50) NOT NULL,
			status bit NOT NULL
		)
		GO