using BuisnesServices.Repository;
using DataAccessLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagement.CQRS.Command
{
    public class AddCourseCommand : IRequest<int>
    {

        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public class CreateTransportCommandHandler : IRequestHandler<AddCourseCommand, int>
        {
            private readonly ICourseRepository _courseRepository;
            public CreateTransportCommandHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<int> Handle(AddCourseCommand command, CancellationToken cancellationToken)
            {
                var course = new Course
                {
                    CourseDescription = command.CourseDescription,
                    CourseDuration = command.CourseDuration,
                    CourseName = command.CourseName
                };
                return await _courseRepository.AddCourse(course);

            }
        }
    }
}
