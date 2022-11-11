﻿using CookingBook.Infrastructure.EF.Configuration;
using CookingBook.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
namespace CookingBook.Infrastructure.EF.Contexts;

public class ReadDbContext : DbContext
{
    
    
    public DbSet<RecipeReadModel> Recipes { get; set; }
    
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options){}
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("cookingBook");

        var configuration = new ReadConfiguration();

        modelBuilder.ApplyConfiguration<RecipeReadModel>(configuration);

        modelBuilder.ApplyConfiguration<IngredientReadModel>(configuration);
    
        modelBuilder.ApplyConfiguration<StepReadModel>(configuration);
        
        modelBuilder.ApplyConfiguration<ToolReadModel>(configuration);

    }
    
}