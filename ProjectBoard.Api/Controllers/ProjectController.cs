using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBoard.Data;
using Newtonsoft.Json;

namespace ProjectBoard.API.Controllers
{
    [ApiController]
    [Route("Project")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _repository;

        public ProjectController(ProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public string QueryById([FromRoute] int id)
        {
            return JsonConvert.SerializeObject(_repository.QueryById(id));
        }

        [HttpGet("searchByName/{Name}")]
        public string QueryByName([FromRoute] string Name)
        {
            return JsonConvert.SerializeObject(_repository.QueryByName(Name));
        }

        [HttpGet("searchByCreator/{Creator}")]
        public string QueryByCreator([FromRoute] string Creator)
        {
            return JsonConvert.SerializeObject(_repository.QueryByCreator(Creator));
        }

        [HttpGet("all")]
        public string QueryAll()
        {
            return JsonConvert.SerializeObject(_repository.QueryAll());
        }

        [HttpPut()]
        public bool Update(Project item)
        {
            return _repository.AddOrUpdate(item);
        }

        [HttpDelete("{id}")]
        public bool Delete([FromRoute] int id)
        {
            return _repository.DeleteById(id);
        }


    }
}
