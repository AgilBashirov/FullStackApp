using AutoMapper;
using Employee.Domain.Models.Entity;
using Employee.Persistance.DataContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Models.EntitiesCQ.Workers.Command
{
    public class CreateWorkerCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, Unit>
    {
        private readonly AppDbContext _context;
        public CreateWorkerCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers.AddAsync(new Worker { Name = request.Name, Surname = request.Surname });

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
