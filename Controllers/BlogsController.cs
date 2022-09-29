using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gfc.Data;
using GfcWebApi.Models;
using Gfc.Models;
namespace Gfc.Controllers
{
    [Route("api")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        public record class EndBlog 
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string PictureUrl { get; set; }
            public string ShortInfo { get; set; }
            public DateTime Published { get; set; }
            public string BlogCode { get; set; }

        }

        private readonly GfcContext _blogContext;

        public BlogsController(GfcContext context)
        {
            _blogContext = context;
        }

        [HttpGet("blogs")]
        public async Task<ActionResult<IEnumerable<EndBlog>>> GetBlogs()
        {
          if (_blogContext.Blogs == null)
          {
              return NotFound();
          }

            var blogs = await _blogContext.Blogs.ToListAsync();

            var endBlogs = new List<EndBlog>();

            foreach(var item in blogs)
            {
                var endBlog = ConvertToEndBlog(item);

                endBlogs.Add(endBlog);
            }
            
            return endBlogs;
        }
        [HttpGet("blogs/{id}")]
        public async Task<ActionResult<EndBlog>> GetBlog(int id)
        {
            if (_blogContext.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _blogContext.Blogs.FindAsync(id);

            StreamReader reader = new StreamReader(blog.TextDocUrl);

            var blogCode = reader.ReadToEnd();

            var endBlog = new EndBlog() { BlogCode = blogCode, Id = blog.Id, Published = blog.Published, Title = blog.Title, PictureUrl = blog.PictureUrl, ShortInfo = blog.ShortInfo };

            return endBlog;
        }

        private EndBlog ConvertToEndBlog(Blog blog)
        {
            StreamReader reader = new StreamReader(blog.TextDocUrl);

            var blogCode = reader.ReadToEnd();

            return new EndBlog() { BlogCode = blogCode, Id = blog.Id, Published = blog.Published, Title = blog.Title, PictureUrl = blog.PictureUrl, ShortInfo = blog.ShortInfo };
        }



    }
}
