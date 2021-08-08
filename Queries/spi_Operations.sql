USE ATM
GO

CREATE PROCEDURE [dbo].[spi_Operations]
	@OperationId	INT,
	@Number			INT,
	@Money			FLOAT(2)
AS
	BEGIN
/**************************************************************************************************************************************
-- Procedure utilizada opera��es de saque e dep�sito em conta. Ao final de ambas as opera��es, a rotina grava, na tabela OperationLogs,
-- a opera��o realizada pelo usu�rio.

-- Data de cria��o: 08/08/2021
**************************************************************************************************************************************/

		DECLARE @Msg				VARCHAR(255)
		DECLARE @CheckingAccountId	UNIQUEIDENTIFIER
		DECLARE @LogId				INT


		PRINT 'In�cio: '

		IF  @OperationId = 1
		BEGIN

			PRINT 'Opera��o: Dep�sito.'

			UPDATE CheckingAccount
			SET
				Balance =
				(
					SELECT	Balance
					FROM	CheckingAccount
					WHERE	Number = @Number
				) + @Money
			WHERE Number = @Number

			SET @Msg = 'Dep�sito de R$ ' + CAST(@Money AS VARCHAR) + ' realizado com sucesso.';

			PRINT @Msg


			SELECT	@CheckingAccountId = CheckingAccountId
			FROM	CheckingAccount
			WHERE	Number = @Number

			INSERT INTO OperationLogs
			VALUES
			(
				@OperationId,
				@CheckingAccountId,
				@Msg,
				GETDATE()
			)


			SELECT @LogId = OperationId FROM OperationLogs ORDER BY OperationId DESC

			PRINT 'Log n� ' + CAST(@LogId AS VARCHAR) + ' realizado com sucesso.'
		END


		IF @OperationId = 2
		BEGIN

			PRINT 'Opera��o: Saque'

			UPDATE CheckingAccount
			SET
				Balance =
				(
					SELECT	Balance
					FROM	CheckingAccount
					WHERE	Number = @Number
				) - @Money
			WHERE Number = @Number

			SET @Msg = 'Saque de R$ ' + CAST(@Money AS VARCHAR) + ' realizado com sucesso.';

			PRINT @Msg


			SELECT	@CheckingAccountId = CheckingAccountId
			FROM	CheckingAccount
			WHERE	Number = @Number

			INSERT INTO OperationLogs
			VALUES
			(
				@OperationId,
				@CheckingAccountId,
				@Msg,
				GETDATE()
			)


			SELECT @LogId = OperationId FROM OperationLogs ORDER BY OperationId DESC

			PRINT 'Log n� ' + CAST(@LogId AS VARCHAR) + ' realizado com sucesso.'
		END
		

		PRINT 'Fim.'

	END
GO