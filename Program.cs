﻿using System.Data.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class UserContext : DbContext
{
    public UserContext()
        : base("DBConnection")

    { }

    public DbSet<User> Users { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        using (UserContext db = new UserContext())
        {
            User user1 = new User { Name = "Tom", Age = 33 };
            User user2 = new User { Name = "Sam", Age = 26 };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены");

            var users = db.Users;
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
            }
        }
        Console.Read();
    }
}
