using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyToDo_List
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndTime { get; set; }   
        public ToDoTask(int id, string task, DateTime createdAt, bool isDone, DateTime endTime)
        {
            Id = id;
            Task = task;
            CreatedAt = createdAt;
            IsDone = isDone;
            EndTime = endTime;
        }
        public void MarkTask()
        {
            IsDone = true;
        }
        public override string ToString()
        {
            return $"{Id}\t{Task}\t{CreatedAt}\t{IsDone}\t{EndTime}";
        }
        public static ToDoTask ToBooking(string booking)
        {
            var result = booking.Split('\t');
            int id = int.Parse(result[0]);
            string task = result[1];
            DateTime createdAt = DateTime.Parse(result[2]);
            bool isDone = bool.Parse(result[3]);
            DateTime endTime = DateTime.Parse(result[4]);
            ToDoTask booking1 = new ToDoTask(id,task,createdAt,isDone,endTime);
            return booking1;
        }
    }
}




