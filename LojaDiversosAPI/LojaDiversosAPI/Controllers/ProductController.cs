using LojaDiversosAPI.Domains;
using LojaDiversosAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LojaDiversosAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;
        public string Message { get; set; }

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        protected void Logs(Exception ex)
        {
            _logger.LogInformation($"Houve um erro: {ex.Message}.");
            System.Console.WriteLine($"Houve um erro: {ex.Message}.");
        }

        /// <summary>
        /// Lista todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-products/")]
        public IActionResult GetAllProducts()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var product = _productRepository.Listar();

                if (product.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    _logger.LogInformation($"Listagem de produtos realizada");
                    System.Console.WriteLine($"Listagem de produtos realizada");

                    return Ok(new
                    {
                        Total  = product.Count,
                        Data = product
                    });

                }
            }

        }

        [HttpGet("search-product/{id}")]
        public IActionResult GetProductById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Product product = _productRepository.BuscarPorId(id);

                if (product == null)
                {
                    return NoContent();
                }
                else
                {
                    _logger.LogInformation($"O produto com {id} foi encontrado");
                    System.Console.WriteLine($"O produto com {id} foi encontrado");

                    return Ok(product);
                }
            }

        }

        [HttpPost("add-product/")]
        public IActionResult AddProduct([FromBody] Product product)
        {

            try
            {
                if (product == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _productRepository.Adicionar(product);

                _logger.LogInformation($"O produto foi criado com sucesso");
                System.Console.WriteLine($"O produto foi criado com sucesso");

                return Ok(product);
            }
            catch (Exception ex)
            {
                Logs(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, product);
            }

        }

        [HttpPut("edit-product/{id}")]
        public IActionResult EditProduct(Guid id, [FromBody] Product product)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _productRepository.Editar(id, product);

                _logger.LogInformation($"O produto {id} foi alterado");
                System.Console.WriteLine($"O produto {id} foi alterado");

                return Ok(product);
            }
            catch (Exception ex)
            {
                Logs(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, product);

            }
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {

            try
            {
                Product product = _productRepository.BuscarPorId(id);

                if (product == null)
                {
                    return NoContent();
                }
                else
                {
                    _productRepository.Remover(id);

                    _logger.LogInformation($"O produto {id} foi removido");
                    System.Console.WriteLine($"O produto {id} foi removido");

                    return Ok(product);
                };

            }
            catch (Exception ex)
            {
                Logs(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("buy-product/{id}")]
        public IActionResult Buy(Guid id, int availableQuantity)
        {
            try
            {
                _productRepository.Comprar(id, availableQuantity);

                _logger.LogInformation($"Compra realizada");
                System.Console.WriteLine($"Compra realizada");

                return Ok(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}