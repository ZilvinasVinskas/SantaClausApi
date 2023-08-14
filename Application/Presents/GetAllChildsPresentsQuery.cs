using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Presents
{

    public class GetAllChildsPresentsQuery : IRequest<IEnumerable<PresentDto>>
    {
        public Guid ChildId;

        public GetAllChildsPresentsQuery(Guid childId)
        {
            ChildId = childId;
        }
    }

    public class GetAllChildsPresentsHandler : IRequestHandler<GetAllChildsPresentsQuery, IEnumerable<PresentDto>>
    {
        private readonly DataContext _context;

        public GetAllChildsPresentsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PresentDto>> Handle(GetAllChildsPresentsQuery request, CancellationToken cancellationToken)
        {
            var child = await _context.Children.FindAsync(request.ChildId) ?? throw new Exception("Can't find child");
            return await _context.Presents
                .Where(x => x.ChildId == child.Id)
                .Select(x =>
                    new PresentDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                .ToListAsync();
        }
    }
}



