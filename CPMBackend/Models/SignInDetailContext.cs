using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class SignInDetailContext : DbContext 
{
    public DbSet<SignInDetail> SignInDetails { get; set; }

    public string DbPath { get; set; }

    public SignInDetailContext()
    {
        DbPath = "signindetail.db";
    }

    // The following configures EF to use a Sqlite database file in the project folder.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}

public class SignInDetail
{
    [Key]
    public int SignInDetailId { get; set; }

    [Column]
    public string UserEmail { get; set; } = "";

    [Column]
    public string UserPassword { get; set; } = "";
}