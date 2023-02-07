using StockPortfolio.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StockPortfolio.Services;

public class MongoPortfolioService : IPortfolioService {

    private readonly IMongoCollection<Portfolio> _portfolioCollection;

    public MongoPortfolioService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _portfolioCollection = database.GetCollection<Portfolio>(mongoDBSettings.Value.CollectionName);
    }

    // everythin is returned as Task because it is async....



    // READ ALL
    public async Task<List<Portfolio>> getAllStocks(){
        return await _portfolioCollection.Find(portfolio => true).ToListAsync();
        
        // later convert the list to list<portfolio>
    }


    // READ ONE
    public async Task<Portfolio> getStock(int id){
        try{
            Portfolio p = await _portfolioCollection.Find(portfolio => portfolio.Id == id).SingleAsync();
            return p;
        }
        catch{
            return null;   // the desired stock is not found
        }
    } 


    // CREATE
    public async Task addStock(Portfolio p){
        // get the latest id
        List<Portfolio> portfolios = await getAllStocks();
        var index_count = 1;
        foreach(Portfolio portfolio in portfolios){
            index_count += 1;
        }

        // update the portfolio p
        p.Id = index_count;

        // insert the new stock
        await _portfolioCollection.InsertOneAsync(p);

        return;
    } 

    // DELETE
    public async Task removeStock(int id){
        await _portfolioCollection.DeleteOneAsync(portfolio => portfolio.Id == id);

        return;
    } 


    // UPDATE
    public async Task updateStock(Portfolio p){
        // finding 
        Portfolio targetStock = await getStock(p.Id);

        // adding mongo's objectId to p
        p.mongoId = targetStock.mongoId;

        // updating
        var filter = Builders<Portfolio>.Filter.Eq(s => s.Id, p.Id);
        var result = await _portfolioCollection.ReplaceOneAsync(filter, p);

        return;
    } 

}