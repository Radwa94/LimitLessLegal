using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class MyDbContext : DbContext
{
    public MyDbContext()
    {
        
    }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    public DbSet<ADAF_Branches> ADAF_Branchess { get; set; }
    public DbSet<ADAF_Cars> ADAF_Carss { get; set; }
   
    public DbSet<LGL_Authorization> LGL_Authorizations { get; set; }
    public DbSet<LGL_Authorization_kinds> LGL_Authorization_kindss { get; set; }
    public DbSet<LGL_Cause> LGL_Causes { get; set; }
    public DbSet<LGL_Client_types> LGL_Client_typess { get; set; }
    public DbSet<LGL_Clients> LGL_Clientss { get; set; }
    public DbSet<LGL_Contracting> LGL_Contractings { get; set; }
    public DbSet<LGL_Court> LGL_Courts { get; set; }
    public DbSet<LGL_Lawsuit> LGL_Lawsuits { get; set; }
    public DbSet<LGL_lawsuit_files> LGL_lawsuit_filess { get; set; }
    public DbSet<LGL_Lawsuit_Status> LGL_Lawsuit_Statuss { get; set; }
    public DbSet<LGL_Litigant> LGL_Litigants { get; set; }
    public DbSet<LGL_Sessions> LGL_Sessionss { get; set; }
    public DbSet<Permission_group> Permission_groups { get; set; }
    public DbSet<Permission_pages> Permission_pagess { get; set; }
    public DbSet<Users> Userss { get; set; }
    public DbSet<Branchleave> branchleaves { get; set; }
    public DbSet<investigation> investigation { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Jop> Jop { get; set; }
    //public DbSet<Calender> Calender { get; set; }
    public DbSet<ADAF_District_license> ADAF_District_licenses { get; set; }
    public DbSet<Central> Central { get; set; }
    public DbSet<Judgment> Judgment { get; set; }





}

