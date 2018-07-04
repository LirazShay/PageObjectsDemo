using System.Linq;
using NUnit.Framework;

namespace TodoMVC.PageObjects.Tests
{
    [Parallelizable(ParallelScope.Children)]
    [TestFixture]
    public class TodosTests
    {
        [Test]
        public void AddTask()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();

                todosPage.AddTask("New task");

                var taskRow = todosPage.TodosList.Last();
                Assert.AreEqual("New task", taskRow.TaskText);
            }
        }

        [Test]
        public void EditTask()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("New Task");

                var newTask = todosPage.TodosList.First(a => a.TaskText == "New Task");
                newTask.EditTask("New Name");

                Assert.AreEqual("New Name", newTask.TaskText);
            }
        }

        [Test]
        public void DeleteTask()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("New Task");

                var taskRow = todosPage.TodosList.First(a => a.TaskText == "New Task");
                taskRow.DeleteTask();

                Assert.AreEqual(0, todosPage.TodosList.Count);
            }
        }

        [Test]
        public void MarkTaskCompleted()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("New Task");

                var task = todosPage.FindTask("New Task");
                task.MarkCompleted();

                Assert.IsTrue(task.IsCompleted);
            }
        }

        [Test]
        public void MarkTaskActive()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("New Task");
                var task = todosPage.FindTask("New Task");
                task.MarkCompleted();

                task.MarkActive();

                Assert.IsFalse(task.IsCompleted);
            }
        }

        [Test]
        public void ClearCompletedTasks()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("New Task");
                todosPage.AddTask("New Task2");
                todosPage.FindTask("New Task").MarkCompleted();
                todosPage.FindTask("New Task2").MarkCompleted();

                todosPage.ClearAllCompletedTasks();

                Assert.AreEqual(0, todosPage.TodosList.Count);
            }
        }

        [Test]
        public void FilterAllTasksWillShowCompletedAndActiveTasks()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("Active");
                todosPage.AddTask("Completed");
                todosPage.FindTask("Completed").MarkCompleted();

                todosPage.SelectViewAll();
                var allTasks = todosPage.TodosList;

                Assert.AreEqual(2, todosPage.TodosList.Count);
                Assert.IsTrue(allTasks.Any(a => a.TaskText == "Completed"));
                Assert.IsTrue(allTasks.Any(a => a.TaskText == "Active"));
            }
        }

        [Test]
        public void FilterActiveTasksWillShowOnlyActiveTasks()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("Active");
                todosPage.AddTask("Completed");
                todosPage.FindTask("Completed").MarkCompleted();

                todosPage.SelectActiveTasksView();
                var allTasks = todosPage.TodosList;

                Assert.AreEqual(1, todosPage.TodosList.Count);
                Assert.IsTrue(allTasks.Any(a => a.TaskText == "Active"));
            }
        }


        [Test]
        public void FilterCompletedTasksWillShowOnlyCompletedTasks()
        {
            using (var testContext = new TodosTestContext())
            {
                var todosPage = testContext.GotoTodosPage();
                todosPage.AddTask("Active");
                todosPage.AddTask("Completed");
                todosPage.FindTask("Completed").MarkCompleted();

                todosPage.SelectCompletedTasksView();
                var allTasks = todosPage.TodosList;

                Assert.AreEqual(1, todosPage.TodosList.Count);
                Assert.IsTrue(allTasks.Any(a => a.TaskText == "Completed"));
            }
        }

    }
}