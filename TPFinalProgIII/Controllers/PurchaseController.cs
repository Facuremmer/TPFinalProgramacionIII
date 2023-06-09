﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [Route("AllId")]
        [HttpGet]
        public IEnumerable<PurchaseId> GetAllPurchaseId()
        {
            var purchase = _purchaseServices.GetAllPurchaseId();
            var purchaseId = _mapper.Map<IEnumerable<PurchaseId>>(purchase);
            return purchaseId;
        }


        [Route("byName")]
        [HttpGet]

        public ActionResult<PurchaseDTO> GetByName(string purchaseName)
        {
            var purchase = _purchaseServices.GetByName(purchaseName);
            if (purchase == null)
            {
                return NotFound();
            }

            var purchaseDTO = _mapper.Map<IEnumerable<PurchaseDTO>>(purchase);
            return Ok(purchaseDTO);
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
        public ActionResult<PurchaseDTO> UpdatePurchase(PurchaseUpdate purchaseData)
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
        [HttpPost] // Cambiar a HttpPost en lugar de HttpPut
        public ActionResult<PurchaseDTO> CreateSale(PurchaseCreate saleData)
        {
            if (saleData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var sale = _purchaseServices.CreatePurchase(saleData);
                if (sale == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<PurchaseDTO>(sale));
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
