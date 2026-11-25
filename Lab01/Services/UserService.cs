using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using Lab01.Models;

namespace Lab01.Services
{
    public class UserService
    {
        private readonly string _filePath;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public UserService(string? customFilePath = null)
        {
            _filePath = customFilePath ?? Path.Combine(AppContext.BaseDirectory, "users.json");
        }

        public string FilePath => _filePath;

        public List<User> LoadUsers()
        {
            if (!File.Exists(_filePath))
            {
                return new List<User>();
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<User>();
                }
                return JsonSerializer.Deserialize<List<User>>(json, JsonOptions) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }

        public void SaveUsers(List<User> users)
        {
            string? dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string json = JsonSerializer.Serialize(users, JsonOptions);
            File.WriteAllText(_filePath, json);
        }

        public User? Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var users = LoadUsers();
            return users.FirstOrDefault(u =>
                string.Equals(u.Login.Trim(), login.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        public bool Register(User newUser, out string errorMessage)
        {
            var users = LoadUsers();
            if (users.Any(u => string.Equals(u.Login.Trim(), newUser.Login.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = "Пользователь с таким логином уже зарегистрирован.";
                return false;
            }

            newUser.Id = Guid.NewGuid();
            newUser.Login = newUser.Login.Trim();
            newUser.FullName = newUser.FullName.Trim();
            newUser.Email = newUser.Email.Trim();
            newUser.RegisteredAt = DateTime.Now;

            users.Add(newUser);
            SaveUsers(users);
            errorMessage = string.Empty;
            return true;
        }

        public void UpdateSubscription(Guid userId, bool isSubscribed, string email)
        {
            var users = LoadUsers();
            var existing = users.FirstOrDefault(u => u.Id == userId);
            if (existing != null)
            {
                existing.IsSubscribed = isSubscribed;
                existing.Email = isSubscribed ? email.Trim() : string.Empty;
                SaveUsers(users);
            }
        }
    }
}
