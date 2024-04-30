//using System.Collections.Generic;
//using TaskScheduler;

//namespace HeCopUI_Framework
//{
//    public partial class TaskSchedulerManager
//    {

//        ITaskService taskService;

//        public TaskSchedulerManager()
//        {

//            taskService = new TaskScheduler.TaskScheduler();
//            taskService.Connect();
//            TaskDefinition = taskService.NewTask(0);
//            ExecAction = (IExecAction)TaskDefinition.Actions.Create(TaskActionType);
//        }

//        /*
//        public ITaskDefinition TaskDefinition { get; set; }

//        public IExecAction ExecAction { get; set; }

//        public _TASK_ACTION_TYPE TaskActionType { get; set; } = _TASK_ACTION_TYPE.TASK_ACTION_EXEC;*/


//        private static List<IRegisteredTask> GetReadyAndRunningTasks(
//    ITaskFolder folder,
//        List<IRegisteredTask> readyAndRunningTasks = null)
//        {
//            if (readyAndRunningTasks == null)
//            {
//                readyAndRunningTasks = new List<IRegisteredTask>();
//            }

//            IRegisteredTaskCollection tasks = folder.GetTasks(flags: 0);

//            foreach (IRegisteredTask task in tasks)
//            {
//                if (task.State == _TASK_STATE.TASK_STATE_READY
//                    || task.State == _TASK_STATE.TASK_STATE_RUNNING)
//                {
//                    readyAndRunningTasks.Add(task);
//                }
//            }

//            foreach (ITaskFolder subFolder in folder.GetFolders(flags: 0))
//            {
//                GetReadyAndRunningTasks(subFolder, readyAndRunningTasks);
//            }

//            return readyAndRunningTasks;
//        }


//        #region Task schedulder
//        public static void StartTask(string taskName)
//        {
//            ITaskService taskService = new TaskScheduler.TaskScheduler();

//            // Connect to the TaskService
//            taskService.Connect();

//            ITaskFolder rootFolder = taskService.GetFolder(@"\");
//            List<IRegisteredTask> readyAndRunningTasks = GetReadyAndRunningTasks(rootFolder);
//            foreach (IRegisteredTask a in readyAndRunningTasks)
//            {
//                if (taskName == a.Name)
//                {
//                    a.Run(null);


//                }
//            }

//        }

//        public static void Stop(string taskName)
//        {
//            ITaskService taskService = new TaskScheduler.TaskScheduler();

//            // Connect to the TaskService
//            taskService.Connect();

//            ITaskFolder rootFolder = taskService.GetFolder(@"\");
//            List<IRegisteredTask> readyAndRunningTasks = GetReadyAndRunningTasks(rootFolder);
//            foreach (IRegisteredTask a in readyAndRunningTasks)
//            {
//                if (taskName == a.Name)
//                {
//                    a.Stop(0);

//                }
//            }
//        }

//        public static bool CheckExistTask(string taskName)
//        {
//            bool av = false;
//            ITaskService taskService = new TaskScheduler.TaskScheduler();

//            // Connect to the TaskService
//            taskService.Connect();

//            ITaskFolder rootFolder = taskService.GetFolder(@"\");

//            foreach (IRegisteredTask a in taskService.GetRunningTasks(0))
//            {
//                if (taskName == a.Name)
//                {
//                    av = true;
//                }
//            }

//            return av;
//        }

//        public static void AddNewTask(string taskName, string description, string filePath, _TASK_INSTANCES_POLICY multipleInstances,
//            _TASK_LOGON_TYPE logonType, bool hidden
//            , _TASK_RUNLEVEL taskRunLevel, bool allowTaskToBeRunOnDemand, bool allowTerminate, string workingDirectory, string arguments = "")
//        {
//            ITaskService taskService = new TaskScheduler.TaskScheduler();

//            // Connect to the TaskService
//            taskService.Connect();

//            // Create a new task definition and assign properties
//            ITaskDefinition taskDefinition = taskService.NewTask(0);
//            taskDefinition.Settings.MultipleInstances = multipleInstances;
//            taskDefinition.RegistrationInfo.Description = description;
//            taskDefinition.Principal.LogonType = logonType;
//            taskDefinition.Settings.Hidden = hidden; // Set to True when running task should be hidden
//                                                     // NOTE: When Hidden is true, it does not work if _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN 
//                                                     // is used as parameter to RegisterTaskDefinition
//                                                     // 
//                                                     // 
//                                                     // Add a trigger that will fire the task every other day
//                                                     //taskDefinition.Principal.RunLevel= _TASK_RUNLEVEL.
//            taskDefinition.Principal.RunLevel = taskRunLevel;
//            taskDefinition.Settings.AllowDemandStart = allowTaskToBeRunOnDemand;
//            taskDefinition.Settings.AllowHardTerminate = allowTerminate;

//            // Create the Task action 
//            IExecAction taskAction = (IExecAction)taskDefinition.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
//            // The Path to the program
//            taskAction.Path = filePath;
//            // Set Arguments
//            taskAction.Arguments = arguments;
//            taskAction.WorkingDirectory = workingDirectory;



//            ITaskFolder rootFolder = taskService.GetFolder(@"\");

//            rootFolder.RegisterTaskDefinition(taskName, taskDefinition, System.Convert.ToInt32(_TASK_CREATION.TASK_CREATE_OR_UPDATE), "", "", _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN_OR_PASSWORD);


//        }

//        public static void DeleteTask(string taskName)
//        {
//            ITaskService taskService = new TaskScheduler.TaskScheduler();

//            // Connect to the TaskService
//            taskService.Connect();

//            ITaskFolder rootFolder = taskService.GetFolder(@"\");
//            rootFolder.DeleteTask(taskName, 0);



//        }

//        #endregion
//    }
//}
