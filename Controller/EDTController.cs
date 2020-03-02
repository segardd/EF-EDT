using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EDTController : ControllerBase
    {
        private readonly Universite.Models.UniversiteContext _context;
        public EDTController(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        DateTime dateVue = DateTime.Now;
        /*public List<Creneau> AddCreno(Universite.Models.UniversiteContext context, DateTime dateEDT)
        {

            List<Creneau> MesEvenements = new List<Creneau>();

            List<Cours> LesCrenos = new List<Cours>();
            DateTime borneInf = dateEDT;
            DateTime borneSup = dateEDT;
            int dayNumber = 0;

            switch (dateEDT.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayNumber = 1;
                    break;
                case DayOfWeek.Monday:
                    dayNumber = 2;
                    break;
                case DayOfWeek.Tuesday:
                    dayNumber = 3;
                    break;
                case DayOfWeek.Wednesday:
                    dayNumber = 4;
                    break;
                case DayOfWeek.Thursday:
                    dayNumber = 5;
                    break;
                case DayOfWeek.Friday:
                    dayNumber = 6;
                    break;
                case DayOfWeek.Saturday:
                    dayNumber = 7;
                    break;
                default:
                    break;
            }
            borneSup = borneSup.AddDays((7 - dayNumber));
            borneInf = borneInf.Subtract(TimeSpan.FromDays(dayNumber - 1));


            LesCrenos = _context.Cours.Include(c => c.LUE).Where(c => c.DHDebut.Date >= borneInf && c.DHDebut <= borneSup).ToList();

            if (LesCrenos.Count != 0)
            {



                foreach (Cours creno in LesCrenos)
                {

                    Creneau enCreno = new Creneau(creno);
                    MesEvenements.Add(enCreno);

                }


            }
            return MesEvenements;
        }*/


            public async Task<List<Creneau>> AddCreno(Universite.Models.UniversiteContext context, DateTime start, DateTime end)
        {
           
            List<Creneau> MesEvenements = new List<Creneau>();

            List<Cours> LesCrenos= new List<Cours>();
           


            LesCrenos =await _context.Cours.Include(c => c.LUE).Where(c=>c.DHDebut.Date >= start && c.DHDebut <=end).ToListAsync();

            if (LesCrenos.Count != 0)
            {

                

                foreach (Cours creno in LesCrenos)
                {
                 
                    Creneau enCreno = new Creneau(creno);
                    MesEvenements.Add(enCreno);

                }

                
            }
            return MesEvenements;
        }


        // GET: api/EDT
        [HttpGet]
        public async Task<IList<Creneau>> Get([FromQuery]string start, [FromQuery]string end)
        {
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            DateTime newStart = DateTime.Parse(start, null, System.Globalization.DateTimeStyles.RoundtripKind);
            DateTime newEnd = DateTime.Parse(end, null, System.Globalization.DateTimeStyles.RoundtripKind);

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            TimeSpan incre = new TimeSpan(7, 0, 0, 0, 0);
            dateVue += incre;
            return await AddCreno(_context, newStart, newEnd);
        }

        // GET: api/EDT/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EDT
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EDT/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
