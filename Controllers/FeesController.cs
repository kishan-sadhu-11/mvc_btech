using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using Microsoft.EntityFrameworkCore;
using mvc_btech.DBFOLDER;
using mvc_btech.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace mvc_btech.Controllers
{
    public class FeesController : Controller
    {
        private readonly STUDENTDB db;
        private readonly IConfiguration _config;

        public FeesController(STUDENTDB db, IConfiguration config)
        {
            this.db = db;
            _config = config;
        }

        // 🔹 Display all payments
        public async Task<IActionResult> Index()
        {
            var fees = await db.fees.ToListAsync();
            return View(fees);
        }

        // 🔹 Open Payment Page
        public IActionResult Add()
        {
            return View();
        }

        // 🔹 Create Razorpay Order
        [HttpPost]
        public IActionResult CreateOrder(decimal amount)
        {
            try
            {
                string key = _config["Razorpay:Key"];
                string secret = _config["Razorpay:Secret"];

                RazorpayClient client = new RazorpayClient(key, secret);

                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", Convert.ToInt32(amount * 100));
                options.Add("currency", "INR");
                options.Add("receipt", Guid.NewGuid().ToString());

                Order order = client.Order.Create(options);

                return Json(new { orderId = order["id"], key = key });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // 🔹 Payment Success
        [HttpPost]
        public IActionResult PaymentSuccess(string razorpay_payment_id,
                                            string razorpay_order_id,
                                            string razorpay_signature,
                                            decimal amount,
                                            int student_id)
        {
            string secret = _config["Razorpay:Secret"];

            // Signature verification
            string generatedSignature = GenerateSignature(razorpay_order_id + "|" + razorpay_payment_id, secret);

            if (generatedSignature == razorpay_signature)
            {
                FeesModel f = new FeesModel
                {
                    student_id = student_id,
                    total_amount = amount,
                    paid_amount = amount,
                    remaining_amount = 0,
                    payment_date = DateTime.Now
                };

                db.fees.Add(f);
                db.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        private string GenerateSignature(string text, string secret)
        {
            var encoding = new UTF8Encoding();
            byte[] keyBytes = encoding.GetBytes(secret);
            byte[] textBytes = encoding.GetBytes(text);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmac.ComputeHash(textBytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}