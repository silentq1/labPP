using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public OwnersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = _repository.Owner.GetAllOwners(trackChanges: false);
            var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersDto);
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwner(Guid id)
        {
            var owner = _repository.Owner.GetOwner(id, trackChanges: false);
            if (owner == null)
            {
                _logger.LogInfo($"Owner with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var ownerDto = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerDto);
            }
        }

        [HttpPost]
        public IActionResult CreateOwer([FromBody] OwnerForCreationDto owner)
        {
            if (owner == null)
            {
                _logger.LogError("OwnerForCreationDto object sent from client is null.");
                return BadRequest("ShopForCreationDto object is null");
            }
            var ownerEntity = _mapper.Map<Owner>(owner);
            _repository.Owner.CreateOwner(ownerEntity);
            _repository.Save();
            var ownerToReturn = _mapper.Map<OwnerDto>(ownerEntity);
            return CreatedAtRoute("OwnerById", new { id = ownerToReturn.OwnerId }, ownerToReturn);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var owner = _repository.Owner.GetOwner(id, trackChanges: false);
            if (owner == null)
            {
                _logger.LogInfo($"Owner with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Owner.DeleteOwner(owner);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            if (owner == null)
            {
                _logger.LogError("OwnerForUpdateDto object sent from client is null.");
                return BadRequest("CompanyForUpdateDto object is null");
            }
            var ownerEntity = _repository.Owner.GetOwner(id, trackChanges: true);
            if (ownerEntity == null)
            {
                _logger.LogInfo($"Owner with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(owner, ownerEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
