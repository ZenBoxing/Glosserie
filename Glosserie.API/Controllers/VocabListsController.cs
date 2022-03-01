using Glosserie.API.Data;
using Glosserie.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Controllers
{
    [Route("api/vocablists")]
    [ApiController]
    public class VocabListsController : ControllerBase
    {
        private readonly IGlosserieRepo _repo;

        public VocabListsController(IGlosserieRepo repo)
        {
            _repo = repo;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<VocabListModel>> GetAllVocabLists()
        //{
        //    var vocabLists = _repo.GetVocabLists();

        //    return Ok(vocabLists);
        //}

        //[HttpGet("{listID}")]
        //public ActionResult<IEnumerable<VocabListModel>> GetVocabListsById(int listID)
        //{
        //    var vocabList = repo.GetVocabListsById(listID);

        //    return Ok(vocabList);
        //}

        [HttpGet("{userID}")]
        public ActionResult<IEnumerable<VocabListModel>> GetVocabListsByUser(int userID)
        {
            var vocabList = _repo.GetVocabListsByUser(userID);

            return Ok(vocabList);
        }

        [HttpGet("listentries")]
        public ActionResult<IEnumerable<EntryModel>> GetEntriesByList(int userID, string listname)
        {
            var listEntries = _repo.GetEntriesByList(userID, listname);

            return Ok(listEntries);
        }


        //[HttpPost]
        //public void PostVocabList(VocabListOptionsModel options)
        //{
        //    _repo.CreateVocabList(options);
        //    //return response at some point
        //}
        [HttpPost]
        public ActionResult<bool> PostVocabList(VocabListOptionsModel options)
        {
            bool success = _repo.CreateVocabList(options);
            if (success == false)
            {
                return BadRequest("false");
            }
            else 
            {
                return Ok(success);
            }
        }

        [HttpDelete]
        public IActionResult DeleteVocabList(int listID)
        {
            bool success = _repo.DeleteList(listID);
            if (success == false)
            {
                return BadRequest("failed");
            }
            else 
            {
                return Ok();
            }
        }


    }
}
