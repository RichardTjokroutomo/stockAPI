using Microsoft.AspNetCore.Mvc;
using StockPortfolio.Models;
using StockPortfolio.Services;

namespace  StockPortfolio.Controller;

[ApiController]
[Route("/")]
public class PortfolioController : ControllerBase{

    // create the interface
    private readonly IPortfolioService _PortfolioService;

    public PortfolioController(IPortfolioService p)
    {
        // TODO, add dependency injection
        _PortfolioService = p;
    }

    // GET
    [HttpGet]
    public async Task<ActionResult<List<Portfolio>>> getAllStocks(){  // the <> inside the actionResult is the return type
        return await _PortfolioService.getAllStocks();  // implied Ok(); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Portfolio>> getOneById(int id){
        Portfolio p = await _PortfolioService.getStock(id);
        if(p == null){
            return NotFound();
        }

        return Ok(p);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> addOne(Portfolio p){  // no need to include the Id, it will add up by itself
        await _PortfolioService.addStock(p);

        return CreatedAtAction( nameof(addOne), new { Id = p.Id}, p); // 1st argument is the url path, nameof(FUNC_NAME), 2nd is the query string
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> modOne(int id, Portfolio p){ // to make this request, must include the stock Id
        if(id != p.Id){
            return BadRequest();
        }

        var existingStock = await _PortfolioService.getStock(p.Id);
        if(existingStock == null){
            return NotFound();
        }

        await _PortfolioService.updateStock(p); 
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> delOne(int id){
        var targetStock = await _PortfolioService.getStock(id);

        if(targetStock == null){
            return NotFound();
        }

        await _PortfolioService.removeStock(id);

        return NoContent();
    }
}