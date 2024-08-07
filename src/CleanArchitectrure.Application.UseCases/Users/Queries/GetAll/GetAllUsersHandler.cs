using CleanArchitectrure.Application.Interface.Infrastructure;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Commands;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ICustomerRepository _cachedCustomerRepository;

        public GetAllUsersHandler(IUnitOfWork unitOfWork,
                                  IPublishEndpoint publishEndpoint,
                                  [FromKeyedServices("CustomerRepo")]ICustomerRepository cachedCustomerRepository)
        {
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
            _cachedCustomerRepository = cachedCustomerRepository;
        }


        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _cachedCustomerRepository.DenemeKeyedService();
            await _publishEndpoint.Publish(new ValidateUser { Id = 1 }, cancellationToken);

            return null;
        }
    }
}
