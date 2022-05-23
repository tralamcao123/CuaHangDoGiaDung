using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangDoGiaDung.Models
{
    public class DoGiaDung
    {
        public int Id { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string Title { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public string Genre { get; set; }
        [Display(Name = "Giá Sản Phẩm")]
        public decimal Price { get; set; }
        

    }
}
