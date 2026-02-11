using System;
using System.Collections.Generic;
using Xunit;
using re;
using System.Linq;
using System.Threading.Tasks;

public class TaskManagerXUnitTests
{
    // Тест 1: Создание задачи с корректными данными
    [Fact]
    public void Test1()
    {
        var task = new Tsk
        {
            Name = "Test Task",
            Description = "Test Description",
            DueDate = DateTime.Now.AddDays(7),
            IsCompleted = false
        };

        Assert.NotNull(task);
        Assert.Equal("Test Task", task.Name);
        Assert.Equal("Test Description", task.Description);
        Assert.False(task.IsCompleted);
    }

    // Тест 2: Добавление задачи в список
    [Fact]
    public void Test2()
    {
        var tsks = new List<Tsk>();  
        var newTsk = new Tsk
        {
            Name = "New Task",
            Description = "Task Description",
            DueDate = DateTime.Now.AddDays(10)
        };


        tsks.Add(newTsk);


        Assert.Single(tsks);
        Assert.Contains(newTsk, tsks);
    }

    // Тест 3: Обновление существующей задачи
    [Fact]
    public void Test3()
    {

        var task = new Tsk
        {
            Name = "Original Task",
            Description = "Original Description",
            DueDate = DateTime.Now.AddDays(5)
        };


        task.Name = "Updated Task";
        task.Description = "Updated Description";
        task.DueDate = DateTime.Now.AddDays(15);


        Assert.Equal("Updated Task", task.Name);
        Assert.Equal("Updated Description", task.Description);
    }

    // Тест 4: Проверка завершения задачи
    [Fact]
    public void Test4()
    {

        var task = new Tsk
        {
            Name = "Incomplete Task",
            IsCompleted = false
        };


        task.IsCompleted = true;


        Assert.True(task.IsCompleted);
    }

    // Тест 5: Удаление задачи из списка
    [Fact]
    public void Test5()
    {

        var tsks = new List<Tsk>  
    {
        new Tsk { Name = "Task 1" },
        new Tsk { Name = "Task 2" }
    };


        tsks.RemoveAt(0);


        Assert.Single(tsks);
        Assert.DoesNotContain("Task 1", tsks.Select(t => t.Name));
    }

    // Функциональный тест
    [Fact]
    public void TestFunc()
    {

        var tsks = new List<Tsk>();  


        var newTsk = new Tsk
        {
            Name = "Complete Project",
            Description = "Finish software development",
            DueDate = DateTime.Now.AddDays(30)
        };
        tsks.Add(newTsk);


        newTsk.Description = "Finalize project documentation";


        newTsk.IsCompleted = true;


        Assert.Single(tsks);
        Assert.True(newTsk.IsCompleted);
        Assert.Equal("Finalize project documentation", newTsk.Description);
    }
}
