﻿using CompeiaSiparis.Data.Repository.IRepository;
using CompeiaSiparis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompeiaSiparis.Areas.Customer.Controllers
{
    [Area("Customer")]
    
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderProduct> orderProduct;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            orderProduct = _unitOfWork.OrderProduct.GetAll(u=>u.AppUserId == claim.Value);

            return View(orderProduct);
        }


        public IActionResult CancelOrder(int id)
        {
            var order = _unitOfWork.OrderProduct.GetFirstOrDefault(x=>x.Id == id);

            if (order.OrderStatus == "Ordered") order.OrderStatus = "Cancel";
            
                _unitOfWork.OrderProduct.Update(order);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

    }
}
