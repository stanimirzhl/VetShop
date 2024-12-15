using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetShop.Core;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using VetShop.Models.Order;

namespace VetShop.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        private ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            var orders = await orderService.GetAllAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var mappedOrders = orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                Status = x.Status,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
            });

            return View(mappedOrders);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var order = await orderService.GetByIdAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));

                var orderModel = new OrderViewModel()
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalPrice = order.TotalPrice,
                    UserId = order.UserId,
                    OrderItems = order.OrderItems.Select(x => new OrderItemViewModel
                    {
                        ProductName = x.ProductName,
                        ProductPrice = x.ProductPrice,
                        Quantity = x.Quantity,
                        ImageUrl = x.ImageUrl,
                    }).ToList()
                };

                return View(orderModel);
            }
            catch (NonExistentEntity ex) 
            {
                return NotFound();
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> ViewOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = await orderService.GetOrCreateOrderAsync(userId);

            var orderModel = new OrderViewModel()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(x => new OrderItemViewModel
                {
                    ProductName = x.Product.Title,
                    ProductPrice = x.Product.Price,
                    Quantity = x.Quantity,
                    ImageUrl = x.Product.ImageUrl,
                    Id = x.Id
                }).ToList()
            };

            return View(orderModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveItem(int orderItemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await orderService.RemoveOrderItemAsync(userId, orderItemId);

            return RedirectToAction("ViewOrder");
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = await orderService.CompleteOrderAsync(userId);

            if (success)
            {
                TempData["SuccessMessage"] = "Order completed successfully!";
                return RedirectToAction("All");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to complete the order. Please try again.";
                return RedirectToAction("ViewOrder");
            }
        }
    }
}
