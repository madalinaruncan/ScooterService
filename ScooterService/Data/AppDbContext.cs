﻿using Microsoft.EntityFrameworkCore;

namespace ScooterService.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
