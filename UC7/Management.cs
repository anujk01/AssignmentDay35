using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementWithLinq
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();

        public void RetrieveOnlyProductID(List<ProductReview> productList)
        {
            var recordedData = productList.Select(x => new { ProductId = x.ProductID, Review = x.Review });
            Console.WriteLine("\nProductId and its review using LINQ select:");
            foreach (var v in recordedData)
            {
                Console.WriteLine($"ProductID:{v.ProductId},ReviewCount:{v.Review}");
            }
        }
    }
}