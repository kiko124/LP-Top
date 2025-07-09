using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._4
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public string Owner { get; }
        private readonly List<string> _transactionHistory = new List<string>();

        public BankAccount(string owner, decimal initialBalance = 0)
        {
            Owner = owner;
            Balance = initialBalance;
            AddTransaction("Initial balance", initialBalance);
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");

            Balance += amount;
            AddTransaction("Deposit", amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
            AddTransaction("Withdrawal", -amount);
        }

        private void AddTransaction(string operation, decimal amount)
        {
            _transactionHistory.Add($"{DateTime.Now:yyyy-MM-dd HH:mm}: {operation} {Math.Abs(amount):C}. New balance: {Balance:C}");
        }

        public void DisplayHistory()
        {
            Console.WriteLine($"\nИстория операций для {Owner}:");
            foreach (var transaction in _transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }


    public class DepositCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly decimal _amount;

        public DepositCommand(BankAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Deposit(_amount);

        public void Undo() => _account.Withdraw(_amount);
    }

    public class WithdrawCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly decimal _amount;

        public WithdrawCommand(BankAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Withdraw(_amount);

        public void Undo() => _account.Deposit(_amount);
    }


    public class TransactionManager
    {
        private readonly BankAccount _account;
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public TransactionManager(BankAccount account)
        {
            _account = account;
        }

        public void Deposit(decimal amount)
        {
            var command = new DepositCommand(_account, amount);
            ExecuteCommand(command);
        }

        public void Withdraw(decimal amount)
        {
            var command = new WithdrawCommand(_account, amount);
            ExecuteCommand(command);
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
            _redoStack.Clear(); 
        }

        public void UndoLast()
        {
            if (_commandHistory.Count == 0)
            {
                Console.WriteLine("Нет операций для отмены");
                return;
            }

            var command = _commandHistory.Pop();
            command.Undo();
            _redoStack.Push(command);
        }

        public void RedoLast()
        {
            if (_redoStack.Count == 0)
            {
                Console.WriteLine("Нет операций для повтора");
                return;
            }

            var command = _redoStack.Pop();
            command.Execute();
            _commandHistory.Push(command);
        }

        public void ShowHistory() => _account.DisplayHistory();

        public void ShowBalance() => Console.WriteLine($"\nТекущий баланс: {_account.Balance:C}");
    }

    class CommandExample
    {
        static void Main()
        {
            var account = new BankAccount("Иван Иванов", 1000);
            var manager = new TransactionManager(account);

 
            manager.ShowBalance();
            manager.Deposit(500);
            manager.Withdraw(200);
            manager.Deposit(300);

    
            manager.ShowHistory();
            manager.ShowBalance();

           
            Console.WriteLine("\nОтменяем последнюю операцию:");
            manager.UndoLast();
            manager.ShowBalance();

            Console.WriteLine("\nОтменяем еще одну операцию:");
            manager.UndoLast();
            manager.ShowBalance();

            Console.WriteLine("\nПовторяем операцию:");
            manager.RedoLast();
            manager.ShowBalance();

           
            manager.ShowHistory();
        }
    }
}
