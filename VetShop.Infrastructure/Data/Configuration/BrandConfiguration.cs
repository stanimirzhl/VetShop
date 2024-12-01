using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            var brands = new List<Brand>()
            {
                 new Brand { Id = 1, BrandName = "Hill’s Science Diet", ImageUrl="https://upload.wikimedia.org/wikipedia/en/a/a7/Hill%27s_Science_Diet_logo.jpg" },
                 new Brand { Id = 2, BrandName = "Royal Canin", ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Royal-Canin-Logo.svg/1920px-Royal-Canin-Logo.svg.png" },
                 new Brand { Id = 3, BrandName = "Pedigree", ImageUrl="https://imgs.search.brave.com/frtJBlHhDNgydF724H2Y2bn0iH7BpIdBOxD21embM1M/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pLnBp/bmltZy5jb20vb3Jp/Z2luYWxzLzlkLzQ5/L2Q2LzlkNDlkNjU4/YjFhZjYyOTMxYjJm/MTY4ZThjODFhNjM2/LmpwZw" },
                 new Brand { Id = 4, BrandName = "Purina" , ImageUrl="https://imgs.search.brave.com/Z3GVpNkUeONQEF2lTMGvGLO_-XmWc4fFMMqD62jNdo4/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/bmVzdGxlLmNvbS9z/aXRlcy9kZWZhdWx0/L2ZpbGVzL3N0eWxl/cy93ZWJwX2ltYWdl/L3B1YmxpYy9wdXJp/bmEtbG9nby1zcXVh/cmUtMjAyMy5wbmcu/d2VicD9pdG9rPVgt/LWRaZXpo"},
                 new Brand { Id = 5, BrandName = "Blue Buffalo", ImageUrl="https://imgs.search.brave.com/FijpYqOLAnX9_i67vECFBphIJJEGGmKI7zTzxgBsxsE/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9hc3Nl/dHMuc3RpY2twbmcu/Y29tL2ltYWdlcy82/MDI5MGYwMDYyNTFl/NTAwMDRlNWYxZjku/cG5n" },
                 new Brand { Id = 6, BrandName = "Wellness", ImageUrl="https://www.wellnesspetfood.com/wp-content/uploads/2024/01/Wellness.png" },
                 new Brand { Id = 7, BrandName = "Iams", ImageUrl="https://imgs.search.brave.com/SQXbqX5SQX_PC0vrWgSARARuSIvCIbwzHMObBUXOex8/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy90/aHVtYi81LzUwL0lB/TVMtTG9nby5zdmcv/MjIwcHgtSUFNUy1M/b2dvLnN2Zy5wbmc" },
                 new Brand { Id = 8, BrandName = "Orijen", ImageUrl="https://imgs.search.brave.com/9Bc0WMTArndMR0Y5gQOm2ozjwqHS9-PuBpRmjhX4JzA/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4x/MS5iaWdjb21tZXJj/ZS5jb20vcy1pYWt3/enI3cnM3L2ltYWdl/cy9zdGVuY2lsL29y/aWdpbmFsL2ovb3Jp/amVuXzE1MzQ5NDk2/NjNfXzUwNjkyLm9y/aWdpbmFsLnBuZw" },
                 new Brand { Id = 9, BrandName = "Acana" , ImageUrl="https://imgs.search.brave.com/yM_0sL0U1T9nlCzFr-MoeZ5vDo6WnGgxITk9W9LRc7I/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4x/MS5iaWdjb21tZXJj/ZS5jb20vcy1pYWt3/enI3cnM3L2ltYWdl/cy9zdGVuY2lsL29y/aWdpbmFsL28vMTky/OF9hY25fMTUzNDM3/MjI1Nl9fMjE0MjIu/b3JpZ2luYWwuanBn"},
                 new Brand { Id = 10, BrandName = "Merrick" , ImageUrl="https://imgs.search.brave.com/zU4e80z1aJu6vqlaREbXCAhmLcgW0l79vubMy68CPNY/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/azljdWlzaW5lLmNv/bS9tZWRpYS9hbWFz/dHkvc2hvcGJ5L29w/dGlvbl9pbWFnZXMv/bWVycmljay1wZXQt/Zm9vZC5qcGc"},
                 new Brand { Id = 11, BrandName = "Canidae" , ImageUrl="https://img.petfoodindustry.com/files/base/wattglobalmedia/all/image/2023/05/pfi.canidae-logo.png?auto=format%2Ccompress&fit=max&q=70&w=1200"},
                 new Brand { Id = 12, BrandName = "Natural Balance" , ImageUrl="https://www.naturalbalanceinc.com/wp-content/themes/natural-balance/resources/images/natural-balance.png?"},
                 new Brand { Id = 13, BrandName = "Taste of the Wild", ImageUrl="https://www.tasteofthewildpetfood.com/wp-content/uploads/2019/08/totw-logo-stacked.png"},
                 new Brand { Id = 14, BrandName = "Solid Gold", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRYHq0CD0gmGzvwGseAsR9FR0tQayfvn2xmiw&s" },
                 new Brand { Id = 15, BrandName = "KONG", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbTowr_PTTt9MIl1HfFsKksT5QdJfHZBRwig&s" },
                 new Brand { Id = 16, BrandName = "Chuckit!" , ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8nnPZPSrDr_GI5GQwD3Zi8fBKvbEnMgDdwA&s"},
                 new Brand { Id = 17, BrandName = "Nerf Dog" , ImageUrl="https://www.wnp.com.hk/cdn/shop/collections/Nerf_Dog.jpg?v=1556537026"},
                 new Brand { Id = 18, BrandName = "Outward Hound", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBpoUwlVPIGLyGt9S7U8qf2KmcE1E0Pt5Obg&s" },
                 new Brand { Id = 19, BrandName = "PetSafe", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHlfvZUmjZyjltXNW9nHZ51gsyWrp9ADjOzQ&s" },
                 new Brand{Id = 20, BrandName = "Gourmet" , ImageUrl="https://static.wikia.nocookie.net/logopedia/images/a/a6/Gourmet_%28pet_food%29_2.png/revision/latest?cb=20210123122812"}
            };
            builder.HasData(brands);
        }
    }
}
