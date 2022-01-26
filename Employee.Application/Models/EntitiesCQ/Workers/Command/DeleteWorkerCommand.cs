using AutoMapper;
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
    public class DeleteWorkerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, Unit>
    {
        private readonly AppDbContext _context;

        public DeleteWorkerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers.FindAsync(request.Id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
