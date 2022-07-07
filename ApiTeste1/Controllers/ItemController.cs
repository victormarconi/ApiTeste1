using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private static List<Produtos> Itens = new List<Produtos>
            {
                new Produtos {
                    Id = 1,
                    Descricao = "Tenis Adidas bla bla bla",
                    NomeItem = "Tenis Adidas Society",
                    Local = "Manaira Shopping"
                },
                new Produtos {
                    Id = 2,
                    Descricao = "Sandalia Havaiana bla bla bla",
                    NomeItem = "Sandalia Havaiana",
                    Local = "Mangabeira Shopping"
                }
            };
        private readonly DataContext context;

        public ProdutosController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> Get()
        {
            return Ok(await this.context.Produtos1.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> Get(int id)
        {
            var item = await this.context.Produtos1.FindAsync(id);
            if (item == null)
                return BadRequest("Item não encontrado");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Produtos>>> AddItem(Produtos item)
        {
            this.context.Produtos1.Add(item);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Produtos1.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Produtos>>> UpdateItem(Produtos request)
        {
            var dbitem = Itens.Find(i => i.Id == request.Id);
            if (dbitem == null)
                return BadRequest("Item não encontrado");

            dbitem.Descricao = request.Descricao;
            dbitem.NomeItem = request.NomeItem;
            dbitem.Local = request.Local;

            await this.context.SaveChangesAsync();
                        
            return Ok(await this.context.Produtos1.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Produtos>>> Delete(int id)
        {
            var item = Itens.Find(i => i.Id == id);
            if (item == null)
                return BadRequest("Item não encontrado");

            this.context.Produtos1.Remove(item);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.Produtos1.ToListAsync());
        }

    }
}
