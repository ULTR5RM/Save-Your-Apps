using System.ComponentModel.DataAnnotations;

namespace Save_Yoour_Apps.Models
{
    public enum EventType { POST, GET}
    public class Event
    {
        public Event()
        {

        }
        public Event(EventType type, int App)
        {
            EventType = type;
            this.App = App;
        }

        public int App { get; set; } = -1; //приложение
        public int Id { get; set; } //айди
        public EventType EventType { get; set; } //какой то тип 
        public DateTime DateCreated { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);//дата
    }
}
