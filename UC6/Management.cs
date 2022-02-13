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

        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "------" + list.Count);
            }
        }

        public void RetrieveProductIdAndReview(List<ProductReview> listReview)
        {
            var recordedData = from productReviews in listReview
                               select new
                               {
                                   productReviews.ProductID,
                                   productReviews.Review
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("Product ID:- " + list.ProductID + " " + "Review: " + list.Review);
            }
        }

        public void SkippingTop5Records(List<ProductReview> listReview)
        {
            var recordedData = (from productReviews in listReview
                                select productReviews).Skip(5);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductID + "UserId: " + list.UserID + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.isLike);
            }
        }
    }
}