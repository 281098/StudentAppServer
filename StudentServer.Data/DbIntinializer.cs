using Microsoft.AspNetCore.Identity;
using StudentAppServer.Data.Entities;
using StudentServer.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAppServer.Data
{
    public class DbIntinializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DbIntinializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = "2",
                    Name = "Student",
                    NormalizedName = "Student",
                    Description = "Student Role"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = "3",
                    Name = "Instructor",
                    NormalizedName = "Instructor",
                    Description = "Instructor Role"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    Id = "1",
                    UserName = "admin",
                    Email = "admin@gmail.com",
                }, "123456");
                await _userManager.CreateAsync(new AppUser()
                {
                    Id = "2",
                    UserName = "student",
                    Email = "student@gmail.com",
                }, "123456");
                await _userManager.CreateAsync(new AppUser()
                {
                    Id = "3",
                    UserName = "instructor",
                    Email = "instructor@gmail.com",
                }, "123456");
                var admin = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(admin, "Admin");
                var student = await _userManager.FindByNameAsync("student");
                await _userManager.AddToRoleAsync(student, "Student");
                var instructor = await _userManager.FindByNameAsync("instructor");
                await _userManager.AddToRoleAsync(instructor, "Instructor");
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.Add(new Department()
                {
                    DepartmentId = "MI",
                    Building = "D3",
                    Name = "Vien Toan Ung DUng",
                    Status = Enums.Status.Active
                });
            }

            if (!_context.StudentDepartments.Any())
            {
                _context.StudentDepartments.Add(new StudentDepartment()
                {
                    Id = "MI1",
                    DepartmentId = "MI",
                    Name = "Khoa Toan-Tin",
                    Status = Enums.Status.Active
                });
                _context.StudentDepartments.Add(new StudentDepartment()
                {
                    Id = "MI2",
                    DepartmentId = "MI",
                    Name = "Khoa HTTTQL",
                    Status = Enums.Status.Active
                });
            }

            if (!_context.StudentClasses.Any())
            {
                _context.StudentClasses.Add(new StudentClass()
                {
                    Id = "MI1-20161",
                    StudentDepartmentId = "MI1",
                    DepartmentId = "MI",
                    Year = "2016",
                    Name = "Toan tin - 2016- 01"
                });

                _context.StudentClasses.Add(new StudentClass()
                {
                    Id = "MI1-20162",
                    StudentDepartmentId = "MI1",
                    DepartmentId = "MI",
                    Year = "2016",
                    Name = "Toan Tin - 2016 -02"
                });

                _context.StudentClasses.Add(new StudentClass()
                {
                    Id = "MI1-2017",
                    StudentDepartmentId = "MI1",
                    DepartmentId = "MI",
                    Year = "2017",
                    Name = "Toan Tin - 2017",
                });
                _context.StudentClasses.Add(new StudentClass()
                {
                    Id = "MI2-20171",
                    StudentDepartmentId = "MI2",
                    DepartmentId = "MI",
                    Year = "2017",
                    Name = "HTTTQL - 2017 -01",
                });
                _context.StudentClasses.Add(new StudentClass()
                {
                    Id = "MI2-20172",
                    StudentDepartmentId = "MI2",
                    DepartmentId = "MI",
                    Year = "2017",
                    Name = "HTTTQL - 2017 - 02",
                });
            }

            if (!_context.Students.Any())
            {
                var admin = await _userManager.FindByNameAsync("admin");
                var student = await _userManager.FindByNameAsync("student");
                var instructor = await _userManager.FindByNameAsync("instructor");
                _context.Students.Add(new Student()
                {
                    Id = "20161997",
                    DepartmentId = "MI",
                    StudentDepartmentId = "MI1",
                    StudentClassId = "MI1-20161",
                    CreatedYear = "2016",
                    Name = "Hung Vu Van Toan tin 01",
                    BitrhDay = DateTime.Now,
                    CardId = 174629083,
                    Status = Enums.Status.Active,
                    AppUserId = admin.Id
                });
                _context.Students.Add(new Student()
                {
                    Id = "20161998",
                    DepartmentId = "MI",
                    StudentDepartmentId = "MI1",
                    StudentClassId = "MI1-20162",
                    CreatedYear = "2016",
                    Name = "Hung Vu Van Toan tin 02",
                    BitrhDay = DateTime.Now,
                    CardId = 174629083,
                    Status = Enums.Status.Active,
                    AppUserId = admin.Id
                });
                _context.Students.Add(new Student()
                {
                    Id = "20161999",
                    DepartmentId = "MI",
                    StudentDepartmentId = "MI2",
                    StudentClassId = "MI2-20171",
                    CreatedYear = "2017",
                    Name = "Hung Vu Van htttql 01",
                    BitrhDay = DateTime.Now,
                    CardId = 174629083,
                    Status = Enums.Status.Active,
                    AppUserId = admin.Id
                });
                _context.Students.Add(new Student()
                {
                    Id = "20162000",
                    DepartmentId = "MI",
                    StudentDepartmentId = "MI2",
                    StudentClassId = "MI2-20172",
                    CreatedYear = "2017",
                    Name = "Hung Vu Van htttql 02",
                    BitrhDay = DateTime.Now,
                    CardId = 174629083,
                    Status = Enums.Status.Active,
                    AppUserId = admin.Id
                });
            }
            _context.SaveChanges();
        }
    }
}