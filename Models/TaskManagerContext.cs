using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CLI.Models;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source=D:\\CLI\\TaskManager.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("TaskItem");

            entity.Property(e => e.taskItemId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("TaskItemID")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.createdDt).HasColumnType("DateTime");
            entity.Property(e => e.isTaskComplete).HasColumnType("bool");
            entity.Property(e => e.modifiedDt).HasColumnType("DateTime");
            entity.Property(e => e.TaskListId)
                .HasColumnType("INT")
                .HasColumnName("TaskListID");

            entity.HasOne(d => d.TaskList).WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.TaskListId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.ToTable("TaskList");

            entity.Property(e => e.taskListId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("TaskListID")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.createdDt).HasColumnType("DateTime");
            entity.Property(e => e.modifiedDt).HasColumnType("DateTime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
