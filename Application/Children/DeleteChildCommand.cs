using System.Reflection.Metadata;
using Domain;
using MediatR;
using Persistence;

namespace Application.Presents
{
    public class DeleteChildCommand : IRequest
    {
        public Guid Id;
        public DeleteChildCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteChildHandler : IRequestHandler<DeleteChildCommand>
    {
        private readonly DataContext _context;

        public DeleteChildHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            var child = await _context.Children.FindAsync(request.Id) ?? throw new Exception("Can't find child to delete");
            _context.Remove(child);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

