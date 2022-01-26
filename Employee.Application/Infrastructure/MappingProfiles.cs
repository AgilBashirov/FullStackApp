using AutoMapper;
using Employee.Domain.Models.Dtos.WorkerDto;
using Employee.Domain.Models.Entity;
using Employee.Domain.Models.Vm;

namespace Employee.Application.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Worker, WorkersListVm>()
                .ReverseMap();

            CreateMap<Worker, WorkerDto>()
                .ReverseMap();
        }
    }
}
