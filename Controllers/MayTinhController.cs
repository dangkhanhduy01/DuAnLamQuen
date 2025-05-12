using DuAnLamQuen.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuAnLamQuen.Controllers
{
    public class MayTinhController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult XuLy()
        //{
        //    //lay gia tri tham so tu client
        //    int so1 = int.Parse(Request.Form["so1"]);
        //    int so2 = int.Parse(Request.Form["so2"]);
        //    string pheptinh = Request.Form["pheptinh"];
        //    //xu ly
        //    int kq = 0;
        //    switch (pheptinh)
        //    {
        //        case "+": kq = so1 + so2; break;
        //        case "-": kq = so1 - so2; break;
        //        case "*": kq = so1 * so2; break;
        //        case "/": kq = so1 / so2; break;
        //    }
        //    ViewBag.kq = kq; //truyen du lieu cho view bang ViewBag
        //    return View("Ket Qua");
        //}

        //public IActionResult XuLy(int so1, int so2, string pheptinh)
        //{
        //    //lay gia tri tham so tu client
        //    //int so1 = int.Parse(Request.Form["so1"]);
        //    //int so2 = int.Parse(Request.Form["so2"]);
        //    //string pheptinh = Request.Form["pheptinh"];
        //    //xu ly
        //    int kq = 0;
        //    switch (pheptinh)
        //    {
        //        case "+": kq = so1 + so2; break;
        //        case "-": kq = so1 - so2; break;
        //        case "*": kq = so1 * so2; break;
        //        case "/": kq = so1 / so2; break;
        //    }
        //    ViewBag.KQ = kq; //truyen du lieu cho view bang ViewBag
        //    return View("Ket Qua");
        //}

        public IActionResult XuLy(MayTinhModel m)
        {
            //lay gia tri tham so tu client
            //int so1 = int.Parse(Request.Form["so1"]);
            //int so2 = int.Parse(Request.Form["so2"]);
            //string pheptinh = Request.Form["pheptinh"];
            //xu ly
            double kq = 0;
            switch (m.PhepTinh)
            {
                case "+": kq = m.so1 + m.so2; break;
                case "-": kq = m.so1 - m.so2; break;
                case "*": kq = m.so1 * m.so2; break;
                case "/": kq = m.so1 / m.so2; break;
            }
            ViewBag.KQ = kq; //truyen du lieu cho view bang ViewBag
            return View("Index", m); // Trả lại cùng View Index và giữ giá trị người dùng đã nhập
        }

    }
}