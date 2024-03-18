using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestPro.Models2;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-KLBSCP3I\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateP)
                .HasColumnType("datetime")
                .HasColumnName("date_p");
            entity.Property(e => e.Directions)
                .HasMaxLength(100)
                .HasColumnName("directions");
            entity.Property(e => e.IdDiseases).HasColumnName("id_diseases");
            entity.Property(e => e.IdDoctor)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_doctor");
            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.InfoDop)
                .HasMaxLength(100)
                .HasColumnName("info_dop");
            entity.Property(e => e.Recipe).HasColumnName("recipe");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Card)
                .HasForeignKey<Card>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_User");

            entity.HasOne(d => d.IdDiseasesNavigation).WithMany(p => p.Cards)
                .HasForeignKey(d => d.IdDiseases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Diseases");

            entity.HasOne(d => d.RecipeNavigation).WithMany(p => p.Cards)
                .HasForeignKey(d => d.Recipe)
                .HasConstraintName("FK_Card_Drug");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCard).HasColumnName("id_card");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Midlename)
                .HasMaxLength(50)
                .HasColumnName("midlename");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Proffecional).HasMaxLength(50);
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.ToTable("Drug");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdCard).HasColumnName("id_card");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Result)
                .HasMaxLength(100)
                .HasColumnName("result");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.IdCardNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Card");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Services");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_Events_EventType");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("adress");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.IdCard).HasColumnName("id_card");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("number");
            entity.Property(e => e.NumberPassport)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("number_passport");
            entity.Property(e => e.Oname).HasMaxLength(50);
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("photo");
            entity.Property(e => e.SeriaPassport)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("seria_passport");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.NameRole)
                .HasMaxLength(30)
                .HasColumnName("name_role");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_Users_Doctor");

            entity.HasOne(d => d.IdRole1).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_Users_Patient");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
