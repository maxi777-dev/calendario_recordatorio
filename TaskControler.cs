using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder_desktop_application
{
    public class TaskControler : IControler<Task>
    {
        IStreamer<string, List<Task>> dataStreamer;
        IControler<Task> Controler;
        Dictionary<string, List<Task>> tasksForEachDay = new Dictionary<string, List<Task>>();
        List<Task> dailyTasks = new List<Task>();
        List<Task> weekedTasks = new List<Task>();
        List<Task> monthTasks = new List<Task>();
        List<string> tasksDays = new List<string>();

        public TaskControler(IStreamer<string, List<Task>> streamer, IControler<Task> controler)
        {
            dataStreamer = streamer;
            Controler = controler;
        }

        public delegate void NewTaskAppearedHandler(Task task);
        public event NewTaskAppearedHandler TaskAppeared;

        public Dictionary<string, List<Task>> AllTasks { get { return tasksForEachDay; } }
        public List<string> AllDays { get { return tasksDays; } }
        public List<Task> DailyTasks { get { return dailyTasks; } }
        public List<Task> WeekedTasks { get { return weekedTasks; } }
        public List<Task> MonthTasks { get { return monthTasks; } }

        public void Add(Task task)
        {
            if (TaskAppeared != null)
            {
                switch (task.isDWMf)
                {
                    case 0:
                        {
                            string key = task.StartingDate.ToShortDateString();
                            if (!tasksForEachDay.Keys.Contains<string>(key))
                            {
                                tasksForEachDay[key] = new List<Task>();
                                tasksDays.Add(key);
                            }
                            tasksForEachDay[key].Add(task);
                            break;
                        }
                    case 1:
                        {
                            dailyTasks.Add(task);
                            break;
                        }
                    case 2:
                        {
                            weekedTasks.Add(task);
                            break;
                        }
                    default:
                        monthTasks.Add(task);
                        break;
                }
                Controler.Add(task);
                TaskAppeared(task);                
            }
        }

        public void Remove(Task task)
        {
            try
            {
                switch (task.isDWMf)
                {
                    case 0:
                        {
                            string key = task.StartingDate.ToShortDateString();
                            tasksForEachDay[key].Remove(task);
                            break;
                        }
                    case 1:
                        dailyTasks.Remove(task);
                        break;
                    case 2:
                        weekedTasks.Remove(task);
                        break;
                    default:
                        monthTasks.Remove(task);
                        break;
                }
                Controler.Remove(task);
            }
            catch(Exception e)
            {
                throw new RemoveTaskException(e.ToString(), e);
            }
        }

        public void Stop()
        {
            System.Threading.Tasks.Task savingTask = new System.Threading.Tasks.Task(
                () => {
                    dataStreamer.SaveData(tasksForEachDay);
                    dataStreamer.SaveData(dailyTasks);
                    dataStreamer.SaveData(weekedTasks);
                    dataStreamer.SaveData(monthTasks);
                });
            savingTask.Start();
            Controler.Stop();
            System.Threading.Tasks.Task.WaitAll(savingTask);
        }

        public void LoadTasks()
        {
            string[] lines = dataStreamer.GetData();
            string[] words;
            foreach(string line in lines)
            {
                words = line.Split(',').ToArray<string>();
                this.Add(new Task(words[2], Convert.ToDateTime(words[0]), TimeSpan.Parse(words[1]), Convert.ToByte(words[3])));
            }
        }
    }
}
