using System;

enum Type
{
    Текущий,
    Сберегательный
}

class BankAccount
{
    private static int count = 10000;

    private int number;
    private int balance;
    private Type type;

    public int Number
    {
        get { return number; }
    }

    public int Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
                balance = value;
        }
    }

    public Type AccountType
    {
        get { return type; }
        set { type = value; }
    }

    public BankAccount()
    {
        count++;
        number = count;
        balance = 0;
    }

    public void Print()
    {
        Console.WriteLine("Номер счёта: " + number);
        Console.WriteLine("Баланс: " + balance);
        Console.WriteLine("Тип счёта: " + type);
    }

    public void Transfer(BankAccount account, int sum)
    {
        if (sum <= 0)
        {
            Console.WriteLine("Неверная сумма");
            return;
        }

        if (account.balance < sum)
        {
            Console.WriteLine("Недостаточно средств");
            return;
        }

        account.balance -= sum;
        balance += sum;

        Console.WriteLine("Перевод выполнен успешно");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount();
        BankAccount account2 = new BankAccount();

        account1.Balance = 10000;
        account2.Balance = 5000;

        Console.WriteLine("До перевода:");
        account1.Print();
        account2.Print();

        Console.WriteLine("Введите сумму перевода:");
        int sum = int.Parse(Console.ReadLine());

        account2.Transfer(account1, sum);

        Console.WriteLine("После перевода:");
        account1.Print();
        account2.Print();
    }
}
