using Quartz;
using Quartz.Impl;
using System;

namespace Reminder_desktop_application
{
    public class NotificationControler : IControler<Task>
    {
        ISchedulerFactory schedulerFactor = new StdSchedulerFactory();
        IScheduler scheduler;

        public NotificationControler()
        {
            scheduler = schedulerFactor.GetScheduler();
            scheduler.Start();
        }

        public void Add(Task task)
        {
            if (task.NotificationTime >= DateTime.Now)
            {
                switch (task.isDWMf)
                {
                    case 0:
                        {
                            IJobDetail taskToNotify = JobBuilder.Create<Notification>().WithIdentity(task.NotificationTime.ToString()).Build();
                            taskToNotify.JobDataMap["Task"] = task;
                            ITrigger trigger = TriggerBuilder.Create().StartAt(task.NotificationTime).Build();
                            scheduler.ScheduleJob(taskToNotify, trigger);
                            break;
                        }
                    case 1:
                        {
                            IJobDetail taskToNotify = JobBuilder.Create<Notification>().WithIdentity(task.NotificationTime.ToString()).Build();
                            taskToNotify.JobDataMap["Task"] = task;
                            ITrigger trigger = TriggerBuilder.Create()
                                .WithDailyTimeIntervalSchedule
                                (s =>
                                    s.WithIntervalInHours(24)
                                    .OnEveryDay()
                                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(task.StartingTime.Hours, task.StartingTime.Minutes)))
                                    .Build();
                            scheduler.ScheduleJob(taskToNotify, trigger);
                            break;
                        }
                    case 2:
                        {
                            IJobDetail taskToNotify = JobBuilder.Create<Notification>().WithIdentity(task.NotificationTime.ToString()).Build();
                            taskToNotify.JobDataMap["Task"] = task;
                            ITrigger trigger = TriggerBuilder.Create()
                                .WithSchedule(CronScheduleBuilder
                                    .WeeklyOnDayAndHourAndMinute(task.StartingDate.DayOfWeek, task.StartingTime.Hours, task.StartingTime.Minutes))
                                    .Build();
                            scheduler.ScheduleJob(taskToNotify, trigger);
                            break;
                        }
                    default:
                        {
                            IJobDetail taskToNotify = JobBuilder.Create<Notification>().WithIdentity(task.NotificationTime.ToString()).Build();
                            taskToNotify.JobDataMap["Task"] = task;
                            string asd = "0 " + task.StartingTime.Minutes + " " +  task.StartingTime.Hours + " " + task.StartingDate.Day + " * ?";
                            ITrigger trigger = TriggerBuilder.Create()
                                .WithCronSchedule("0 " + task.StartingTime.Minutes + " " + task.StartingTime.Hours + " " + task.StartingDate.Day + " * ?")
                                .Build();
                            scheduler.ScheduleJob(taskToNotify, trigger);
                            break;
                        }
                }
            }
        }

        public void Remove(Task task)
        {
            scheduler.DeleteJob(task.JobKey);
        }

        public void Stop()
        {
            scheduler.Shutdown();
        }
    }
}
