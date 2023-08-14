using MediatR;
using Persistence;

namespace Application.Presents
{

    public class RemovePresentCommand : IRequest
    {
        public Guid PresentId;

        public RemovePresentCommand(Guid presentId)
        {
            PresentId = presentId;
        }
    }

    public class RemovePresentHandler : IRequestHandler<RemovePresentCommand>
    {
        private readonly DataContext _context;

        public RemovePresentHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(RemovePresentCommand request, CancellationToken cancellationToken)
        {
            var present = await _context.Presents.FindAsync(request.PresentId)
                ?? throw new Exception("Can't find present to delete");
            _context.Presents.Remove(present);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}


