using Microsoft.AspNetCore.Mvc;
using TestPro.Models2;
using TestPro.Repository;

namespace TestPro.Controllers
{
    [Route("api/default")]
    [ApiController]

    public class FirstController : ControllerBase
    {
        private readonly IRepository _irep;
        public FirstController(IRepository rep)
        {
            _irep = rep;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ICollection<User> GetAllUsers()
        {

            var list = _irep.GetAllUsers();
            return list;
        }
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> TryPatient(int id)
        //{
        //    var user = await _irep.GetById(id);
        //    if (user != null)
        //    {
        //        if (user.NameRole.Trim() == "Пациент" && user.IdRole1 != null)
        //        {
        //            return NoContent();
        //        }
        //    }
        //    return BadRequest();
        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePatient(int id, RegPatient pat)
        {
            var user = await _irep.GetById(id);
            if (user != null)
            {
                if (user.NameRole.Trim() == "Пациент" && user.IdRole1 == null)
                {
                    var p = new Patient();
                    p.Id = pat.Id;
                    p.Name = pat.Name;
                    p.LastName = pat.LastName;
                    user.IdRole1 = p;
                    await _irep.Save();
                    return NoContent();
                }
            }
            return BadRequest();
        }
    }
}
