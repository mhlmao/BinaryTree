using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BinaryTree.Web.API.Models;
using BinaryTree.Entities;

namespace BinaryTree.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tree")]
    public class TreeController : Controller
    {
        private readonly ApplicationDbContext context;

        public TreeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        //public IEnumerable<Tree> Get()
        //{
        //    return context.Tree.ToList();
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Tree tree)
        {
            return Ok();
        }
    }
}