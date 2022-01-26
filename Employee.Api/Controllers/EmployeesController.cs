using Employee.Application.EntitiesCQ.Workers.Queries;
using Employee.Application.Models.EntitiesCQ.Workers.Command;
using Employee.Application.Models.EntitiesCQ.Workers.Queries;
using Employee.Domain.Models.Dtos.WorkerDto;
using Employee.Domain.Models.Entity;
using Employee.Persistance.DataContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public EmployeesController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetWorkersListQuery query = new GetWorkersListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetWorkerDetailQuery { Id = id});
            return Ok(result);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post(WorkerDto response)
        {
            return Ok(await _mediator.Send(new CreateWorkerCommand { Name = response.Name, Surname = response.Surname }));
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, WorkerDto response)
        {
            return Ok(await _mediator.Send(new UpdateWorkerCommand { Id = id, Worker = response }));
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWorkerCommand { Id = id }));
        }
    }
}
