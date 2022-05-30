using System.ComponentModel.DataAnnotations;

namespace Save_Yoour_Apps.Models
{
    public class App
    {
        public int owner { get; set; } = -1; //владелец
        public int Id { get; set; } //ид владельца
        public string Identity { get; set; } = ""; //идентификатор
        public DateTime DateCreated { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc); //дата 
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; } = ""; // название
        [Required(ErrorMessage = "Не указано описание")]
        public string Desc { get; set; } = ""; //описание
    }
}
