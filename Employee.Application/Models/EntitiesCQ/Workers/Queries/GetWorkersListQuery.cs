using AutoMapper;
using Employee.Domain.Models.Entity;
using Employee.Domain.Models.Vm;
using Employee.Persistance.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.EntitiesCQ.Workers.Queries
{
    public class GetWorkersListQuery : IRequest<List<WorkersListVm>>
    {
    }
    public class GetWorkersListQueryHandler : IRequestHandler<GetWorkersListQuery, List<WorkersListVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetWorkersListQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkersListVm>> Handle(GetWorkersListQuery request, CancellationToken cancellationToken)
        {
            List<Worker> workers = await _context.Workers.ToListAsync();

            return _mapper.Map<List<WorkersListVm>>(workers);
        }
    }
}
