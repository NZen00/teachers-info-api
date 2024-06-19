using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using teachers_info_api.Models;
using teachers_info_api.Services;

namespace teachers_info_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            try
            {
                var teachers = await _service.GetAllAsync();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            try
            {
                var teacher = await _service.GetByIdAsync(id);
                if (teacher == null)
                {
                    return NotFound($"Teacher with Id = {id} not found");
                }
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest("Teacher object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _service.AddAsync(teacher);
                return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest("Teacher object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var existingTeacher = await _service.GetByIdAsync(id);
                if (existingTeacher == null)
                {
                    return NotFound($"Teacher with Id = {id} not found");
                }

                await _service.UpdateAsync(id, teacher);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var teacher = await _service.GetByIdAsync(id);
                if (teacher == null)
                {
                    return NotFound($"Teacher with Id = {id} not found");
                }

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
