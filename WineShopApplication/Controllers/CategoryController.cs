using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineShopApplication.Auth;
using WineShopApplication.Data;
using WineShopApplication.Models;
using WineShopApplication.Models.CategoryModels;
using WineShopApplication.Repositories._UnitOfWork;

namespace WineShopApplication.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;
        private readonly Mapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ReadAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Entering GetAll method from CategoryController");

            try
            {
                var categories = _unitOfWork.CategoryRepository.GetAll().Include(c => c.Subcategories).ToList();
                var models = categories.ConvertAll(_mapper.MapEntityToModel);

                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to read data");
            }
        }

        [HttpGet]
        [Route("Read/{id:int:min(1):required}")]
        public IActionResult GetById([FromRoute] int id)
        {
            _logger.LogInformation("Entering GetById method from CategoryController");

            try
            {
                Category category = _unitOfWork.CategoryRepository.GetById(id);
                return Ok(_mapper.MapEntityToModel(category));
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Failed to read data");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CategoryInputModel model)
        {
            _logger.LogInformation("Entering Create method from CategoryController");

            try
            {
                _unitOfWork.CategoryRepository.Create(_mapper.MapModelToEntity(model));
                
                if (!_unitOfWork.Commit())
                    return BadRequest("Could not add the category");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPut]
        [Route("Update/{id:int:min(1):required}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryInputModel model)
        {
            _logger.LogInformation("Entering Update method from CategoryController");

            try
            {
                Category toUpdate = _unitOfWork.CategoryRepository.GetById(id);

                toUpdate.Name = model.Name;
                toUpdate.Description = model.Description;

                if (!_unitOfWork.Commit())
                    return BadRequest("Could not update the category");

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Failed to read data");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Entering Update method from CategoryController");

            try
            {
                _unitOfWork.CategoryRepository.Delete(id);

                if (!_unitOfWork.Commit())
                    return BadRequest("Could not delete the category");

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Failed to read data");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
