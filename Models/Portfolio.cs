using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace StockPortfolio.Models;

public class Portfolio{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? mongoId{get; set;}   // for the mongo Id

    public int Id{get; set;}
    public string? TickerCode{get; set;}
    public double Price{get; set;}

    public double Quantity {get; set;}
}