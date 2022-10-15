using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyEmployees.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ShopsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetShops()
        {
            var shops = _repository.Shops.GetAllShops(trackChanges: false);
            var shopsDto = _mapper.Map<IEnumerable<ShopDto>>(shops);
            return Ok(shopsDto);
        }

        [HttpGet("{id}", Name = "ShopById")]
        public IActionResult GetShop(Guid id)
        {
            var shop = _repository.Shops.GetShop(id, trackChanges: false);
            if (shop == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var shopDto = _mapper.Map<ShopDto>(shop);
                return Ok(shopDto);
            }
        }

        [HttpPost]
        public IActionResult CreateShop([FromBody] ShopForCreationDto shop)
        {
            if (shop == null)
            {
                _logger.LogError("ShopForCreationDto object sent from client is null.");
                return BadRequest("ShopForCreationDto object is null");
            }
            var shopEntity = _mapper.Map<Shop>(shop);
            _repository.Shops.CreateShop(shopEntity);
            _repository.Save();
            var shopToReturn = _mapper.Map<ShopDto>(shopEntity);
            return CreatedAtRoute("ShopById", new { id = shopToReturn.ShopId }, shopToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop(Guid id)
        {
            var shop = _repository.Shops.GetShop(id, trackChanges: false);
            if (shop == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Shops.DeleteShop(shop);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShop(Guid id, [FromBody] ShopForUpdateDto shop)
        {
            if (shop == null)
            {
                _logger.LogError("ShopForUpdateDto object sent from client is null.");
                return BadRequest("ShopForUpdateDto object is null");
            }
            var shopEntity = _repository.Shops.GetShop(id, trackChanges: true);
            if (shopEntity == null)
            {
                _logger.LogInfo($"Shop with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(shop, shopEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
