
using StockPortfolio.Models;

namespace StockPortfolio.Services;

public interface IPortfolioService
{
    Task<List<Portfolio>> getAllStocks();  // get all stocks
    Task<Portfolio> getStock(int id); // get 1 specific stock

    Task addStock(Portfolio p); // add a stock to the DB

    Task removeStock(int id); // removes a stock from the DB

    Task updateStock(Portfolio p); // update a stock by Id
}