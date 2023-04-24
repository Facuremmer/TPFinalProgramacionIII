using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.Purchase;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Compra")]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;

        private IMapper _mapper;

        private IPurchaseServices _purchaseServices;

        public PurchaseController(ILogger<PurchaseController> logger,
                                  IMapper mapper,
                                  IPurchaseServices purchaseServices)
        {
            _logger = logger;
            _mapper = mapper;
            _purchaseServices = purchaseServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<PurchaseDTO> GetALL()
        {
            var purchase = _purchaseServices.GetAll();
            var purchaseDTO = _mapper.Map<IEnumerable<PurchaseDTO>>(purchase);
            return purchaseDTO;
        }

        [HttpGet("{purchaseId}")]
        public PurchaseDTO GetOne(int purchaseId)
        {
            var purchase = _purchaseServices.GetOne(purchaseId);
            var purchaseDTO = _mapper.Map<PurchaseDTO>(purchase);
            return purchaseDTO;
        }

        [HttpDelete("{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int purchaseId)
        {
            var purchase = _purchaseServices.GetOne(purchaseId);
            if (purchase == null)
            {
                return NotFound();
            }
            try
            {
                _purchaseServices.DeletePurchase(purchase);
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
        public ActionResult<PurchaseDTO> UpdatePurchase(PurchaseCreateOrUpdate purchaseData)
        {
            if (purchaseData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var purchase = _purchaseServices.UpdatePurchase(purchaseData);
                if (purchase == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<PurchaseDTO>(purchase));
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
        public ActionResult<PurchaseDTO> CreatePurchase(PurchaseCreateOrUpdate purchaseData)
        {
            if (purchaseData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var purchase = _purchaseServices.CreatePurchase(purchaseData);
                if (purchase == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<PurchaseDTO>(purchase));
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
