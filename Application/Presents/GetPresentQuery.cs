using MediatR;
using Persistence;

namespace Application.Presents
{

    public class GetPresentQuery : IRequest<PresentDto>
    {
        public Guid PresentId;

        public GetPresentQuery(Guid presentId)
        {
            PresentId = presentId;
        }
    }

    public class GetPresentHandler : IRequestHandler<GetPresentQuery, PresentDto>
    {
        private readonly DataContext _context;

        public GetPresentHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<PresentDto> Handle(GetPresentQuery request, CancellationToken cancellationToken)
        {
            var present = await _context.Presents.FindAsync(request.PresentId) ?? throw new Exception("Can't find present");
            return new PresentDto
            {
                Id = present.Id,
                Name = present.Name
            };
        }
    }
}



