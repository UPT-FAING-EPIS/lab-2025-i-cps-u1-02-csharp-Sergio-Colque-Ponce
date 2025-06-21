using NUnit.Framework;
using Bank.WebApi.Models;

namespace Bank.WebApi.Tests
{
    /// <summary>
    /// Contiene las pruebas unitarias para la clase BankAccount.
    /// </summary>
    /// <remarks>
    /// Esta clase de pruebas verifica el comportamiento correcto de todas las operaciones
    /// de la clase BankAccount, incluyendo casos válidos e inválidos para débitos y créditos.
    /// </remarks>
    public class BankAccountTests
    {
        /// <summary>
        /// Verifica que el método Debit actualiza correctamente el saldo cuando se proporciona un monto válido.
        /// </summary>
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        /// <summary>
        /// Verifica que el método Debit lanza ArgumentOutOfRangeException cuando el monto es mayor que el saldo.
        /// </summary>
        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double debitAmount = 150.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        /// <summary>
        /// Verifica que el método Debit lanza ArgumentOutOfRangeException cuando el monto es negativo.
        /// </summary>
        [Test]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double debitAmount = -50.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        /// <summary>
        /// Verifica que el método Credit incrementa correctamente el saldo cuando se proporciona un monto positivo.
        /// </summary>
        [Test]
        public void Credit_WithPositiveAmount_IncreasesBalance()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = 25.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(125.0, account.Balance, 0.001, "Account not credited correctly");
        }

        /// <summary>
        /// Verifica que el método Credit lanza ArgumentOutOfRangeException cuando el monto es negativo.
        /// </summary>
        [Test]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = -10.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }
    }
}
