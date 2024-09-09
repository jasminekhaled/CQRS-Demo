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
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
        {
            private readonly Context _context;
            public DeleteUserCommandHandler(Context context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null)
                    return default;

                _context.Users.Remove(user);
                _context.SaveChanges();
                return request.Id;
            }
        }
    }
}
