using System.Text.Json;

namespace TaskManager
{
    public enum ReturnStatus
    {
        Ok = 0,
        NotFound = 1,
        Illegal = 2,
    }

    public static class TaskManager
    {
        private static string _filePath = "db.json";
        private static List<Task> _listTasks = new List<Task>();

        public static void SaveJson()
        {
            var json = JsonSerializer.Serialize(_listTasks);
            File.WriteAllText(_filePath,json);
        }   
        
        public static void LoadJson()
        {
            var json = File.ReadAllText(_filePath);
            _listTasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }
        
        public static void Create(String description)
        {
            var task = new Task(_listTasks.Count,description,Status.todo,DateTime.Now,DateTime.Now);
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
                Console.WriteLine(JsonSerializer.Serialize<Task>(task));
            }
        }
    }
}
