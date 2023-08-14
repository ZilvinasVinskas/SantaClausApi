using System.Security.AccessControl;
using Domain;
using MediatR;
using Persistence;

namespace Application.Presents
{
    public class AssignPresentCommand : IRequest
    {
        public string Name;
        public Guid ChildId;

        public AssignPresentCommand(string name, Guid childId)
        {
            Name = name;
            ChildId = childId;
        }
    }

    public class AssignPresentHandler : IRequestHandler<AssignPresentCommand>
    {
        private readonly DataContext _context;

        public AssignPresentHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(AssignPresentCommand request, CancellationToken cancellationToken)
        {
            var child = await _context.Children.FindAsync(request.ChildId) ?? throw new Exception("Can't find child for present");

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new Exception("Present name must have value");
            }

            _context.Add(new Present
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ChildId = request.ChildId,
            });
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}



