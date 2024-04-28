using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MahasiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Rakha Galih Nugraha Sukma", Nim = "1302223118" },
            new Mahasiswa { Nama = "Abdillah Aufa Taqiyya", Nim = "1302220131" },
            new Mahasiswa { Nama = "Irvan Dzawin Nuha", Nim = "1302223076" },
            new Mahasiswa { Nama = "Joshua Daniel Simanjuntak", Nim = "1302220072" },
            new Mahasiswa { Nama = "Mohammed Yousef Gumilar", Nim = "1302220085" },
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return Ok(mahasiswa);
        }

        // GET: api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswa.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            return Ok(mahasiswa[index]);
        }

        // POST: api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            mahasiswa.Add(newMahasiswa);
            return CreatedAtAction(nameof(GetMahasiswa), newMahasiswa);
        }

        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswa.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            mahasiswa.RemoveAt(index);
            return NoContent();
        }
    }

    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}

