using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("DetalleVenta")]
    public class SaleDetailController : ControllerBase
    {
        private readonly ILogger<SaleDetailController> _logger;

        private IMapper _mapper;

        private ISaleDetailServices _saleDetailServices;

        public SaleDetailController(ILogger<SaleDetailController> logger,
                                  IMapper mapper,
                                  ISaleDetailServices saleDetailServices)
        {
            _logger = logger;
            _mapper = mapper;
            _saleDetailServices = saleDetailServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<SaleDetailDTO> GetALL()
        {
            var saleDetail = _saleDetailServices.GetAll();
            var saleDetailDTO = _mapper.Map<IEnumerable<SaleDetailDTO>>(saleDetail);
            return saleDetailDTO;
        }

        [Route("AllId")]
        [HttpGet]
        public IEnumerable<SaleDetailId> GetAllsaleDetailId()
        {
            var saleDetail = _saleDetailServices.GetAllSaleDetailId();
            var saleDetailId = _mapper.Map<IEnumerable<SaleDetailId>>(saleDetail);
            return saleDetailId;
        }

        [HttpGet("{saleDetailId}")]
        public SaleDetailDTO GetOne(int saleDetailId)
        {
            var saleDetail = _saleDetailServices.GetOne(saleDetailId);
            var saleDetailDTO = _mapper.Map<SaleDetailDTO>(saleDetail);
            return saleDetailDTO;
        }

        [Route("byName")]
        [HttpGet]

        public ActionResult<SaleDetailDTO> GetByName(string branchName)
        {
            var saleDetail = _saleDetailServices.GetByName(branchName);
            if (saleDetail == null)
            {
                return NotFound();
            }

            var saleDetailDTO = _mapper.Map<IEnumerable<SaleDetailDTO>>(saleDetail);
            return Ok(saleDetailDTO);
        }


        [HttpDelete("{saleDetailId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int saleDetailId)
        {
            var saleDetail = _saleDetailServices.GetOne(saleDetailId);
            if (saleDetail == null)
            {
                return NotFound();
            }
            try
            {
                _saleDetailServices.DeleteSaleDetail(saleDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error borrando la información ");
            }
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SaleDetailDTO> UpdateSaleDetail(SaleDetaiUpdate saleDetailData)
        {
            if (saleDetailData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var saleDetail = _saleDetailServices.UpdateSaleDetail(saleDetailData);
                if (saleDetail == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<SaleDetailDTO>(saleDetail));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro actualizando la información");
            }
        }

        [Route("create")]
        [HttpPut]
        public ActionResult<SaleDetailDTO> CreateSaleDetail(SaleDetailCreate saleDetailData)
        {
            if (saleDetailData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var saleDetail = _saleDetailServices.CreateSaleDetail(saleDetailData);
                if (saleDetail == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<SaleDetailDTO>(saleDetail));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear");
            }
        }
    }
}
