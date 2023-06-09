﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TPFinalProgIII.Models.DataTranfers.Sale;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Ventas")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;

        private IMapper _mapper;

        private ISaleServices _saleServices;

        public SaleController(ILogger<SaleController> logger,
                                  IMapper mapper,
                                  ISaleServices saleServices)
        {
            _logger = logger;
            _mapper = mapper;
            _saleServices = saleServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<SaleDTO> GetALL()
        {
            var sale = _saleServices.GetAll();
            var saleDTO = _mapper.Map<IEnumerable<SaleDTO>>(sale);
            return saleDTO;
        }

        [Route("AllId")]
        [HttpGet]
        public IEnumerable<SaleId> GetAllSaleId()
        {
            var sale = _saleServices.GetAllSaleId();
            var saleId = _mapper.Map<IEnumerable<SaleId>>(sale);
            return saleId;
        }

        [HttpGet("{saleId}")]
        public SaleDTO GetOne(int saleId)
        {
            var sale = _saleServices.GetOne(saleId);
            var saleDTO = _mapper.Map<SaleDTO>(sale);
            return saleDTO;
        }

        [Route("byName")]
        [HttpGet]

        public ActionResult<SaleDTO> GetByName(string saleName)
        {
            var sale = _saleServices.GetByName(saleName);
            if (sale == null)
            {
                return NotFound();
            }

            var saleDTO = _mapper.Map<IEnumerable<SaleDTO>>(sale);
            return Ok(saleDTO);
        }

        [HttpDelete("{saleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int saleId)
        {
            var sale = _saleServices.GetOne(saleId);
            if (sale == null)
            {
                return NotFound();
            }
            try
            {
                _saleServices.DeleteSale(sale);
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
        public ActionResult<SaleDTO> UpdateSale(SaleUpdate saleData)
        {
            if (saleData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var sale = _saleServices.UpdateSale(saleData);
                if (sale == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<SaleDTO>(sale));
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
        public ActionResult<SaleDTO> CreateSale(SaleCreate saleData)
        {
            if (saleData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var sale = _saleServices.CreateSale(saleData);
                if (sale == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<SaleDTO>(sale));
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
