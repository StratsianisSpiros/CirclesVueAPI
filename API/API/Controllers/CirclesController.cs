using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CirclesController : ControllerBase
    {
        private readonly IRepository _repository;

        public CirclesController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("circles/{uniqueCode}")]
        public async Task<IActionResult> GetCircles(string uniqueCode)
        {
            var circles = await _repository.GetCirclesByUniqueCode(uniqueCode);
            var circlesDto = new List<CircleDto>();

            foreach (var circle in circles)
            {
                var circleDto = MapCircleToDto(circle);
                circlesDto.Add(circleDto);
            }

            return Ok(circlesDto);
        }

        [HttpGet("exist/{uniqueCode}")]
        public async Task<IActionResult> CodeExists(string uniqueCode)
        {
            return Ok(await _repository.CodeExists(uniqueCode));
        }

        [HttpGet("codes")]
        public async Task<IActionResult> CurrentCodes() 
        {
            return Ok(await _repository.GetAllDatabaseUniqueCodes());
        }

        [HttpGet("code/{uniqueCode}")]
        public async Task<string> GenerateCode(string uniqueCode)
        {
            var result = await _repository.CodeExists(uniqueCode);

            if (result)
                return uniqueCode;

            var code = CodeService.GenerateRandomCode();
            var codes = await _repository.GetAllDatabaseUniqueCodes();

            while (codes.Contains(code))
            {
                code = CodeService.GenerateRandomCode();              
            }

            return code;
        }

        [HttpPost("store")]
        public async Task<IActionResult> StoreCircle(CircleDto circleDto)
        {
            var circle = MapDtoToCircle(circleDto);

            var result = await _repository.StoreCircle(circle);

            if (!result)
                return BadRequest("Unable to store data");

            return Ok(circleDto);
        }

        private CircleDto MapCircleToDto(Circle circle)
        {
            var circleDto = new CircleDto
            {
                UniqueCode = circle.UniqueCode,
                HostUrl = circle.HostUrl,
                Date = circle.Date,
                CoordX = circle.CoordX,
                CoordY = circle.CoordY,
                Diameter = circle.Diameter,
                Color = circle.Color
            };

            return circleDto;
        }

        private Circle MapDtoToCircle(CircleDto circleDto)
        {
            var circle = new Circle
            {
                UniqueCode = circleDto.UniqueCode,
                HostUrl = circleDto.HostUrl,
                Date = circleDto.Date,
                CoordX = circleDto.CoordX,
                CoordY = circleDto.CoordY,
                Diameter = circleDto.Diameter,
                Color = circleDto.Color
            };

            return circle;
        }
    }
}
