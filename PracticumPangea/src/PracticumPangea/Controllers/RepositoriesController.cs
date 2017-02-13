using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using PracticumPangea.processModels;

//using PracticumPangea.processModels;

using PracticumPangea.Data;
using PracticumPangea.Models;

namespace PracticumPangea.Controllers
{
    [Route("api/[controller]")]
    public class RepositoriesController : Controller
    {
        PangeaContext _myNewContext;

        public RepositoriesController(PangeaContext context)
        {
            _myNewContext = context;
        }

        // GET api/Repositories
        [HttpGet]
        public IEnumerable<PangeaRecord> Get()
        {
            //return new string[] { "value1", "value2" };
            List<PangeaRecord> myRecords = new List<PangeaRecord>();
            myRecords = _myNewContext.PangeaRecords.ToList();

            return myRecords;
        }
        
    }
}
