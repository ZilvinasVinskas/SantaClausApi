using MediatR;
using Persistence;

namespace Application.Presents
{
    public class GetChildQuery : IRequest<ChildDto>
    {
        public Guid ChildId;

        public GetChildQuery(Guid childId)
        {
            ChildId = childId;
        }
    }

    public class GetChildHandler : IRequestHandler<GetChildQuery, ChildDto>
    {
        private readonly DataContext _context;

        public GetChildHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ChildDto> Handle(GetChildQuery request, CancellationToken cancellationToken)
        {
            var child = await _context.Children.FindAsync(request.ChildId) ?? throw new Exception("Can't find child");
            return new ChildDto(child.Id, child.Name, child.Surname);
        }
    }
}


