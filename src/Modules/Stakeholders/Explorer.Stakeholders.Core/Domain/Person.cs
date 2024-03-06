﻿using Explorer.BuildingBlocks.Core.Domain;
using System.Net.Mail;

namespace Explorer.Stakeholders.Core.Domain;

public class Person : Entity
{
    public long UserId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public string? ProfileImage { get; init; }
    public string? Bio { get; init; }
    public string? Quote { get; init; }
    public double Balance { get; set; }


    public Person(long userId, string name, string surname, string email, string? profileImage, string? bio, string? quote, double balance = 0)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Email = email;
        ProfileImage = profileImage;
        Bio = bio;
        Quote = quote;
        Balance = balance;
        Validate();
    }

    private void Validate()
    {
        if (UserId == 0) throw new ArgumentException("Invalid UserId");
        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
        if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email");
    }
}