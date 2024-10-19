using System;
using System.Collections.Generic;

class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public User(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}

class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(string name, string email, string role)
    {
        users.Add(new User(name, email, role));
    }

    public void UpdateUser(string name, string newEmail, string newRole)
    {
        foreach (var user in users)
        {
            if (user.Name == name)
            {
                user.Email = newEmail;
                user.Role = newRole;
                return;
            }
        }
        Console.WriteLine("Пользователь не найден.");
    }

    public void RemoveUser(string name)
    {
        users.RemoveAll(u => u.Name == name);
    }

    public void ShowUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Имя: {user.Name}, Email: {user.Email}, Роль: {user.Role}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        userManager.AddUser("Алиса", "alice@example.com", "User");
        userManager.AddUser("Мария", "maria@example.com", "Admin");

        Console.WriteLine("Список пользователей:");
        userManager.ShowUsers();

        userManager.UpdateUser("Алиса", "alice@example.com", "Admin");

        userManager.RemoveUser("Мария");

        Console.WriteLine("\nСписок пользователей после изменений:");
        userManager.ShowUsers();
    }
}
