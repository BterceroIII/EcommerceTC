using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Implement
{
    public class DashboardService : IDashboardService
    {
        
        private readonly IGenericRepository<Usuario> _userRepository;
        private readonly IGenericRepository<Producto> _productRepository;
        private readonly ISaleRepository _saleRepository;

        public DashboardService(IGenericRepository<Usuario>
            userRepository, IGenericRepository<Producto> productRepository,
            ISaleRepository saleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }
        /*
        private string Income()
        {
            var consult = _saleRepository.Consult();
            decimal? income = consult.Sum(x => x.Total);
            return Convert.ToString(income);
        }

        private int Sales()
        {
            var consult = _saleRepository.Consult();
            int total = consult.Count();
            return total;
        }

        private int Customer()
        {
            var consult = _userRepository.Consult(u => u.Rol.ToLower() == "cliente");
            int total = consult.Count();
            return total;
        }
        

        private int Product()
        {
            var consult = _productRepository.Consult();
            int total = consult.Count();
            return total;
        }

        */

        public DashboardDTO Summary()
        {
            try
            {
                
                DashboardDTO dto = new DashboardDTO()
                {
                    //TotalIngresos = Income(),
                    //TotalVentas = Sales(),
                    //TotalProductos = Product(),
                    //TotalClientes = Customer(),
                };
                


                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
