using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.Person;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Persona")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IMapper _mapper;

        private IPersonServices _personServices;

        public PersonController(ILogger<PersonController> logger,
                                  IMapper mapper,
                                  IPersonServices personServices)
        {
            _logger = logger;
            _mapper = mapper;
            _personServices = personServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<PersonDTO> GetALL()
        {
            var person = _personServices.GetAll();
            var personDTO = _mapper.Map<IEnumerable<PersonDTO>>(person);
            return personDTO;
        }

        [HttpGet("{personId}")]
        public PersonDTO GetOne(int personId)
        {
            var person = _personServices.GetOne(personId);
            var personDTO = _mapper.Map<PersonDTO>(person);
            return personDTO;
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int personId)
        {
            var person = _personServices.GetOne(personId);
            if (person == null)
            {
                return NotFound();
            }
            try
            {
                _personServices.DeletePerson(person);
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
        public ActionResult<PersonDTO> UpdatePerson(PersonCreateOrUpdate personData)
        {
            if (personData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var person = _personServices.UpdatePerson(personData);
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<PersonDTO>(person));
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
        public ActionResult<PersonDTO> CreatePerson(PersonCreateOrUpdate personData)
        {
            if (personData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var person = _personServices.CreatePerson(personData);
                if (person == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<PersonDTO>(person));
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
