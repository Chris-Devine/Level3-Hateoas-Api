using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libaryRepository;

        public AuthorsController(ILibraryRepository libaryRepository)
        {
            _libaryRepository = libaryRepository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libaryRepository.GetAuthors();

            var authors = AutoMapper.Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorsFromRepo = _libaryRepository.GetAuthor(id);

            if (authorsFromRepo == null)
            {
                return NotFound();
            }

            var authors = AutoMapper.Mapper.Map<AuthorDto>(authorsFromRepo);

            return Ok(authors);
        }
    }
}