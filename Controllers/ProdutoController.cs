using APIC.Model;
using Microsoft.AspNetCore.Mvc;
namespace APIC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("Produtos")]
        public IActionResult ConsultarProduto()
        {
            return Ok(new Produto().CarregarProdutos());
        }
        
        [HttpPost("AdProduto")]
        public IActionResult AdProduto(Produto produto)
        {
            return Ok(new Produto().AdProduto(produto));
        }

        [HttpPost("AtualizarProduto")]
        public IActionResult AtualizarProduto(Produto produto)
        {
            return Ok(new Produto().AtualizarProduto(produto));
        }
        [HttpGet("CarregarProdutosPorPreco/{preco}")]
        public IActionResult CarregarProdutorPorPreco(decimal preco)
        {
            return Ok(new Produto().CarregarProdutosPorPreco(preco));
        }

        [HttpGet("CarregarProdutosPorDataExpiracao/{dataExpiracao}")]
        public IActionResult CarregarProdutorPorDataExpiracao(DateTime dataExpiracao)
        {
            return Ok(new Produto().CarregarProdutosPorDataExpiracao(dataExpiracao));
        }

        [HttpGet("CarregarProdutosPorCategoria/{categoria}")]
        public IActionResult CarregarProdutorPorCategoria(string categoria)
        {
            return Ok(new Produto().CarregarProdutosPorCategoria(categoria));
        }

    }
}