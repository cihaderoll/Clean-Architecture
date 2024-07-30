using CleanArchitectrure.Domain.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Infrastructure.Consumers.Commands
{
    public class ValidateUserConsumer : IConsumer<ValidateUser>
    {
        public async Task Consume(ConsumeContext<ValidateUser> context)
        {
            throw new NotImplementedException();
        }
    }
}
