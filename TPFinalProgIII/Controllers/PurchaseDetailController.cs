using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("DetalleCompra")]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly ILogger<PurchaseDetailController> _logger;

        private IMapper _mapper;

        private IPurchaseDetailServices _purchaseDetailServices;

        public PurchaseDetailController(ILogger<PurchaseDetailController> logger,
                                  IMapper mapper,
                                  IPurchaseDetailServices purchaseDetailServices)
        {
            _logger = logger;
            _mapper = mapper;
            _purchaseDetailServices = purchaseDetailServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<PurchaseDetailDTO> GetALL()
        {
            var purchaseDetail = _purchaseDetailServices.GetAll();
            var purchaseDetailDTO = _mapper.Map<IEnumerable<PurchaseDetailDTO>>(purchaseDetail);
            return purchaseDetailDTO;
        }

        [Route("AllId")]
        [HttpGet]
        public IEnumerable<PurchaseDetailId> GetAllpurchaseDetailId()
        {
            var purchaseDetail = _purchaseDetailServices.GetAllpurchaseDetailId();
            var purchaseDetailId = _mapper.Map<IEnumerable<PurchaseDetailId>>(purchaseDetail);
            return purchaseDetailId;
        }

        [Route("byName")]
        [HttpGet]

        public ActionResult<PurchaseDetailDTO> GetByName(string purchaseDetailName)
        {
            var purchaseDetail = _purchaseDetailServices.GetByName(purchaseDetailName);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            var purchaseDetailDTO = _mapper.Map<IEnumerable<PurchaseDetailDTO>>(purchaseDetail);
            return Ok(purchaseDetailDTO);
        }

        [HttpGet("{purchaseDetailId}")]
        public PurchaseDetailDTO GetOne(int purchaseDetailId)
        {
            var purchaseDetail = _purchaseDetailServices.GetOne(purchaseDetailId);
            var purchaseDetailDTO = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            return purchaseDetailDTO;
        }

        [HttpDelete("{purchaseDetailId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int purchaseDetailId)
        {
            var purchaseDetail = _purchaseDetailServices.GetOne(purchaseDetailId);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            try
            {
                _purchaseDetailServices.DeletePurchaseDetail(purchaseDetail);
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
        public ActionResult<PurchaseDetailDTO> UpdatePurchaseDetail(PurchaseDetailUpdate purchaseDetailData)
        {
            if (purchaseDetailData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var purchaseDetail = _purchaseDetailServices.UpdatePurchaseDetail(purchaseDetailData);
                if (purchaseDetail == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<PurchaseDetailDTO>(purchaseDetail));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro actualizando la información");
            }
        }

    }
}
