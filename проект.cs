using System;
using System.Collections.Generic;

enum TaskType
{
    Руководство,
    Системщики,
    Разработчики
}

class Task
{
    public string Name;
    public TaskType Type;

    public Task(string name, TaskType type)
    {
        Name = name;
        Type = type;
    }
}

class Worker
{
    public string Name;
    public TaskType Type;

    private List<Worker> managers = new List<Worker>();

    public Worker(string name, TaskType type)
    {
        Name = name;
        Type = type;
    }

    public void AddManager(Worker manager)
    {
        managers.Add(manager);
    }

    public bool CanAcceptTask(Worker sender, Task task)
    {
        return managers.Contains(sender) && Type == task.Type;
    }

    public void GiveTask(Worker receiver, Task task)
    {
        Console.WriteLine("От человека " + Name + " даётся задача " + task.Name + " человеку " + receiver.Name);

        if (receiver.CanAcceptTask(this, task))
        {
            Console.WriteLine("Человек берёт задачу");
        }
        else
        {
            Console.WriteLine("Человек не берёт задачу");
        }
    }
}

class Program
{
    static void Main()
    {
        // Руководство
        Worker timur = new Worker("Тимур", TaskType.Руководство);
        Worker rashid = new Worker("Рашид", TaskType.Руководство);
        Worker ilham = new Worker("О Ильхам", TaskType.Руководство);
        Worker lukas = new Worker("Лукас", TaskType.Руководство);

        // Начальство IT
        Worker orkadiy = new Worker("Оркадий", TaskType.Руководство);
        Worker volodya = new Worker("Володя", TaskType.Руководство);

        // Системщики
        Worker ilshat = new Worker("Ильшат", TaskType.Системщики);
        Worker ivanych = new Worker("Иваныч", TaskType.Системщики);
        Worker ilya = new Worker("Илья", TaskType.Системщики);
        Worker vitya = new Worker("Витя", TaskType.Системщики);
        Worker zhenya = new Worker("Женя", TaskType.Системщики);

        // Разработчики
        Worker sergey = new Worker("Сергей", TaskType.Разработчики);
        Worker laysan = new Worker("Ляйсан", TaskType.Разработчики);
        Worker marat = new Worker("Марат", TaskType.Разработчики);
        Worker dina = new Worker("Дина", TaskType.Разработчики);
        Worker ildar = new Worker("Ильдар", TaskType.Разработчики);
        Worker anton = new Worker("Антон", TaskType.Разработчики);

        rashid.AddManager(timur);
        ilham.AddManager(timur);

        lukas.AddManager(rashid);

        orkadiy.AddManager(ilham);
        volodya.AddManager(ilham);

        ilshat.AddManager(orkadiy);
        ilshat.AddManager(volodya);

        ivanych.AddManager(ilshat);
        ilya.AddManager(ivanych);
        vitya.AddManager(ivanych);
        zhenya.AddManager(ivanych);

        sergey.AddManager(orkadiy);
        sergey.AddManager(volodya);

        laysan.AddManager(sergey);
        marat.AddManager(laysan);
        dina.AddManager(laysan);
        ildar.AddManager(laysan);
        anton.AddManager(laysan);

        Task task1 = new Task("настроить сеть", TaskType.Системщики);
        Task task2 = new Task("написать программу", TaskType.Разработчики);
        Task task3 = new Task("проверить сервер", TaskType.Системщики);
        Task task4 = new Task("ничего не делать", TaskType.Руководство);

        orkadiy.GiveTask(ilshat, task1);
        volodya.GiveTask(sergey, task3);
        sergey.GiveTask(laysan, task2);
        laysan.GiveTask(dina, task2);
        dina.GiveTask(marat, task2);
        ilham.GiveTask(sergey, task4);
        ivanych.GiveTask(ilya, task1);
        timur.GiveTask(dina, task3);
        ilham.GiveTask(orkadiy, task4);
    }
}