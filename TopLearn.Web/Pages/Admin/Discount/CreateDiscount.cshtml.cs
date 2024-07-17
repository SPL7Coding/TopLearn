using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Discount
{
    public class CreateDiscountModel : PageModel
    {
        private IOrderService _orderService;

        public CreateDiscountModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        

        [BindProperty]
        public DataLayer.Entities.Order.Discount Discount { get; set; }
        public void OnGet()
        {

        }


        public IActionResult OnPost(string stDate="",string edDate="")
        {
            if (stDate != "")
            {
                string[] std = stDate.Split('/');
                Discount.StartDate=new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                    );
            }

            if (edDate != "")
            {
                string[] edd = edDate.Split('/');
                Discount.EndDate = new DateTime(int.Parse(edd[0]),
                    int.Parse(edd[1]),
                    int.Parse(edd[2]),
                    new PersianCalendar()
                );
            }

            if (!ModelState.IsValid&&_orderService.IsExistCode(Discount.DiscountCode))
                return Page();

            _orderService.AddDiscount(Discount);

            return RedirectToPage("Index");

        }
        //admin/discount/creatediscount?handler=checkcode
        //admin/discount/creatediscount/checkcode
        public IActionResult OnGetCheckCode(string code)
        {
            return Content(_orderService.IsExistCode(code).ToString());
        }
    }
}