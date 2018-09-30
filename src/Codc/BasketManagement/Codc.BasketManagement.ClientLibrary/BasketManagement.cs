using Codc.BasketManagement.Application.InputModels;
using Codc.BasketManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Codc.BasketManagement.ClientLibrary
{
    public class BasketManagement
    {
        private const string API_URL = "https://codc-service.azurewebsites.net/api";
        private const decimal API_VERSION = 1.1m;

        private HttpClient httpClient;

        public BasketManagement()
        {
            this.httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            this.httpClient.BaseAddress = new Uri($"{API_URL}/v{API_VERSION}/");
        }

        public async Task AddItem(BasketAddItemInputModel item)
        {
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync("baskets", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateItem(BasketUpdateItemInputModel item)
        {
            HttpResponseMessage response = await this.httpClient.PutAsJsonAsync("baskets", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveItem(int productId)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync($"baskets/products/{productId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task ClearBasket()
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync("baskets");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BasketItem>> View()
        {
            HttpResponseMessage response = await this.httpClient.GetAsync("baskets");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<BasketItem>>();
        }
    }
}
