using BuisnesServices.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagement.CQRS.Command
{
    public class DeleteCourseCommand : IRequest<int>
    {

        public int Id { get; set; }
        public class CreateTransportCommandHandler : IRequestHandler<DeleteCourseCommand, int>
        {
            private readonly ICourseRepository _courseRepository;
            public CreateTransportCommandHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public async Task<int> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                return await _courseRepository.DeleteCourse(request.Id);
            }
        }
    }
}