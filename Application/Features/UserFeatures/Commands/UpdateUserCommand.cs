using Domain.Models;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
        {
            private readonly Context _context;
            public UpdateUserCommandHandler(Context context)
            {
                _context = context;
            }
            public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null)
                    return new User();

                user.Name = request.Name;
                user.Age = request.Age;
                user.Address = request.Address;


                _context.Users.Update(user);
                _context.SaveChanges();
                return user;
            }
        }
    }
}
