using BuisnesServices.Repository;
using DataAccessLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagement.CQRS.Query
{
    public class GetAllCourse : IRequest<IEnumerable<Course>>
    {
        public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCourse, IEnumerable<Course>>
        {
            private readonly ICourseRepository _courseRepository;
            public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<IEnumerable<Course>> Handle(GetAllCourse request, CancellationToken cancellationToken)
            {
                var courseList = await _courseRepository.GetCourses();
                if (courseList == null)
                {
                    return null;
                }
                return courseList;
            }
        }
    }
}
