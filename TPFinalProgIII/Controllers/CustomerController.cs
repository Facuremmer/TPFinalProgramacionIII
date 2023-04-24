using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.Customer;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        private IMapper _mapper;

        private ICustomerServices _customerServices;

        public CustomerController(ILogger<CustomerController> logger,
                                  IMapper mapper,
                                  ICustomerServices customerServices)
        {
            _logger = logger;
            _mapper = mapper;
            _customerServices = customerServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<CustomerDTO> GetALL()
        {
            var customer = _customerServices.GetAll();
            var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);
            return customerDTO;
        }

        [HttpGet("{customerId}")]
        public CustomerDTO GetOne(int customerId)
        {
            var customer = _customerServices.GetOne(customerId);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }

        [HttpDelete("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int customerId)
        {
            var customer = _customerServices.GetOne(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            try
            {
                _customerServices.DeleteCustomer(customer);
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
        public ActionResult<CustomerDTO> UpdateCustomer(CustomerCreateOrUpdate customerData)
        {
            if (customerData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var customer = _customerServices.UpdateCustomer(customerData);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<CustomerDTO>(customer));
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
        public ActionResult<CustomerDTO> CreateCustomer(CustomerCreateOrUpdate customerData)
        {
            if (customerData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var customer = _customerServices.CreateCustomer(customerData);
                if (customer == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<CustomerDTO>(customer));
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
