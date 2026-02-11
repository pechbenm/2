using System;
using System.Collections.Generic;
using NUnit.Framework;
using re;

[TestFixture]
public class TaskManagerNUnitTests
{
    // Тест 1: Проверка создания задачи с граничными значениями
    [Test]
    [TestCase("", "пустое название")]
    [TestCase("Длинное название задачи с более чем 15 символов", "длинное имя")]
    public void Test1(string name, string description)
    {
        var task = new Tsk
        {
            Name = name,
            Description = description,
            DueDate = DateTime.Now.AddDays(1)
        };

        Assert.IsNotNull(task);
        Assert.AreEqual(name, task.Name);
    }

    // Тест 2: Проверка валидности даты задачи
    [Test]
    public void Test2()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var task = new Tsk
            {
                Name = "Past Due Task",
                DueDate = DateTime.Now.AddDays(-1)
            };
        });
    }

    // Тест 3: Сравнение задач
    [Test]
    public void Test3()
    {
        // Arrange
        var task1 = new Tsk
        {
            Name = "Task",
            Description = "Description",
            DueDate = DateTime.Now.AddDays(10)
        };

        var task2 = new Tsk
        {
            Name = "Task",
            Description = "Description",
            DueDate = task1.DueDate
        };

        Assert.AreEqual(task1.Name, task2.Name);
        Assert.AreEqual(task1.Description, task2.Description);
        Assert.AreEqual(task1.DueDate, task2.DueDate);
    }

    // Тест 4: Проверка статуса задачи
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Test4(bool initialStatus)
    {
        var task = new Tsk
        {
            Name = "Status Test Task",
            IsCompleted = initialStatus
        };

        task.IsCompleted = !initialStatus;

        Assert.AreNotEqual(initialStatus, task.IsCompleted);
    }

    // Тест 5: Проверка максимального количества символов в описании
    [Test]
    public void Test5()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var task = new Tsk
            {
                Name = "Long Description Task",
                Description = new string('A', 501) 
            };
        });
    }

    // Функциональный тест
    [Test]
    public void TestFunc()
    {
        var tsks = new List<Tsk>(); 

        var tsk = new Tsk
        {
            Name = "Project Milestone",
            Description = "Complete key deliverables",
            DueDate = DateTime.Now.AddDays(15)
        };
        tsks.Add(tsk); 

        tsk.IsCompleted = true;

        Assert.AreEqual(1, tsks.Count);
        Assert.IsTrue(tsk.IsCompleted);
        Assert.AreEqual("Project Milestone", tsk.Name);
    }
}
