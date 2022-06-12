using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace praktika.Models
{
    public partial class course_workContext : DbContext
    {
        public course_workContext()
        {
        }

        public course_workContext(DbContextOptions<course_workContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationForVacation> ApplicationForVacations { get; set; }
        public virtual DbSet<ClassificationVacation> ClassificationVacations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<LogPass> LogPasses { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkersOnProject> WorkersOnProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NOTEBOOK_KNST\\SQLEXPRESS;Database=course_work;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationForVacation>(entity =>
            {
                entity.HasKey(e => e.IdApplication)
                    .HasName("PK_Заявка на отпуск");

                entity.ToTable("Application_for_vacation");

                entity.Property(e => e.IdApplication).HasColumnName("id_application");

                entity.Property(e => e.DateBeginVacation)
                    .HasColumnType("date")
                    .HasColumnName("date_begin_vacation");

                entity.Property(e => e.IdClassificationVacation).HasColumnName("id_classification_vacation");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.StatusApplication).HasColumnName("status_application");

                entity.Property(e => e.VacationCount).HasColumnName("vacation_count");

                entity.HasOne(d => d.IdClassificationVacationNavigation)
                    .WithMany(p => p.ApplicationForVacations)
                    .HasForeignKey(d => d.IdClassificationVacation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_for_vacation_Classification_vacation");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.ApplicationForVacations)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_for_vacation_Workers");
            });

            modelBuilder.Entity<ClassificationVacation>(entity =>
            {
                entity.HasKey(e => e.IdClassificationVacation)
                    .HasName("PK_Классификация отпусков");

                entity.ToTable("Classification_vacation");

                entity.Property(e => e.IdClassificationVacation).HasColumnName("id_classification_vacation");

                entity.Property(e => e.CodeClassification)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code_classification")
                    .IsFixedLength(true);

                entity.Property(e => e.NameClassification)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("name_classification");

                entity.Property(e => e.PeriodVacation).HasColumnName("period_vacation");

                entity.Property(e => e.UsageCount).HasColumnName("usage_count");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IdDepartment)
                    .HasName("PK_department");

                entity.ToTable("Department");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.Department1)
                    .HasMaxLength(50)
                    .HasColumnName("department");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.ToTable("gender");

                entity.Property(e => e.IdGender).HasColumnName("id_gender");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gender_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogPass>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("log_pass");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.LogPasses)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_pass_Workers");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK_Должности");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.Post1)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("post");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("PK_Проекты");

                entity.Property(e => e.IdProject).HasColumnName("id_project");

                entity.Property(e => e.DateProjectBegin)
                    .HasColumnType("date")
                    .HasColumnName("date_project_begin");

                entity.Property(e => e.DateProjectEnd)
                    .HasColumnType("date")
                    .HasColumnName("date_project_end");

                entity.Property(e => e.DateProjectStatus)
                    .HasColumnType("date")
                    .HasColumnName("date_project_status");

                entity.Property(e => e.LaborCount).HasColumnName("labor_count");

                entity.Property(e => e.ProjectManager).HasColumnName("project_manager");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("project_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.HasKey(e => e.IdVacation)
                    .HasName("PK_Отпуска");

                entity.Property(e => e.IdVacation).HasColumnName("id_vacation");

                entity.Property(e => e.DataVacationReal)
                    .HasColumnType("date")
                    .HasColumnName("data_vacation_real");

                entity.Property(e => e.IdApplication).HasColumnName("id_application");

                entity.Property(e => e.IdClassificationVacation).HasColumnName("id_classification_vacation");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.VacationCountReal).HasColumnName("vacation_count_real");

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany(p => p.Vacations)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacations_Application_for_vacation");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.IdWorker)
                    .HasName("PK_Сотрудники");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.DateHiring)
                    .HasColumnType("date")
                    .HasColumnName("date_hiring");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(15)
                    .HasColumnName("patronymic")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Post).HasColumnName("post");

                entity.Property(e => e.ServiceNumber)
                    .HasMaxLength(10)
                    .HasColumnName("service_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("surname")
                    .IsFixedLength(true);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK_Workers_Department");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("FK_Workers_gender");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.Post)
                    .HasConstraintName("FK_Workers_Posts");
            });

            modelBuilder.Entity<WorkersOnProject>(entity =>
            {
                entity.HasKey(e => e.IdWorkerOnProject)
                    .HasName("PK_Сотрудники на проекте");

                entity.ToTable("Workers_on_project");

                entity.Property(e => e.IdWorkerOnProject).HasColumnName("id_worker_on_project");

                entity.Property(e => e.DateEndParticipate)
                    .HasColumnType("date")
                    .HasColumnName("date_end_participate");

                entity.Property(e => e.DateStartParticipate)
                    .HasColumnType("date")
                    .HasColumnName("date_start_participate");

                entity.Property(e => e.IdProject).HasColumnName("id_project");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.ProjectRole)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("project_role");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.WorkersOnProjects)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workers_on_project_Projects");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.WorkersOnProjects)
                    .HasForeignKey(d => d.IdWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workers_on_project_Workers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
