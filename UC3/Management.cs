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

        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductID + "Userid: " + list.UserID + " Rating: " + list.Rating + "Review: " + list.Review + "isLike: " + list.isLike);

            }
        }
        
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData = from productReviews in listProductReview
                             where (productReviews.ProductID == 1 && productReviews.Rating > 3) ||
                             (productReviews.ProductID == 4 && productReviews.Rating > 3 ) ||
                             (productReviews.ProductID == 9 && productReviews.Rating > 3)
                             select productReviews;
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID: " + list.ProductID + "Userid: " + list.UserID + " Rating: " + list.Rating + "Review: " + list.Review + "isLike: " + list.isLike);

            }
        }
    }
}
