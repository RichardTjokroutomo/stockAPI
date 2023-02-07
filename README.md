# Stock API

 stock API allows users to store their stock portfolio in MongoAtlas. It is designed for any client who needs data on their stock portfolio to be displayed on the front-end side (but you still need to host it somewhere)

## Description

The purpose of this project is for me to learn and practice:
> - ASP.NET webAPI (version 7.0.102)
> - MVC Architectural pattern
> - Dependency injection design patterns
> - Designing RESTFUL APIs, along with proper HTTP responses for each requests.
> - C#

Here are the commands available to the user:

![API Commands][commandsLink]

A sample output from HTTP GET /:
> ```
> [
>     {
>         "mongoId": "63c7e977af3626a9af2cb412",
>         "id": 1,
>         "tickerCode": "MSFT",
>         "price": 690,
>         "quantity": 6900
>     },
>     {
>         "mongoId": "63c8d317e9d4734edc9f471f",
>         "id": 2,
>         "tickerCode": "TSLA",
>         "price": 200,
>         "quantity": 2500
>     }
> ]
> ```

for POST and PUT request, the user is required to put a JSON file in the HTTP body. The format is as follows:
> ```
> {
>     "tickerCode": STOCK_TICKER_CODE,
>     "price": PRICE_OF_THE_STOCK,
>     "quantity": QUANTITY
> }
> ```
>> - STOCK_TICKER_CODE is string
>> - PRICE_OF_THE_STOCK is double
>> - QUANTITY is double




## Demo
Due to my inability to find a site to host the API for free (I am not eligible for Azure student account and their free trial for some reason), Here is a link for the [video demo](https://cuhko365-my.sharepoint.com/:v:/g/personal/121040003_link_cuhk_edu_cn/EcWBTnU_q1pOph2sxlsVm7oBdJNK3KilhLa6UDWcHXOMcw?e=jirNF1)


## Setup
to run this code yourself locally:
> 1) make sure you have ASP.NET version 7.0.102 installed
> 2) clone this repository
> 3) in the appsettings.json, change the `"ConnectionURI"` to your mongoAtlas URL link
> 4) in your command prompt, `cd` into the file directory and use the command `dotnet run`




[commandsLink]:{https://github.com/[RichardTjokroutomo]/[stockAPI]/images/APIcommands.jpg?raw=true}