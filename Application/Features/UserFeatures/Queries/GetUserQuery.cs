using Application.Features.UserFeatures.Commands;
using Domain.Models;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
        {
            private readonly Context _context;
            public GetUserQueryHandler(Context context)
            {
                _context = context;
            }
            public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null)
                    return new User();

                return user;
            }
        }
    }
}
