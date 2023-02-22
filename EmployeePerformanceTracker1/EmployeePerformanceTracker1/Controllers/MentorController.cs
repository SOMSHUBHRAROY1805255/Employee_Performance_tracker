using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Services;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : Controller
    {
        
        public readonly MentorService _mentorService;
        public MentorController(MentorService mentorService)
        {
            _mentorService = mentorService;
        }
        #region getbyid
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mentorService.GetMentorDetailsById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Mentor entity)
        {
            await _mentorService.UpdateMentorDetails(entity);
            await _mentorService.Save();
            return Ok(entity);
        }
        #endregion

        #region getall
        [HttpGet]
        //[Authorize (Roles ="Employee")]
        public async Task<IActionResult> GetAllMentors()
        {
            try
            {
                var mentors = await _mentorService.GetAll();
                return Ok(mentors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region AddMentor
        [HttpPost]
        [Route("Add Mentor")]
        public async Task<IActionResult> SaveMentor([Bind()] Mentor entity)
        {
            try
            {
                await _mentorService.SaveMentor(entity);
                await _mentorService.Save();
                return (Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region DeleteMentor
        [HttpDelete("DeleteMentor")]
        public async Task<IActionResult> DeleteEAsync(int MentorId)
        {
            try
            {
                var mentor = await _mentorService.DeleteEAsync(MentorId);
                if (mentor == null)
                {
                    return NotFound();
                }
                return Ok(mentor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}

