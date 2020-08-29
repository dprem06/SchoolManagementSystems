using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesServices.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentManagementContext _context;

        public CourseRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<int> AddCourse(Course Course)
        {
            var result = _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            return (int)result.Entity.CourseId;
        }

        public async Task<int> DeleteCourse(int id)
        {
            int result = 0;
            var employee = _context.Courses.FirstOrDefault(e => e.CourseId == id);
            if (employee != null)
            {
                _context.Courses.Remove(employee);
                result = await _context.SaveChangesAsync();
                return result;
            }

            return result;
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.CourseId == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
