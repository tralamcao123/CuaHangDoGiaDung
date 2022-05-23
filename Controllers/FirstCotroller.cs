using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangDoGiaDung.Controllers
{
    public class FirstCotroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
