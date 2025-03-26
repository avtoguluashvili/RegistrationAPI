﻿using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Domain;

namespace RegistrationAPI.Repository.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}