using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SBLPIMIDTP.Entity;
using SBLPIMIDTP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBLPIMIDTP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _repository;
        private readonly ILogger<ItemsController> _logger;
        private readonly IConfiguration _config;

        //ItemRepository repository,
        public ItemsController(ILogger<ItemsController> logger, IConfiguration config)
        {
            _repository = new ItemRepository();
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _repository.GetItems();
        }

        [HttpGet]
        public Item GetItemById(Guid id)
        {
            return _repository.GetItemById(id);
        }
    }
}
