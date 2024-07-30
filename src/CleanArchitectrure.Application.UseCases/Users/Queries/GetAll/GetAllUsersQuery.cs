using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<GetAllUsersResponse>
    {
        public int Id { get; set; }
    }
}
