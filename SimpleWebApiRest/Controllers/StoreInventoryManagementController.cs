﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("Create New Item")]
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
        [HttpGet("Get All Items")]
        public ActionResult<RpgInventoryItem> GetAllItems()
        {
            try
            {
                List<RpgInventoryItem> listOfAllItems = new List<RpgInventoryItem>();
                listOfAllItems = _rpgItemStoreService.GetAllItems();
                return Ok(listOfAllItems);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // GET api/<StoreInventoryManagementController>/5
        [HttpGet("Get Item by Id Number")]
        public IActionResult Get(int id)
        {
            try
            {
                RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                rpgInventoryItem = _rpgItemStoreService.GetItemByIdNumber(id);
                return Ok(rpgInventoryItem);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
           
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
