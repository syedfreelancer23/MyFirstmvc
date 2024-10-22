using System;
using Microsoft.EntityFrameworkCore;

namespace MyFirstmvc.Models;
using Microsoft.Extensions.DependencyInjection;
using MyFirstmvc.Data;

public static  class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UsersContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UsersContext>>() )   )
    {
if(context.Users.Any())
{
    return;
}

//adding rowdata intable
    context.Users.AddRange(
        new Users
        {
            Name="syed",
            Email="7BmIc@example.com",
            IsActive=true,
            PhoneNumber="1234567890",
            Password="syed",


        }
    );

    context.SaveChanges();

    }   
    }
}
