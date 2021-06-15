using System;

using System.Threading.Tasks;
using ASPNETCore_StoredProcs.Data;
using ASPNETCore_StoredProcs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_StoredProcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesRepository _repository;

        public ValuesController(ValuesRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Value value)
        {
            await _repository.Insert(value);
        }
    }
}
