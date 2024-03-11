using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redisCache;
        private readonly IConnectionMultiplexer _redisConnection;

        public BasketRepository(IConnectionMultiplexer redisConnection)
        {


            //_redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _redisConnection = redisConnection;
            _redisCache = _redisConnection.GetDatabase();
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.StringGetAsync(userName);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            await _redisCache.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            //await _redisCache.RemoveAsync(userName);
            await _redisCache.KeyDeleteAsync(userName);
        }
    }
}