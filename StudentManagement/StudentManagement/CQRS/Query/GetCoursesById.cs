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
    public class GetCoursesById : IRequest<IEnumerable<Course>>
    {
        public int Id { get; set; }
        public class GetCoursesByIdQueryHandler : IRequestHandler<GetCoursesById, IEnumerable<Course>>
        {
            private readonly ICourseRepository _courseRepository;
            public GetCoursesByIdQueryHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public async Task<IEnumerable<Course>> Handle(GetCoursesById request, CancellationToken cancellationToken)
            {
                var courseList = await _courseRepository.GetCourseById(request.Id);
                if (courseList == null)
                {
                    return null;
                }
                return courseList;
            }
        }
    }
}
