using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }
    
    [Required]
    public string Username { get; set; }


    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    public User() { }

    public User(string fullName, string username, string password, string email)
    {
        FullName = fullName;
        Username = username;
        Password = password;
        Email = email;
    }
}