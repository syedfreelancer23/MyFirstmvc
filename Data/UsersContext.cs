using System;
using Microsoft.EntityFrameworkCore;
using MyFirstmvc.Models;

namespace MyFirstmvc.Data;

public class UsersContext:DbContext
{
public UsersContext (DbContextOptions<UsersContext> options)
            : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
}
