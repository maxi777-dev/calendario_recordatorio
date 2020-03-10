using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Reminder_desktop_application
{
    public partial class Reminder : MetroFramework.Forms.MetroForm
    {
        /*  TODO:
         *  Lazy
         */

        public TaskControler taskControler = new TaskControler(new FileStreamer(), new NotificationControler());
        public List<Task> allDayTaks;
        public Dictionary<string, List<Task>> tasksForEeachDay;
        public Task taskToNotify;

        public Reminder()
        {
            InitializeComponent();
            taskControler.TaskAppeared += SubscribeForNotification;
            taskControler.LoadTasks();
            //PrintDayTasks(DateTime.Now.ToShortDateString());
            PrintDayTasks(DateTime.Now);
            this.ControlBox = false;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
        int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private void addLink_Click(object sender, EventArgs e)
        {
            Form NewTaskForm = new NewTaskForm(taskControler, reminderDateTime.Value);
            NewTaskForm.ShowDialog();
            reminderTabControl.SelectedTab = homeTab;
            //PrintDayTasks(reminderDateTime.Value.ToShortDateString());
            PrintDayTasks(reminderDateTime.Value);
        }

        private void deleteLink_Click(object sender, EventArgs e)
        {
            if (reminderTasksView.SelectedItems.Count == 1)
            {
                DialogResult result = MessageBox.Show("Está segurx?", "Eliminar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Task temp = (Task)reminderTasksView.SelectedItems[0].Tag;
                        taskControler.Remove(temp);
                        //PrintDayTasks(temp.StartingDate.ToShortDateString());
                        PrintDayTasks(temp.StartingDate);
                    }
                    catch(RemoveTaskException exp)
                    {
                        MessageBox.Show(exp.ToString());
                    }
                }
            }
        }

        private void doneLink_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Reminder_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se cerrará la agenda. Está segurx?", "Cerrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                taskControler.Stop();
                this.notificationIcon.Dispose();
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void ShootOutNotification(object sender, EventArgs e)
        {
            taskToNotify = (Task)sender;
            notificationIcon.BalloonTipTitle = this.Text;
            notificationIcon.BalloonTipText = taskToNotify.ReminderText;
            notificationIcon.ShowBalloonTip(5000);
        }
        private void notificationIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notificationIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            TaskNotification notificationForm = new TaskNotification(taskToNotify, taskControler);
            notificationForm.FormClosing += notificationForm_FormClosing;
            notificationForm.Show();
            notificationForm.WindowState = FormWindowState.Normal;
        }

        private void SubscribeForNotification(Task task)
        {
            task.TaskStarted += ShootOutNotification;
        }

        private void PrintDayTasks(DateTime date)
        {
            reminderTasksView.Items.Clear();
            if (taskControler.DailyTasks.Count != 0)
            {
                foreach (Task task in taskControler.DailyTasks)
                {
                    PrintingTheTask(task);
                }
            }
            if (taskControler.WeekedTasks.Count != 0)
            {
                foreach (Task task in taskControler.WeekedTasks)
                {
                    if (task.StartingDate.DayOfWeek==date.DayOfWeek)
                    {
                        PrintingTheTask(task);
                    }                    
                }
            }
            if (taskControler.MonthTasks.Count != 0)
            {
                foreach (Task task in taskControler.MonthTasks)
                {
                    if (task.StartingDate.Day==date.Day)
                    {
                        PrintingTheTask(task);
                    }                    
                }
            }
            if (taskControler.AllDays.Contains(date.ToShortDateString()))
            {
                allDayTaks = taskControler.AllTasks[date.ToShortDateString()];
                foreach (Task task in allDayTaks)
                {
                    if (task.StartingDate.Day == date.Day)
                    {
                        PrintingTheTask(task);
                    }                    
                }
            }
        }

        private void PrintingTheTask(Task task)
        {
            ListViewItem taskForList = new ListViewItem();
            taskForList.Text = task.StartingTime.ToString(@"hh\:mm");
            taskForList.SubItems.Add(task.ReminderText);
            taskForList.Tag = task;
            reminderTasksView.Items.Add(taskForList);
        }

        private void reminderDateTime_ValueChanged(object sender, EventArgs e)
        {
            PrintDayTasks(reminderDateTime.Value);
        }

        private void notificationForm_FormClosing(object sender, EventArgs e)
        {
            //PrintDayTasks(DateTime.Now.ToShortDateString());
            PrintDayTasks(DateTime.Now);
        }

        private void reminderDateTime_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("%{DOWN}");
        }

        private void Reminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            taskControler.Stop();
            this.notificationIcon.Dispose();
            Application.Exit();          
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
