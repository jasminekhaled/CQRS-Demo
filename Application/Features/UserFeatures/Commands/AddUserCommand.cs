using Domain.Models;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
        {
            private readonly Context _context;
            public AddUserCommandHandler(Context context)
            {
                _context = context;
            }
            public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    Name = request.Name,
                    Age = request.Age,
                    Address = request.Address
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
        }
    }
}
