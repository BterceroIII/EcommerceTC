using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Service.Implement
{
    public class SaleService: ISaleService
    {
        private readonly ISaleRepository _modelRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<SaleDTO> Register(SaleDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Venta>(model);
                var saleGenerate = await _modelRepository.Register(dbModel);

                if (saleGenerate.IdVenta == 0)
                {
                    throw new TaskCanceledException("No se pudo registrar");
                }
                else
                {
                    return _mapper.Map<SaleDTO>(saleGenerate);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
