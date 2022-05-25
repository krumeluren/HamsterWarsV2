﻿using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options){ }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyConfig());
        modelBuilder.ApplyConfiguration(new EmployeeConfig());
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
