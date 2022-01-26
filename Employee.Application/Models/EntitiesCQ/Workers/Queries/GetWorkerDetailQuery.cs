using AutoMapper;
using Employee.Domain.Models.Vm;
using Employee.Persistance.DataContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Models.EntitiesCQ.Workers.Queries
{
    public class GetWorkerDetailQuery : IRequest<WorkersListVm>
    {
        public int Id { get; set; }
    }
    public class GetWorkersListQueryHandler : IRequestHandler<GetWorkerDetailQuery, WorkersListVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetWorkersListQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkersListVm> Handle(GetWorkerDetailQuery request, CancellationToken cancellationToken)
        {
            var workers = await _context.Workers.FindAsync(request.Id);

            return _mapper.Map<WorkersListVm>(workers);
        }
    }
}
