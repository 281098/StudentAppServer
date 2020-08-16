using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAppServer.Data.Entities;

namespace StudentAppServer.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admins { set; get; }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppUser> AppUsers { set; get; }
        public DbSet<Classroom> Classrooms { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Instructor> Instructors { set; get; }
        public DbSet<InstructorDepartment> InstructorDepartments { set; get; }
        public DbSet<InstructorNotification> InstructorNotifications { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<Prereq> Prereqs { set; get; }
        public DbSet<Section> Sections { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudentClass> StudentClasses { set; get; }
        public DbSet<StudentDepartment> StudentDepartments { set; get; }
        public DbSet<StudentNotification> StudentNotifications { set; get; }
        public DbSet<Take> Takes { set; get; }
        public DbSet<Teach> Teaches { set; get; }
        public DbSet<TimeSlot> TimeSlots { set; get; }
        public DbSet<ToeicPoint> ToeicPoints { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Identity Config

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });

            #endregion Identity Config

            #region Entity Config

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => new { e.Building, e.RoomNumber })
                    .HasName("PK__classroom");

                entity.ToTable("Classrooms");

                entity.Property(e => e.Building)
                    .HasColumnName("Building")
                    .HasMaxLength(20);

                entity.Property(e => e.RoomNumber)
                    .HasColumnName("RoomNumber")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__course__dept_nam__164452B1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__department");

                entity.ToTable("Departments");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.Building)
                    .HasColumnName("Building")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructors");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20);

                entity.Property(e => e.InstructorDepartmentId)
                    .HasColumnName("InstructorDepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                   .HasColumnName("DepartmentId")
                   .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200);

                entity.Property(e => e.Salary)
                    .HasColumnName("Salary")
                    .HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.InstructorDepartment)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => new { d.InstructorDepartmentId, d.DepartmentId })
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__instructor_instructordepartment");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__instructor_appuser");
            });
            modelBuilder.Entity<InstructorDepartment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.DepartmentId })
                   .HasName("PK_InstructorDepartment");

                entity.ToTable("InstructorDepartments");

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.InstructorDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__instructordept_dept");
            });

            modelBuilder.Entity<InstructorNotification>(entity =>
            {
                entity.HasKey(e => new { e.InstructorId, e.NotificationId })
                   .HasName("PK_InstructorNotice");

                entity.ToTable("InstructorNotification");

                entity.Property(e => e.InstructorId)
                    .HasMaxLength(20);

                entity.Property(e => e.NotificationId)
                    .HasMaxLength(20);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.InstructorNotifications)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__instructorNotification12");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.InstructorNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NoticeInstrucNotification");
            });

            modelBuilder.Entity<StudentNotification>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.NotificationId })
                   .HasName("PK_StudentNotice");

                entity.ToTable("StudentNotification");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(20);

                entity.Property(e => e.NotificationId)
                    .HasMaxLength(20);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentNotifications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__StudentNotification12");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.StudentNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NoticeStudentNotification");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK_language");

                entity.ToTable("Languages");

                entity.Property(e => e.Id)
                       .HasMaxLength(20);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK_Notification");

                entity.ToTable("Notifications");

                entity.Property(e => e.Id)
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                   .HasName("PK_Permission");

                entity.ToTable("Permissions");

                entity.HasOne(d => d.AppRole)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permission_AppRole123");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK_Post");

                entity.ToTable("Posts");

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.HasOne(d => d.PostCategory)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostCategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Post_PostCategory");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK_Postcategory");

                entity.ToTable("PostCategories");

                entity.Property(e => e.Id)
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Prereq>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PrereqId })
                    .HasName("PK__prereq");

                entity.ToTable("Prereqs");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .HasMaxLength(20);

                entity.Property(e => e.PrereqId)
                    .HasColumnName("PrereqId")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Prereqs)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prereq__course");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("PK__section");

                entity.ToTable("Sections");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .HasMaxLength(20);

                entity.Property(e => e.SecId)
                    .HasColumnName("SecId")
                    .HasMaxLength(20);

                entity.Property(e => e.Semester)
                    .HasColumnName("Semester")
                    .HasMaxLength(20);

                entity.Property(e => e.Year)
                    .HasColumnName("Year")
                    .HasMaxLength(20);

                entity.Property(e => e.Building)
                    .HasColumnName("Building")
                    .HasMaxLength(20);

                entity.Property(e => e.RoomNumber)
                    .HasColumnName("RoomNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("TimeSlotId")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__section__course___1ED998B2");

                entity.HasOne(d => d.TimeSlot)
                   .WithMany(p => p.Sections)
                   .HasForeignKey(d => d.TimeSlotId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .HasConstraintName("FK__section__timeslot");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => new { d.Building, d.RoomNumber })
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__section__1FCDBCEB");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK__Student");

                entity.ToTable("Students");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.StudentClassId)
                   .HasColumnName("StudentClassId")
                   .HasMaxLength(20);

                entity.Property(e => e.StudentDepartmentId)
                   .HasColumnName("StudentDepartmentId")
                   .HasMaxLength(20);

                entity.Property(e => e.CreatedYear)
                  .HasColumnName("CreatedYear")
                  .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasMaxLength(20);

                entity.HasOne(d => d.StudentClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => new { d.StudentClassId, d.StudentDepartmentId, d.DepartmentId })
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__student__dept_na__276EDEB3");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__student__appuser");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.StudentDepartmentId, e.DepartmentId })
                   .HasName("PK__StudentClass");

                entity.ToTable("StudentClasses");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.StudentDepartmentId)
                    .HasColumnName("StudentDepartmentId")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("Year")
                    .HasMaxLength(20);

                entity.HasOne(d => d.StudentDepartment)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => new { d.StudentDepartmentId, d.DepartmentId })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__studentclass__dept");
            });

            modelBuilder.Entity<StudentDepartment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.DepartmentId })
                   .HasName("PK_Studentdepartment");

                entity.ToTable("StudentDepartments");

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.StudentDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__StudentDepartment_dept");
            });

            modelBuilder.Entity<Take>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("PK__takes__A0A7458A976F2631");

                entity.ToTable("Takes");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .HasMaxLength(20);

                entity.Property(e => e.SecId)
                    .HasColumnName("SecId")
                    .HasMaxLength(20);

                entity.Property(e => e.Semester)
                    .HasColumnName("Semester")
                    .HasMaxLength(20);

                entity.Property(e => e.Year)
                    .HasColumnName("Year")
                    .HasMaxLength(20);

                entity.Property(e => e.Grade)
                    .HasColumnName("Grade")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__takes__ID__2B3F6F97");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__takes__2A4B4B5E");
            });

            modelBuilder.Entity<Teach>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("PK__teaches__A0A7458ABC151A07");

                entity.ToTable("Teaches");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseId")
                    .HasMaxLength(20);

                entity.Property(e => e.SecId)
                    .HasColumnName("SecId")
                    .HasMaxLength(20);

                entity.Property(e => e.Semester)
                    .HasColumnName("Semester")
                    .HasMaxLength(20);

                entity.Property(e => e.Year)
                    .HasColumnName("Year")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__teaches_instructor");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Teaches)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .HasConstraintName("FK__teaches_section");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => e.TimeSlotId)
                    .HasName("PK__timeslot");

                entity.ToTable("TimeSlots");

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("TimeSlotId")
                    .HasMaxLength(20);

                entity.Property(e => e.Day)
                    .HasColumnName("Day")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ToeicPoint>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.StudentId })
                    .HasName("PK__toeicpoint");

                entity.ToTable("ToeicPoints");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentId")
                    .HasMaxLength(20);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Student)
                   .WithMany(p => p.ToeicPoints)
                   .HasForeignKey(d => d.StudentId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK__toeic_student");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__feedback");

                entity.ToTable("Feedbacks");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(200);
            });

            #endregion Entity Config
        }
    }
}