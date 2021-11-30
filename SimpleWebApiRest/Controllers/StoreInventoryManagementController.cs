using Microsoft.AspNetCore.Mvc;
using StoreInventoryManagement.Domain;
using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.ModelMappers;
using StoreInventoryManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreInventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreInventoryManagementController : ControllerBase
    {
        private readonly IRpgItemStoreService _rpgItemStoreService;
        private readonly IRpgInventoryItemJsonMapper _mapper;
        //private readonly IRpgInventoryItem _rpgInventoryItem;
        public StoreInventoryManagementController(IRpgItemStoreService rpgItemStoreService, IRpgInventoryItemJsonMapper mapper)
        {
            _rpgItemStoreService = rpgItemStoreService;
            _mapper = mapper;
            //_rpgInventoryItem = rpgInventoryItem;

        }

        
        // POST api/<StoreInventoryManagementController>
        [HttpPost("Create new Item")]
        public IActionResult CreateNewItem (RpgInventoryItemJson rpgInventoryItemJson)
        {
            try
            {
                TryValidateModel(rpgInventoryItemJson);

                    if(ModelState.IsValid)
                {
                    RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                    rpgInventoryItem = _mapper.RpgInventoryItemMapper(rpgInventoryItemJson);
                    rpgInventoryItem = _rpgItemStoreService.CreateItem(rpgInventoryItem);
                    return Ok(rpgInventoryItem);
                }
                else
                {
                    return BadRequest(rpgInventoryItemJson);
                }

            }
            catch (Exception e)
            {
                               
                return StatusCode(400, e.Message);
            }
        }

        // GET: api/<StoreInventoryManagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StoreInventoryManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<StoreInventoryManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreInventoryManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
