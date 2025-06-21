namespace Bank.WebApi.Models
{
    /// <summary>
    /// Representa una cuenta bancaria con funcionalidades básicas de débito y crédito.
    /// </summary>
    /// <remarks>
    /// Esta clase proporciona operaciones fundamentales para el manejo de cuentas bancarias,
    /// incluyendo validaciones para prevenir operaciones inválidas como débitos que excedan el saldo
    /// o montos negativos.
    /// </remarks>
    public class BankAccount
    {
        /// <summary>
        /// Nombre del cliente propietario de la cuenta.
        /// </summary>
        private readonly string m_customerName = string.Empty;
        
        /// <summary>
        /// Saldo actual de la cuenta bancaria.
        /// </summary>
        private double m_balance;
        
        /// <summary>
        /// Constructor privado por defecto.
        /// </summary>
        private BankAccount() { }
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase BankAccount.
        /// </summary>
        /// <param name="customerName">El nombre del cliente propietario de la cuenta.</param>
        /// <param name="balance">El saldo inicial de la cuenta.</param>
        /// <example>
        /// <code>
        /// BankAccount account = new BankAccount("Juan Pérez", 1000.0);
        /// </code>
        /// </example>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        
        /// <summary>
        /// Obtiene el nombre del cliente propietario de la cuenta.
        /// </summary>
        /// <value>El nombre del cliente como una cadena de texto.</value>
        public string CustomerName { get { return m_customerName; } }
        
        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        /// <value>El saldo actual como un número de punto flotante.</value>
        public double Balance { get { return m_balance; }  }
        
        /// <summary>
        /// Realiza un débito (retiro) de la cuenta bancaria.
        /// </summary>
        /// <param name="amount">La cantidad a debitar de la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el monto es mayor que el saldo disponible o cuando el monto es negativo.
        /// </exception>
        /// <example>
        /// <code>
        /// BankAccount account = new BankAccount("Juan Pérez", 1000.0);
        /// account.Debit(250.0); // Saldo resultante: 750.0
        /// </code>
        /// </example>
        public void Debit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, m_balance);
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            m_balance -= amount;
        }

        /// <summary>
        /// Realiza un crédito (depósito) a la cuenta bancaria.
        /// </summary>
        /// <param name="amount">La cantidad a acreditar a la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el monto es negativo.
        /// </exception>
        /// <example>
        /// <code>
        /// BankAccount account = new BankAccount("Juan Pérez", 1000.0);
        /// account.Credit(500.0); // Saldo resultante: 1500.0
        /// </code>
        /// </example>
        public void Credit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            m_balance += amount;
        }
    }
}