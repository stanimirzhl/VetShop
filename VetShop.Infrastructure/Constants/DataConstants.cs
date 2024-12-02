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
            public const int MaxProductDescription = 3000;
        }
        public static class CategoryConstants
        {
            public const int MaxCategoryName = 10;
        }
        public static class BrandConstants
        {
            public const int MaxBrandName = 100;
            public const int MinBrandName = 5;
        }
        public static class VeterinaryConstants
        {
            public const int MinSpecialtyLength = 50;
            public const int MaxSpecialtyLength = 70;
        }
        public static class AppointmentConstants
        {
            public const int MinReasonLength = 100;
            public const int MaxReasonLength = 500;
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
        public enum AppointmentStatus
        {
            Pending,
            Confirmed,
            Waiting,
            Cancelled,
            Completed
        }
        public static class ExceptionMessagesConstants
        {
            public const string BrandNameRequiredMessage = "Field for brand name is required!";
            public const string BrandNameLengthMessage = "Length of field brand name must be between {2} and {1} characters long!";

            public const string ImageUrlRequiredMessage = "Field for image url is required!";

            public const string ImageUrlFormatMessage = "Field for image url is not in the correct format!";

        }
    }
}
