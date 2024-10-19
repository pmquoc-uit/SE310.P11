using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using ValiStore.Models;
using ValiStore.Models.ProductModels;

namespace ValiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController(QlbanVaLiContext qlbanVaLiContext) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return qlbanVaLiContext.TDanhMucSps.ToImmutableList()
                .Select(x => new Product
                {
                    MaSp = x.MaSp,
                    TenSp = x.TenSp,
                    MaLoai = x.MaLoai,
                    AnhDaiDien = x.AnhDaiDien,
                    GiaNhoNhat = x.GiaNhoNhat
                }).ToImmutableList();
        }
        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetAllProducts(String maLoai)
        {
            return qlbanVaLiContext.TDanhMucSps.Where(x=>x.MaLoai == maLoai).ToImmutableList()
                .Select(x => new Product
                {
                    MaSp = x.MaSp,
                    TenSp = x.TenSp,
                    MaLoai = x.MaLoai,
                    AnhDaiDien = x.AnhDaiDien,
                    GiaNhoNhat = x.GiaNhoNhat
                }).ToImmutableList();
        }
    }
}
