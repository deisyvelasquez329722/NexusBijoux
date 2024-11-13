using Microsoft.AspNetCore.Mvc;
using NexusBijoux.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NexusBijoux.Controllers
{
    [ApiController]
    [Route("api/[controller/purchase]")]
    public class PurchaseController : ControllerBase
    {
        private static List<Purchase> purchases = new List<Purchase>();

        [HttpGet]
        public ActionResult<IEnumerable<Purchase>> GetPurchases()
        {
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public ActionResult<Purchase> GetPurchase(int id)
        {
            var purchase = purchases.FirstOrDefault(p => p.Purchase_ID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Purchase>> GetPurchasesByUser(int userId)
        {
            var userPurchases = purchases.Where(p => p.User_ID == userId).ToList();
            return Ok(userPurchases);
        }

        [HttpPost]
        public ActionResult<Purchase> RegisterPurchase(Purchase newPurchase)
        {
            newPurchase.Purchase_ID = purchases.Count > 0 ? purchases.Max(p => p.Purchase_ID) + 1 : 1;
            purchases.Add(newPurchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = newPurchase.Purchase_ID }, newPurchase);
        }
    }
}