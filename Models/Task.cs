using System.Collections;
using System.CommandLine;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace TaskManager;

public enum Status
{
    todo = 0, 
    in_progress = 1,
    done = 2
}

public class Task
{
    public int _id { get; set; }
    public string _description { get; set; }
    public Status _status { get; set; }
    public DateTime _createdAt { get; set; }
    public DateTime _updatedAt { get; set; }

    public Task() { }
    public Task(int id, string description, Status status, DateTime createdAt, DateTime updatedAt)
    {
        _id = id;
        _description = description;
        _status = status;
        _createdAt = createdAt;
        _updatedAt = updatedAt;
    }
}