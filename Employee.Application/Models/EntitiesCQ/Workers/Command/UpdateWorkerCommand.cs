using AutoMapper;
using Employee.Domain.Models.Dtos.WorkerDto;
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
    public class UpdateWorkerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public WorkerDto Worker { get; set; }
    }
    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateWorkerCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers.FindAsync(request.Id);
            _context.Workers.Update(_mapper.Map(request.Worker, worker));
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
