using Domain;
using MediatR;
using Persistence;

namespace Application.Presents
{
    public class RegisterChildCommand : IRequest
    {
        public string Name;
        public string Surname;

        public RegisterChildCommand(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    public class CreateChildHandler : IRequestHandler<RegisterChildCommand>
    {
        private readonly DataContext _context;

        public CreateChildHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(RegisterChildCommand request, CancellationToken cancellationToken)
        {
            var child = new Child()
            {
                Id = Guid.NewGuid(),
                Name = string.IsNullOrWhiteSpace(request.Name)
                    ? throw new Exception("Child's name must have value") : request.Name,
                Surname = string.IsNullOrWhiteSpace(request.Surname)
                    ? throw new Exception("Child's name must have value") : request.Surname,
            };

            _context.Add(child);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}



