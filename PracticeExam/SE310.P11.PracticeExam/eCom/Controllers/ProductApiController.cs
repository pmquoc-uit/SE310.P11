using eCom.Models;
using eCom.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace eCom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController(EComContext qlbanVaLiContext) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return qlbanVaLiContext.SanPhams.ToImmutableList()
                .Select((x) => new Product
                {
                    MaSp = x.MaSp!,
                    TenSp = x.TenSp,
                    MaLoai = x.MaLoai,
                    AnhDaiDien = x.AnhSp,
                    GiaNhoNhat = x.GiaSp
                }).ToImmutableList();
        }
        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetAllProducts(String maLoai)
        {
            Console.WriteLine(maLoai);
            return qlbanVaLiContext.SanPhams.Where((x) => x.MaLoai == maLoai).ToImmutableList()
                .Select((x) => new Product
                {
                    MaSp = x.MaSp!,
                    TenSp = x.TenSp,
                    MaLoai = x.MaLoai,
                    AnhDaiDien = x.AnhSp,
                    GiaNhoNhat = x.GiaSp
                }).ToImmutableList();
        }
    }
}
