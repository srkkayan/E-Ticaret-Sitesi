using CompeiaSiparis.Data.Repository.IRepository;
using CompeiaSiparis.Models;
using CompeiaSiparis.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompeiaSiparis.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;          
        }

        public IActionResult Index()
        {
            var orderList = _unitOfWork.OrderProduct.GetAll(x=>x.OrderStatus != "Teslim Edildi");
            return View(orderList);
        }


        public IActionResult Details(int orderId)
        {
            OrderVM = new OrderVM
            {
                OrderProduct = _unitOfWork.OrderProduct.GetFirstOrDefault(o=>o.Id == orderId, includeProperties:"AppUser"),
                OrderDetails = _unitOfWork.OrderDetails.GetAll(d=>d.OrderProductId == orderId, includeProperties:"Product")
            };
            return View(OrderVM);

        }


    }
}
