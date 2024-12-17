using API.RequestHelpers;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace API.Controllers;

public class ProductsController(IUnitOfWork unit, IPhotoService photoService) : BaseApiController
{
    [Cache(600)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
        [FromQuery]ProductSpecParams specParams)
    {
        var spec = new ProductSpecification(specParams);

        return await CreatePagedResult(unit.Repository<Product>(), spec, specParams.PageIndex, specParams.PageSize);
    }

    [Cache(600)]
    [HttpGet("{id:int}")] // api/products/2
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [InvalidateCache("api/products")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        unit.Repository<Product>().Add(product);

        if (await unit.Complete())
        {
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        return BadRequest("Problem creating product");
    }

    [InvalidateCache("api/products")]
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (product.Id != id || !ProductExists(id))
            return BadRequest("Cannot update this product");

        unit.Repository<Product>().Update(product);

        if (await unit.Complete())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the product");
    }

    //[InvalidateCache("api/products|")]
    //[Authorize(Roles = "Admin")]
    //[HttpDelete("{id:int}")]
    //public async Task<ActionResult> DeleteProduct(int id)
    //{
    //    var product = await unit.Repository<Product>().GetByIdAsync(id);

    //    if (product == null) return NotFound();

    //    unit.Repository<Product>().Remove(product);

    //    if (await unit.Complete())
    //    {
    //        return NoContent();
    //    }

    //    return BadRequest("Problem deleting the product");
    //}

    [InvalidateCache("api/products")]
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSpecProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);

        if (product == null) return BadRequest("Product not found!");

        var orderItemSpec = new OrderItemSpecification();

        var orderItemLst = await unit.Repository<OrderItem>().ListAsync(orderItemSpec);

        var isSold = orderItemLst.Where(x => x.ItemOrdered.ProductId == id).Any();

        if(isSold) return BadRequest("Cannot delete sold item!");

        unit.Repository<Product>().Remove(product);

        if (await unit.Complete())
        {
            return Ok("Delete successfully");
        }

        return BadRequest("Problem deleting the product");
    }

    [Cache(10000)]
    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var spec = new BrandListSpecification();

        return Ok(await unit.Repository<Product>().ListAsync(spec));
    }

    [Cache(10000)]
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var spec = new TypeListSpecification();

        return Ok(await unit.Repository<Product>().ListAsync(spec));
    }

    [HttpPost("photo")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            // Gọi service upload và nhận kết quả
            var uploadResult = await photoService.AddPhotoAsync(file);

            // Trả về kết quả (secureUrl từ Cloudinary)
            return Ok(new { secureUrl = uploadResult.SecureUrl.ToString() });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading file: " + ex.Message);
        }
    }

    private bool ProductExists(int id)
    {
        return unit.Repository<Product>().Exists(id);
    }
}
