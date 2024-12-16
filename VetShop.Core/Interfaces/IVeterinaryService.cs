using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface IVeterinaryService
    {
        Task<IEnumerable<VeterinaryServiceModel>> GetAllVeterinariansAsync();
        Task<VeterinaryServiceModel?> GetVeterinarianByIdAsync(int id);
        Task<bool> IsVeterinary(string userId);
    }
}
