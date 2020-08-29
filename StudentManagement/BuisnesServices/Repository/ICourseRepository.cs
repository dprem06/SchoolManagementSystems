using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesServices.Repository
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Get All Courses
        /// </summary>
        /// <returns>List of Courses</returns>
        Task<IEnumerable<Course>> GetCourses();

        /// <summary>
        /// Get All Courses
        /// </summary>
        /// <returns>Courses</returns>
        Task<Course> GetCourseById(int id);


        /// <summary>
        /// Add new Course
        /// </summary>
        /// <returns>New Course id</returns>
        Task<int> AddCourse(Course Course);

        /// <summary>
        /// Delete Course
        /// </summary>
        /// <returns>Deleted status</returns>
        Task<int> DeleteCourse(int id);
    }
}
