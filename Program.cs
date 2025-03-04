// See https://aka.ms/new-console-template for more information
using ModelFirst.Models;

Console.WriteLine("Hello, Students!");



var _context = new SchoolContext();




var course = new Course
{
    Credits = 2,
    Title = "Computer Science"
};

_context.Courses.Add(course);

var result = _context.SaveChanges();