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

            public const int MinUsersName = 4;
            public const int MaxUsersName = 20;
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

            public const string MinProductPrice = "1";
            public const string MaxProductPrice = "4999";

            public const int MinProductQuantity = 1;
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
            public const int MinReasonLength = 20;
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
            Delivered
        }
        public enum AppointmentStatus
        {
            Pending,
            Confirmed,
            Cancelled
        }
        public static class ExceptionMessagesConstants
        {
            public const string BrandNameRequiredMessage = "Field for brand name is required!";
            public const string BrandNameLengthMessage = "Length of field brand name must be between {2} and {1} characters long!";

            public const string ImageUrlRequiredMessage = "Field for image url is required!";

            public const string ImageUrlFormatMessage = "Field for image url is not in the correct format!";

            public const string ProductTitleRequiredMessage = "Field for product title is required!";
            public const string ProductTitleLengthMessage = "Length of field product title must be between {2} and {1} characters long!";

            public const string ProductPriceRequiredMessage = "Field for product price is required!";
            public const string ProductPriceLengthMessage = "Field for product price must be between {2} and {1}!";

            public const string ProductDescriptionRequiredMessage = "Field for product description is required!";
            public const string ProductDescriptionLengthMessage = "Length of field brand description must be between {2} and {1} characters long!";

            public const string ProductCategoryIdRequiredMessage = "Field for product category is required!";
            public const string ProductBrandIdRequiredMessage = "Field for product brand is required!";

            public const string ProductQuantityRequiredMessage = "Field for product quantity is required!";

            public const string ProductQuantityMessage = "Field for product quantity cannot be below or 0";

            public const string UserFirstNameMessage = "Field for User first name is required!";
            public const string UserLastNameMessage = "Field for User last name is required!";
            public const string UsersUserNameMessage = "Field for User name is required!";

            public const string UserFirstNameLegnthMessage = "Length of field first name must be between {2} and {1} characters long!";
            public const string UserLastNameLegnthMessage = "Length of field last name must be between {2} and {1} characters long!";
            public const string UsersUserNameLegnthMessage = "Length of field user name must be between {2} and {1} characters long!";

            public const string CommentTitleRequiredMessage = "Field for Comment title is required!";
            public const string CommentTitleLengthMessage = "Length of field Comment title must be between {2} and {1} characters long!";

            public const string CommentDescriptionRequiredMessage = "Field for Comment description is required!";
            public const string CommentDescriptionLengthMessage = "Length of field Comment description must be between {2} and {1} characters long!";

            public const string AppointmentRequiredMessage = "Field for Appointment reason is required!";
            public const string AppointReasonLengthMessage = "Length of field Appoint reason must be between {2} and {1} characters long!";
            public const string AppointmentDateRequiredMessage = "Field for Appointment Date is required!";
        }
    }
}
