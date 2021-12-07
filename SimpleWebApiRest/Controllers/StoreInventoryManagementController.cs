using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreInventoryManagement.Domain;
using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.ModelMappers;
using StoreInventoryManagement.Domain.Models;
using System;
using System.Collections.Generic;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Create New Item")]
        public IActionResult CreateNewItem(RpgInventoryItemJson rpgInventoryItemJson)
        {
            try
            {
                TryValidateModel(rpgInventoryItemJson);

                if (ModelState.IsValid)
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

                return StatusCode(500, e.Message);
            }
        }

        // GET: api/<StoreInventoryManagementController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Get Item by Id Number - guid")]
        public IActionResult Get(string id)
        {
            try
            {
                if (id.Length == 36)
                {
                    RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                    rpgInventoryItem = _rpgItemStoreService.GetItemByIdNumber(id);
                    return Ok(rpgInventoryItem);
                }

                else
                {
                    ArgumentException e = new ArgumentException();
                    return BadRequest(e.Message);//invalid Id personalized ex.Message
                }

            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<StoreInventoryManagementController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("Update Item Description by Id Number - guid")]
        public IActionResult UpdateItemDescription(string id, string newValue)
        {
            try
            {
                RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                rpgInventoryItem = _rpgItemStoreService.UpdateItemDescription(id, newValue);
                return Ok(rpgInventoryItem);
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update fields by Id Number - guid. Fields - NAME, DESCRIPTION, BUYPRICE, RARITY, ISKEYITEM")]
        public IActionResult UpdateItemfield(string id, string field, string newValue)
        {
            try
            {
                string[] arrOfOptions = new string[] { "name", "description", "buyprice", "rarity", "iskeyitem" };
                bool isValidOption = false;

                foreach (string option in arrOfOptions)
                {
                    if (option.ToUpper() != field.ToUpper())
                    {
                        isValidOption = false;
                    }
                    else
                    {
                        isValidOption = true;
                        break;
                    }

                }

                if (field.ToUpper() == "BUYPRICE" && decimal.Parse(newValue) < 0) { isValidOption = false; }

                if (!isValidOption)
                {
                    throw new ArgumentException("Property to be changedd must be one of the " +
                                       "specified values for 'field'. BuyPrice must be equal or greater than 0");
                }

                RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                rpgInventoryItem = _rpgItemStoreService.UpdateItemField(id, field, newValue);
                return Ok(rpgInventoryItem);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<StoreInventoryManagementController>/5
        [HttpDelete("Delete an Item by its Id Number - guid")]
        public IActionResult Delete(string id)
        {
            try
            {
                RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
                rpgInventoryItem = _rpgItemStoreService.DeleteItem(id);
                return Ok(rpgInventoryItem);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
