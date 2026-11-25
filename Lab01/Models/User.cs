using System;
using System.Text.Json.Serialization;

namespace Lab01.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Today.AddYears(-19);
        public string Gender { get; set; } = "Мужской";
        public string Faculty { get; set; } = string.Empty;
        public bool IsSubscribed { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public int Age => CalculateAge(BirthDate);

        public static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return Math.Max(0, age);
        }
    }
}
