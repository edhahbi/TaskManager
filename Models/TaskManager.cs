namespace TaskManager
{
    public enum ReturnStatus
    {
        Ok = 0,
        NotFound = 1,
        Illegal = 2,
    }

    public class TaskManager
    {
        private static List<Task> _listTasks = new List<Task>();
        private static int _id;

        public static void Create(String description)
        {
            var task = new Task(_id,description);
            _id++;
            _listTasks.Add(task);
        }

        public static ReturnStatus UpdateDescription(int id, string description){
            try
            {
                var task = RetrieveById(id);
                task._description = description;
                task._updatedAt = DateTime.Now;
                return ReturnStatus.Ok;
            }
            catch
            {
                return ReturnStatus.NotFound;
            }
        }

        public static ReturnStatus UpdateStatus(int id,Status newStatus)
        {
            try
            {
                var task = RetrieveById(id);
                if (newStatus < task._status) return ReturnStatus.Illegal;
                else
                {
                    task._status = newStatus;
                    task._updatedAt = DateTime.Now;
                    return ReturnStatus.Ok;
                }
            }
            catch
            {
                return ReturnStatus.NotFound;
            }
        }

        public static ReturnStatus DeleteById(int id)
        {
            try
            {
                _listTasks.RemoveAt(id);
                return ReturnStatus.Ok;
            }
            catch
            {
                return ReturnStatus.NotFound;
            }
        }
    
        public static List<Task> RetierveByStatus(Status status)
        {
            List<Task> result = new List<Task>();
            foreach (var task in _listTasks)
            {
                if(task._status == status) result.Add(task);
            }
            return result;
        }

        public static Task RetrieveById(int id)
        {
            return _listTasks[id];
        }

        public static void PrintTasks()
        {
            foreach (var task in _listTasks)
            {
                Console.WriteLine($"{task._id}:{task._description},{task._status}");
            }
        }
    }
}
