using AutoMapper;
using DataTransferObjects.Departments;
using DataTransferObjects.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using SalesManager.API.Interfaces;
using System.Data;

namespace SalesManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductGetDTO>>> GetProductsAsync([FromQuery] string value)
        {
            List<Product> products = await _productsService.GetProductAsync(value);

            List<ProductGetDTO> productsGetDTO = _mapper.Map<List<ProductGetDTO>>(products);

            return Ok(productsGetDTO);
        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public async Task<ActionResult<ProductGetDTO>> GetProductsByIdAsync([FromRoute] int productId)
        {
            Product product = await _productsService.GetProductByIdAsync(productId);

            if (product == null)
            {
                return NotFound("Nenhum registro encontrado");
            }

            ProductGetDTO productGetDTO = _mapper.Map<ProductGetDTO>(product);

            return Ok(productGetDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductGetDTO>> PostProductAsync([FromBody] ProductPostDTO productPostDTO)
        {
            if (await _productsService.ExistsByNameAsync(productPostDTO.ProductName))
            {
                return BadRequest($"Já existe um produto com o nome {productPostDTO.ProductName}");
            }

            Product product = _mapper.Map<Product>(productPostDTO);
            await _productsService.InsertAsync(product);

            //ProductGetDTO productGetDTO = new ProductGetDTO();
            //return CreatedAtAction("GetProductById", new { productId = product.Id }, productGetDTO);
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> PutProductAsync([FromBody] ProductPutDTO productPutDTO)
        {
            Product product = await _productsService.GetProductByIdAsync(productPutDTO.Id);

            if (product == null)
            {
                return NotFound($"Nenhum registro encontrado com o id {productPutDTO.Id}");
            }

            if (await _productsService.ExistsByNameUpdateAsync(productPutDTO.ProductName, productPutDTO.Id))
            {
                return BadRequest($"Já existe um produto com o nome {productPutDTO.ProductName}");
            }

            product.ProductName = productPutDTO.ProductName;

            try
            {
                await _productsService.UpdateAsync(product);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest($"Erro interno do sistema: {e.Message}");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<ActionResult> DeleteDepartmentAsync([FromRoute] int productId)
        {
            Product product = await _productsService.GetProductByIdAsync(productId);

            if (product == null)
            {
                return NotFound($"Nenhum registro encontrado com o id {productId}");
            }

            try
            {
                await _productsService.DeleteAsync(product);
            }
            catch (DBConcurrencyException e)
            {
                return BadRequest($"Erro interno do sistema: {e.Message}");
            }

            return NoContent();
        }
    }
}
