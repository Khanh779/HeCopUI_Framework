using System;
using System.Windows.Forms;
using TaskScheduler;

namespace HeCopUI_Framework
{
    internal class TaskShedulerService
    {
        public TaskShedulerService()
        {


        }

        public bool CheckTaskExist(string taskName)
        {
            TaskScheduler.ITaskService scheduler = new TaskScheduler.TaskScheduler();

            //Change first parameter to remote server if desired and add credentials
            scheduler.Connect();

            //Specify the path to the folder containing the task, could make this an extension method
            var folder = scheduler.GetFolder(@"\");
            var task = folder.GetTask(taskName);


            //Run the task, optionally pass parameters
            if (task != null)
                return true;
            else return false;
        }

        public void CreateSchedule(string taskName, string filePath, string description, string author, string arguments, string userName,
            string password)
        {
            ITaskService ts = new TaskScheduler.TaskScheduler();
            try
            {
                ts.Connect(null, null, null, null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error : " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ITaskDefinition td = ts.NewTask(0);
            td.RegistrationInfo.Author = author;
            td.RegistrationInfo.Description = description;

            //ITimeTrigger tt = (ITimeTrigger)td.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);  
            //tt.Enabled = true;  
            //tt.StartBoundary = (DateTime.Now.AddSeconds(60)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");  
            //tt.Repetition.Interval = "PT1M";  

            //CultureInfo cultinfo = new CultureInfo("en-US");
            //DateTime startDate = Convert.ToDateTime("04-01-2021 12:10:15 AM", cultinfo);
            //DateTime endDate = Convert.ToDateTime("04-01-2022 12:10:15 AM", cultinfo);

            // https://learn.microsoft.com/en-us/windows/win32/taskschd/monthlytrigger  
            //IMonthlyTrigger mt = (IMonthlyTrigger)td.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLY);
            //mt.StartBoundary = startDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            //mt.EndBoundary = endDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            // mt.DaysOfMonth = 0x20000000 | 0x40000000; // 30 and 31  
            //mt.MonthsOfYear = MonthsOfTheYear.AllMonths;  
            //mt.MonthsOfYear = 0X400 | 0X800; // November and December  

            td.Settings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_IGNORE_NEW;
            td.Settings.StopIfGoingOnBatteries = false;
            td.Settings.AllowHardTerminate = false;
            //td.Settings.AllowHardTerminate = true;
            td.Settings.DisallowStartIfOnBatteries = false;

            td.Principal.RunLevel = _TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST;
            // td.Principal.LogonType = _TASK_LOGON_TYPE.TASK_LOGON_GROUP;
            //td.Settings.Hidden = false;


            IExecAction execAction = (IExecAction)td.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
            execAction.Path = filePath;
            var rootFolder = ts.GetFolder("\\");
            try
            {
                IRegisteredTask ticket = rootFolder.RegisterTaskDefinition(taskName, td, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Could not add a task : " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        public void Start(string taskName)
        {

            //Add COM reference to Task Scheduler
            TaskScheduler.ITaskService scheduler = new TaskScheduler.TaskScheduler();

            //Change first parameter to remote server if desired and add credentials
            scheduler.Connect();

            //Specify the path to the folder containing the task, could make this an extension method
            var folder = scheduler.GetFolder(@"\");
            var task = folder?.GetTask(taskName);


            //Run the task, optionally pass parameters
            if (task != null)
                task.Run(null);
        }

        public void Stop(string taskName)
        {

            //Add COM reference to Task Scheduler
            TaskScheduler.ITaskService scheduler = new TaskScheduler.TaskScheduler();

            //Change first parameter to remote server if desired and add credentials
            scheduler.Connect();

            //Specify the path to the folder containing the task, could make this an extension method
            var folder = scheduler.GetFolder(@"\");
            var task = folder?.GetTask(taskName);


            //Run the task, optionally pass parameters
            if (task != null)
                task.Stop(0);
        }

        /* TaskService Lib
        void exT()
        {
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Test", td);

                // Remove the task we just created
                ts.RootFolder.DeleteTask("Test");
            }
        }
        */
    }
}
