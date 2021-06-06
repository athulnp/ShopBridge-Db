using Microsoft.AspNetCore.Mvc;
using ShopBridge.Site.Models;
using ShopBridge.Site.Services;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [Route("Upsert")]
        [HttpPost]
        public async Task<IActionResult> UpsertInventory(Inventory inventory)
        {
            var response = await _inventoryService.UpsertInventory(inventory);
            return Ok(response);
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetListInventory()
        {
            var response = await _inventoryService.GetInventoryList();
            return Ok(response);
        }

        [Route("details")]
        [HttpGet]
        public async Task<IActionResult> GetListInventory(long id)
        {
            var response = await _inventoryService.GetInventoryDetails(id);
            return Ok(response);
        }
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInventory(long id)
        {
            var response = await _inventoryService.DeleteInventory(id);
            return Ok(response);
        }
    }
}
