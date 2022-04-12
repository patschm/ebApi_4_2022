using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Microsoft.AspNetCore.Mvc.Testing;
using ProductReviews.Interfaces;
using ProductReviews.Repositories.EntityFramework;

namespace ProductReviews.Repositories.Tests.Integration
{
    public class ProductGroupRequestTests 
    {
        [Fact]
        public async Task GetPaged()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        //services.AddTransient<IProductGroupRepository, ProductGroupRepository>();
                    });
                });
            var client = application.CreateClient();
            // etc
        } 
    }
}