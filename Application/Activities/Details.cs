using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {

        public class  Query:IRequest<Activity>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Activity>
        {
            public Handler(DataContext context)
            {
                _context = context;
            }

            public DataContext _context { get; }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activiy=await _context.Activities.FindAsync(request.Id);
                return activiy;
            }
        }

    }
   
}
