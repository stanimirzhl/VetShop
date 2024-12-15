using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "Pate for Cats",
                    Description = "Complete and balanced food with minerals and vitamins, made with fresh ingredients for superior taste and natural nutrition. Grain-free." +
                    "\r\n\r\nSpecial Cat GOLD Pâté for Kittens with Chicken: From weaning to around 12 months or until neutering. Suitable for pregnant and nursing mothers." +
                    "\r\n\r\nIngredients: Fresh chicken meat and meat products (45%), plant-based products, minerals. Additives: Vitamins, provitamins, and similar substances: Vitamin A 2,000 i.u./kg, Vitamin D3 200 i.u./kg, Vitamin E 20 i.u./kg, Manganese (Manganese sulfate monohydrate) 5.0mg/kg, Selenium (Sodium selenite) 0.04mg/kg, Iodine (Calcium iodate) 0.50mg/kg, Taurine 500mg/kg. Trace elements: Zinc (Zinc sulfate monohydrate) 10.0mg/kg." +
                    "\r\n\r\nFeeding Guide: Feed 1/4 of the can for every 3 months of kitten's age. Adjust the amount of food based on activity level and body condition. Serve at room temperature. Always provide fresh drinking water. Storage: Store unopened cans in a dry, cool place. After opening, store in an airtight container in the fridge and use within 72 hours.\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Turkey: Ingredients: Fresh meat and meat products (35%), fresh turkey (min. 4%), plant-based products, minerals." +
                    "\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Beef: Ingredients: Fresh meat and meat products (35%), fresh beef (min. 4%), plant-based products, minerals." +
                    "\r\n\r\nSpecial Cat GOLD Pâté for Adult Cats (1+ years) with Lamb: Ingredients: Fresh meat and meat products (35%), fresh lamb (min. 4%), plant-based products, minerals." +
                    "\r\n\r\nSpecial Cat GOLD Pâté for Neutered Cats (1+ years) with Salmon: Ingredients: Fresh meat and meat products (31%), fresh salmon (min. 8%), plant-based products, minerals." +
                    "\r\n\r\nAdditives: Vitamins, provitamins, and similar substances: Vitamin A 1,000 i.u./kg, Vitamin D3 100 i.u./kg, Vitamin E 10 i.u./kg, Manganese (Manganese sulfate monohydrate) 2.5mg/kg, Selenium (Sodium selenite) 0.02mg/kg, Iodine (Calcium iodate) 0.25mg/kg, Taurine 250mg/kg. Trace elements: Zinc (Zinc sulfate monohydrate) 5.0mg/kg.\r\n\r\nAnalytical Composition: Crude protein 8.0%, Crude fat 5.0%, Crude fiber 0.2%, Crude ash 2.0%, Moisture 82%.\r\n\r\nFeeding Guide: Feed 1 can (400g) per 5kg cat per 24 hours. Adjust the amount of food based on activity level and body condition. Serve at room temperature. Always provide fresh drinking water. Storage: Store unopened cans in a dry, cool place. After opening, store in an airtight container in the fridge and use within 72 hours." +
                    "\r\n\r\nMade in Turkey.",
                    CategoryId = 1,
                    BrandId = 12,
                    ImageUrl = "https://m.media-amazon.com/images/I/61ccbUsZsdL._AC_SL1000_.jpg",
                    Price = 15.56m,
                    Quantity = 54
                },
                new Product()
                {
                    Id = 2,
                    Title = "Cat Can Ocean Fish, Chicken",
                    Description = "Cat Can Ocean Fish & Chicken - 3.74 kg (Transparent)" +
                    "\r\n\r\nTreat your cat to a nutritious and flavorful meal with Cat Can Ocean Fish & Chicken. This premium cat food combines the delicious taste of ocean fish and tender chicken to provide your feline friend with a balanced diet that supports overall health. With a generous 3.74 kg weight, this large pack is perfect for cat owners looking for a cost-effective and high-quality option to keep their pets satisfied." +
                    "\r\n\r\nFormulated with high-quality proteins, this formula supports your cat's lean muscle development and energy levels, while promoting a shiny coat and healthy skin. The recipe is enriched with essential vitamins and minerals, ensuring your cat receives all the nutrients it needs for optimal well-being.\r\n\r\nPackaged in a transparent can, this product showcases the quality and freshness of the ingredients, giving you peace of mind that your cat is enjoying a wholesome meal. Perfect for cats of all ages, Cat Can Ocean Fish & Chicken is the ideal choice for a delicious, healthy, and satisfying meal." +
                    "\r\n\r\nKey Features:\r\n\r\n    Flavorful Blend: Made with a combination of ocean fish and chicken for a taste cats love.\r\n    High-Quality Protein: Supports lean muscle development and provides essential energy.\r\n    Essential Nutrients: Packed with vitamins and minerals for a healthy, balanced diet.\r\n    Transparent Packaging: Clear can design ensures product quality and freshness.\r\n    Large Size: 3.74 kg pack, ideal for multi-cat households or long-term feeding.\r\n\r\nFeeding Guidelines: Adjust portion sizes based on your cat's weight and activity level. Always provide fresh water alongside meals." +
                    "\r\n\r\nGive your cat the best with Cat Can Ocean Fish & Chicken—the perfect meal for a happy, healthy feline!",
                    CategoryId = 1,
                    BrandId = 11,
                    ImageUrl = "https://m.media-amazon.com/images/I/71dsU3Y0hRL._AC_SL1500_.jpg",
                    Price = 5.99m,
                    Quantity = 100
                },
                new Product()
                {
                    Id = 3,
                    Title = "Automatic Cat Feeder - Cat Feeder with 1-6 Meals",
                    Description = "Saves Time, More Moments Together: With the automatic cat feeder, my mom no longer has to open the cat food container every time to refill my bowl. She just watches me eat, and I love that it gives her more time to be with me. I get my meals on time, ensuring I’m never hungry, and my food stays fresh and crispy, unlike the old bowls where my food would sit too long. Before, when my mom came home late, I’d often go hungry. Now, I’m fed and happy!" +
                    "\r\n\r\nDouble Lock Design, No Spills: When mom’s out, I’m busy guarding the house. I run around excitedly, sometimes bumping into the feeder, but thanks to its double-lock design, the food stays in place. No more mess for mom to clean up, and I can stay focused on my duties without worrying about spilled food.\r\n\r\n10s Voice Message, Mom’s Call: One of my favorite features is the ability to hear my mom’s voice before I eat! The automatic feeder can record a 10-second personalized message, so when it’s time for me to eat, I hear her say, “Baby, come eat!” I always run over immediately because I love hearing her voice, and the feeder doesn’t scare me at all!" +
                    "\r\n\r\n3L Capacity, Worry-Free Travel: When mom goes on trips, she leaves me in the care of the cat feeder. It holds 3L of food, enough to last me for up to 15 days. Mom no longer worries that I’ll go hungry while she’s away, and I’m happy knowing she’s having a relaxing time. She even sets up a feeding schedule for me, with 1 to 6 meals a day, and each meal can consist of 1 to 9 servings (11g per serving). I’m now a punctual kitty, eating on time!\r\n\r\nDual Power Supply, Consistent Feeding: One day, there was a power outage, and mom explained that the lights went out. But the automatic feeder kept working, and I got my food on time. " +
                   "It turns out the feeder runs on both electricity and batteries, so even if the power goes out, I still get my meals. Now, mom doesn’t have to worry about me missing a meal.",
                    ImageUrl = "https://m.media-amazon.com/images/I/71823ihrMEL._AC_SL1500_.jpg",
                    CategoryId = 1,
                    BrandId = 3,
                    Price = 35.99m,
                    Quantity = 23
                },
                new Product()
                {
                    Id = 4,
                    Title = "Complete Dry Dog Food for Adult Dogs, Rich in Lamb and Rice",
                    Description = "Complete Dry Dog Food for Adult Dogs - Rich in Lamb and Rice\r\n\r\nGive your adult dog the best with our Complete Dry Dog Food, formulated with a delicious blend of rich lamb and nutritious rice. " +
                    "This balanced, high-quality formula is designed to meet the specific dietary needs of adult dogs, providing everything they need to thrive." +
                    "\r\n\r\nPacked with premium protein from lamb, it helps support lean muscle mass, while easily digestible rice promotes optimal digestion and gut health. Enhanced with essential vitamins, minerals, and omega fatty acids, this food helps maintain a shiny coat, healthy skin, and supports overall immune function." +
                    "\r\n\r\nPerfect for active dogs, this complete meal delivers the energy and nutrients your pet needs to stay strong and active throughout the day. Free from artificial preservatives and fillers, it offers a wholesome, natural meal that your dog will love.",
                    ImageUrl = "https://m.media-amazon.com/images/I/61JUpVMSEkL._AC_SL1500_.jpg",
                    CategoryId = 2,
                    BrandId = 7,
                    Price = 10.99m,
                    Quantity = 3000
                },
                new Product()
                {
                    Id = 5,
                    Title = "Dog Food Mixed in Gravy",
                    Description = "Dog Food Mixed in Gravy - Delicious and Nutritious\r\n\r\nTreat your dog to a meal they'll love with our Dog Food Mixed in Gravy." +
                    " This savory recipe combines high-quality meat with a rich, flavorful gravy that enhances the taste and texture, making every bite irresistible. " +
                    "Packed with protein-rich meat and essential nutrients, it provides a complete and balanced diet to support your dog’s overall health and well-being." +
                    "\r\n\r\nPerfect for picky eaters or dogs in need of extra hydration, this wet food ensures that every meal is both satisfying and nourishing. " +
                    "The gravy not only adds a burst of flavor but also promotes healthy digestion and helps keep your dog hydrated throughout the day." +
                    "\r\n\r\nIdeal as a standalone meal or as a tasty topper to dry kibble, Dog Food Mixed in Gravy is suitable for dogs of all breeds and sizes, providing them with the nutrients they need to stay happy, active, and healthy.",
                    ImageUrl = "https://m.media-amazon.com/images/I/61bvaNMzZQL._AC_SL1024_.jpg",
                    CategoryId = 2,
                    BrandId = 9,
                    Price = 15.89m,
                    Quantity = 5129
                },
                new Product()
                {
                    Id = 6,
                    Title = "Meaty Chunks Mixed in Jelly Wet",
                    Description = "Meaty Chunks Mixed in Jelly Wet Dog Food – A Savory Delight\r\n\r\nSatisfy your dog's cravings with our Meaty Chunks Mixed in Jelly Wet Dog Food. " +
                    "This delectable recipe features tender, meaty chunks combined with a flavorful jelly that enhances the texture and taste, making every meal an irresistible treat. " +
                    "Packed with high-quality protein and essential nutrients, it supports your dog's overall health, providing the energy and nourishment they need." +
                    "\r\n\r\nThe soft, juicy chunks in savory jelly are perfect for picky eaters or dogs who enjoy a variety of textures in their meals. The added jelly not only boosts the flavor but also promotes healthy digestion and hydration." +
                    "\r\n\r\nWhether served as a stand-alone meal or as a topping for dry kibble, Meaty Chunks Mixed in Jelly Wet Dog Food is ideal for dogs of all sizes and breeds. Your dog will love every bite, and you'll love knowing they’re getting a balanced, nutritious meal.",
                    ImageUrl = "https://m.media-amazon.com/images/I/71qVGX-Z22L._AC_SL1500_.jpg",
                    CategoryId = 2,
                    BrandId = 10,
                    Price = 14.89m,
                    Quantity = 3450
                },
                new Product()
                {
                    Id = 7,
                    Title = "Complete Food for Adult Dogs, Meat Selection in Gravy",
                    Description = "Here’s a product description for Complete Food for Adult Dogs, Meat Selection in Gravy:\r\n\r\nComplete Food for Adult Dogs - Meat Selection in Gravy" +
                    "\r\n\r\nGive your adult dog a meal they’ll love with our Complete Food for Adult Dogs, featuring a delicious Meat Selection in Gravy. " +
                    "This tasty formula combines a variety of high-quality meats, including beef, chicken, and lamb, all served in a rich, flavorful gravy that adds moisture and enhances the taste." +
                    "\r\n\r\nDesigned to meet the nutritional needs of adult dogs, this complete and balanced meal is packed with protein to support strong muscles and energy, along with essential vitamins and minerals to promote overall health and well-being. " +
                    "The gravy not only boosts flavor but also helps with hydration and digestion, ensuring your dog stays satisfied and healthy.\r\n\r\nIdeal for dogs of all breeds and sizes, Complete Food for Adult Dogs, Meat Selection in Gravy can be served as a standalone meal or as a tasty topper to dry kibble." +
                    " With its delicious taste and balanced nutrition, it's the perfect choice for keeping your dog happy and thriving.",
                    ImageUrl = "https://m.media-amazon.com/images/I/616nCQ1rIUL._AC_SL1500_.jpg",
                    CategoryId = 2,
                    BrandId = 12,
                    Price = 19.99m,
                    Quantity = 1256
                },
                new Product()
                {
                    Id = 8,
                    Title = "Adult Lamb & Rice 2 kg Bag, Hypoallergenic Dry Dog Food",
                    Description = "Adult Lamb & Rice 2 kg Bag - Hypoallergenic Dry Dog Food\r\n\r\nProvide your adult dog with a nutritious, easily digestible meal with our Adult Lamb & Rice Dry Dog Food. Specially formulated with high-quality lamb as the primary protein source and rice for easy digestion, this hypoallergenic recipe is ideal for dogs with food sensitivities or allergies.\r\n\r\nThis 2 kg bag contains a balanced mix of essential nutrients, including vitamins, minerals, and omega fatty acids, to support your dog’s overall health, strong muscles, shiny coat, and healthy skin. The lamb provides a high-quality, lean protein, while rice serves as a gentle carbohydrate that helps maintain digestive health.\r\n\r\nFree from common allergens like grains, gluten, and artificial additives, this dry dog food ensures that your dog gets a wholesome, satisfying meal without unnecessary fillers. It’s the perfect choice for adult dogs of all breeds, especially those with sensitive stomachs or allergies.\r\n\r\nGive your dog a delicious, healthy, and hypoallergenic diet with Adult Lamb & Rice 2 kg Bag, and support their well-being every day!",
                    ImageUrl = "https://m.media-amazon.com/images/I/81bM6ccyZ1L._AC_SL1500_.jpg",
                    CategoryId = 2,
                    BrandId = 13,
                    Price = 12.99m,
                    Quantity = 567
                },
                new Product()
                {
                    Id = 9,
                    Title = "Country’s Best Gra Mix Chick & Quail",
                    Description = "Country’s Best Gra Mix Chick & Quail\r\n\r\nProvide your pets with the finest, all-natural nutrition with Country’s Best Gra Mix Chick & Quail." +
                    " This premium blend combines high-quality chicken and quail to create a delicious and nutritious diet that supports the health and vitality of your birds." +
                    " Specially formulated for poultry, this feed ensures your animals receive essential proteins, vitamins, and minerals to thrive." +
                    "\r\n\r\nWith carefully selected ingredients, the Gra Mix Chick & Quail is designed to support healthy growth, improved egg production, and a vibrant, active lifestyle." +
                    " The mix is easily digestible, helping to maintain strong bones and a shiny plumage, while also encouraging healthy, consistent laying patterns." +
                    "\r\n\r\nPerfect for both chicks and quail, this feed can be used as a standalone meal or alongside other supplements to provide a balanced diet. " +
                    "Country’s Best Gra Mix offers an ideal solution for anyone raising healthy, happy chickens or quail.",
                    ImageUrl = "https://www.foodforbirds.co.uk/wp-content/uploads/2024/02/Countrys-Best-Gra-Mix-Chick-Quail-20kg-scaled.jpg",
                    CategoryId = 3,
                    BrandId = 20,
                    Price = 23.98m,
                    Quantity = 300
                },
                new Product()
                {
                    Id = 10,
                    Title = "AFRICAN PARROT MIX",
                    Description = "African Parrot Mix\r\n\r\nGive your African parrot a nutritious and flavorful diet with African Parrot Mix. " +
                    "This specially formulated blend combines a variety of seeds, grains, and dried fruits to provide a balanced, complete diet for your feathered friend. Rich in essential vitamins, minerals, and healthy fats, this mix is designed to support your parrot's overall health, vibrant plumage, and active lifestyle." +
                    "\r\n\r\nWith carefully selected ingredients like sunflower seeds, millet, dried fruits, and nuts, this mix promotes healthy digestion, strong beaks, and bones while helping to maintain your parrot’s energy levels throughout the day. The variety of textures and flavors is sure to keep your African parrot engaged and excited during mealtime." +
                    "\r\n\r\nAfrican Parrot Mix is perfect for parrots of all sizes, providing a rich, enjoyable diet that can be served as a standalone meal or as part of a balanced feeding routine. Keep your parrot healthy, happy, and full of energy with this premium mix tailored specifically for their needs.",
                    ImageUrl = "https://petmarket.bg/wp-content/uploads/2022/02/5410340222010pack.png",
                    CategoryId = 3,
                    BrandId = 18,
                    Price = 6.99m,
                    Quantity = 123
                },
                new Product()
                {
                    Id = 11,
                    Title = "Hamster Tasty Mix | Pack of 2 x 700g ",
                    Description = "Here’s a product description for Hamster Tasty Mix | Pack of 2 x 700g:\r\n\r\nHamster Tasty Mix | Pack of 2 x 700g" +
                    "\r\n\r\nTreat your hamster to a delicious and nutritious meal with Hamster Tasty Mix. This specially crafted blend offers a variety of high-quality ingredients, including seeds, grains, and dried fruits, ensuring a balanced diet that supports your hamster's health, energy, and well-being. " +
                    "Available in a convenient Pack of 2 x 700g, this mix provides a generous supply to keep your hamster satisfied and nourished.\r\n\r\nEach bite is packed with essential vitamins and minerals to promote healthy digestion, strong teeth, and a shiny coat. " +
                    "The mix’s variety of textures and flavors encourages natural foraging behavior, keeping your hamster active and engaged throughout the day.\r\n\r\nPerfect for all hamster breeds, Hamster Tasty Mix can be served as a standalone food or combined with fresh fruits and vegetables for an extra treat. " +
                    "With the 2 x 700g pack, you’ll have enough to feed your pet for weeks, ensuring they enjoy every meal!",
                    ImageUrl = "https://m.media-amazon.com/images/I/61is0DrvB4L._AC_SL1024_.jpg",
                    CategoryId = 3,
                    BrandId = 2,
                    Price = 12.97m,
                    Quantity = 467
                },
                new Product()
                {
                    Id = 12,
                    Title = "Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food",
                    Description = "Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food\r\n\r\nGive your hamster or gerbil a healthy, delicious, and nutritionally balanced diet with Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food." +
                    " This premium muesli blend combines a variety of wholesome ingredients such as seeds, grains, dried fruits, and mealworms, providing your small pet with the protein and energy they need to thrive." +
                    "\r\n\r\nRich in fibre, this mix promotes healthy digestion and helps maintain strong teeth, while the mealworms provide essential protein, supporting your pet’s growth and overall health. " +
                    "With added vitamins and minerals, this food helps maintain a shiny coat, boosts immunity, and keeps your pet full of energy.\r\n\r\nIdeal for hamsters and gerbils, this blend encourages natural foraging behaviors and is perfect for pets of all life stages." +
                    "Whether you serve it as a main meal or mix it with fresh fruits and vegetables, Supreme Hamster and Gerbil Mix Muesli Mealworm Fibre Food ensures your pet enjoys a balanced, tasty diet every day.",
                    ImageUrl = "https://m.media-amazon.com/images/I/514qbqR-lUL._AC_.jpg",
                    CategoryId = 3,
                    BrandId = 4,
                    Price = 7.89m,
                    Quantity = 890
                }
            };
            builder.HasData(products);
        }
    }
}
