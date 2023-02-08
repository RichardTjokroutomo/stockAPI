// no longer needed, this is the Model that I used when I only use local cache as storage

using StockPortfolio.Models;

namespace StockPortfolio.Services;

public class PortfolioService {  // for now, we wont be using the interface
    static List<Portfolio> Portfolios {get;}
    static int highestId = 0;

    static PortfolioService(){
        Portfolios = new List<Portfolio>
        {
            new Portfolio{Id = 1, TickerCode = "AAPL", Price = 100, Quantity = 90},
            new Portfolio{Id = 2, TickerCode = "TSLA", Price = 150, Quantity = 50}
        };
        highestId += 2;
    }

    // return all stocks in hand
    public List<Portfolio> getAllStocks(){
        return Portfolios;
    }

    // return a specific stock
    public Portfolio getStock(int id){
        Portfolio stock = null;
        foreach(var portfolio in Portfolios){
            if(id == portfolio.Id){
                stock = portfolio;
            }
        }

        return stock;
    }

    // add a stock
    public void addStock(Portfolio p){
        highestId += 1;
        p.Id = highestId;
        Portfolios.Add(p);
    }

    // remove a stock
    public void removeStock(int id){
         var stock = getStock(id);
         if(stock is null)
             return;

         Portfolios.Remove(stock);
    }

    // update a stock
    public void updateStock(Portfolio p){

        var index = Portfolios.FindIndex(stock => stock.Id == p.Id);
        if(index == -1)
            return;

        Portfolios[index] = p;
    }
}