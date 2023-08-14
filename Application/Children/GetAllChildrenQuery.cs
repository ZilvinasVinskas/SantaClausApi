using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Presents
{

    public class GetAllChildrenQuery : IRequest<List<ChildDto>>
    {

    }

    public class GetAllChildrenHandler : IRequestHandler<GetAllChildrenQuery, List<ChildDto>>
    {
        private readonly DataContext _context;

        public GetAllChildrenHandler(DataContext context)
        {
            _context = context;
        }


        public async Task<List<ChildDto>> Handle(GetAllChildrenQuery request, CancellationToken cancellationToken)
        {

            var cc = await _context.Children.ToListAsync();
            return await _context.Children.Select(x => new ChildDto(x.Id, x.Name, x.Surname)).ToListAsync();
        }
    }
}


