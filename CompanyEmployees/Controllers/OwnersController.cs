﻿using AutoMapper;
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

        [HttpGet("{id}")]
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
    }
}
