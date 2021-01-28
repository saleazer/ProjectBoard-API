using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScrumLeaderboard.DATA;

namespace ScrumLeaderboard.API.Controllers
{
    [ApiController]
    [Route("BoardItem")]
    public class BoardItemController : ControllerBase
    {
       

        private readonly BoardItemRepository _repository;

        public BoardItemController(BoardItemRepository repository)
        {
            _repository = repository;
        }
                
        [HttpGet("{id}")]
        public string QueryById([FromRoute] int id)
        {
            return JsonConvert.SerializeObject(_repository.QueryById(id));
        }

        [HttpGet("searchByState/{State}")]
        public string QueryByState([FromRoute] string State)
        {
            return JsonConvert.SerializeObject(_repository.QueryByState(State));
        }

        [HttpGet("all")]
        public string QueryAll()
        {
            return JsonConvert.SerializeObject(_repository.QueryAll());
        }

        [HttpPut()]
        public bool Update(BoardItem item)
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
