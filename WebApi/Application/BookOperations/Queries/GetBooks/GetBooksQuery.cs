using WebApi.DbOperations;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var books =  _context.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(b => b.Id)
            // .Select(b => new BooksViewModel
            // {
            //     Title = b.Title,
            //     PageCount = b.PageCount,
            //     PublishDate = b.PublishDate.ToString("dd/MM/yyy"),
            //     Genre = ((GenreEnum)b.GenreId).ToString()
            // })
            .ToList();

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(books);

            return vm;
        }

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}