using System.Text.Json.Serialization;
using MediatR;
using Persistence;

namespace Application.Presents
{
    public class EditChildCommand : IRequest
    {
        public Guid Id;
        public string Name;
        public string Surname;

        [JsonConstructor]
        public EditChildCommand(Guid id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }

    public class EditChildHandler : IRequestHandler<EditChildCommand>
    {
        private readonly DataContext _context;

        public EditChildHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(EditChildCommand request, CancellationToken cancellationToken)
        {
            var child = await _context.Children.FindAsync(request.Id) ?? throw new Exception("Can't find child to edit");
            child.Name = string.IsNullOrWhiteSpace(request.Name)
                ? throw new Exception("Child's name must have value") : request.Name;
            child.Surname = string.IsNullOrWhiteSpace(request.Surname)
                ? throw new Exception("Child's name must have value") : request.Surname;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}



