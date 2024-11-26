using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Infrastructure.Constants
{
    public class DataConstants
    {
        public static class UserConstants
        {
            public const int MinUserFirstName = 3;
            public const int MaxUserFirstName = 20;

            public const int MinUserLastName = 3;
            public const int MaxUserLastName = 25;
        }
        public static class CommentConstants
        {
            public const int MinCommentTitle = 5;
            public const int MaxCommentTitle = 100;

            public const int MinCommentDescription = 5;
            public const int MaxCommentDescription = 250;
        }
        public static class ProductConstants
        {
            public const int MinProductTitle = 25;
            public const int MaxProductTitle = 100;

            public const int MinProductDescription = 100;
            public const int MaxProductDescription = 2000;
        }
        public static class CategoryConstants
        {
            public const int MaxCategoryName = 10;
        }
        public static class BrandConstants
        {
            public const int MaxBrandName = 100;
            public const int MinBrandName = 20;
        }
        public enum CommentStatus
        {
            Pending,
            Approved
        }
        public enum OrderStatus
        {
            Pending,
            Sent,
            Delivered,
            Cancelled
        }
    }
}
