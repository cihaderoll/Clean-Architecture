using CleanArchitectrure.Application.Interface.Infrastructure;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Commands;
using MassTransit;
using MediatR;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;

        public GetAllUsersHandler(IUnitOfWork unitOfWork,
                                  IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
        }


        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            await _publishEndpoint.Publish(new ValidateUser { Id = 1 }, cancellationToken);

            return null;
        }
    }
}
