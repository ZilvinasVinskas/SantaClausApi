using System.Security.AccessControl;
using Domain;
using MediatR;
using Persistence;

namespace Application.Presents
{

    public class EditPresentCommand : IRequest
    {
        public string Name;
        public Guid Id;

        public EditPresentCommand(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }

    public class EditPresentHandler : IRequestHandler<EditPresentCommand>
    {
        private readonly DataContext _context;

        public EditPresentHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(EditPresentCommand request, CancellationToken cancellationToken)
        {
            var present = await _context.Presents.FindAsync(request.Id) ?? throw new Exception("Can't find present to edit");

            if (string.IsNullOrWhiteSpace(present.Name))
            {
                throw new Exception("Present name must have value");
            }

            present.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}



