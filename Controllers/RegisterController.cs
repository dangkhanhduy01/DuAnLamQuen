using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using DuAnLamQuen.Models;
using System;
using System.IO;

namespace DuAnLamQuen.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IWebHostEnvironment _hosting;

        public RegisterController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XuLy(PersonViewModel m, IFormFile FHinh)
        {
            if (FHinh != null && FHinh.Length > 0)
            {
                string extension = Path.GetExtension(FHinh.FileName).ToLower();

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    string filename = Guid.NewGuid().ToString() + extension;
                    string imageFolder = Path.Combine(_hosting.WebRootPath, "images");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }

                    string fullPath = Path.Combine(imageFolder, filename);

                    try
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            FHinh.CopyTo(stream);
                        }

                        m.Picture = filename; // Gán tên file để hiển thị ở view
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Lỗi khi lưu file: " + ex.Message);
                        return View("Index", m);
                    }
                }
                else
                {
                    ModelState.AddModelError("FHinh", "Chỉ chấp nhận ảnh có định dạng .jpg, .jpeg hoặc .png");
                    return View("Index", m);
                }
            }

            return View(m);
        }
    }
}
