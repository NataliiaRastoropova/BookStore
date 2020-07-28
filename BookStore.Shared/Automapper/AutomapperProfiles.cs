using System;
using System.Linq;
using AutoMapper;
using BookStore.DB.Domain;
using BookStore.Shared.Dto.Author;
using BookStore.Shared.Dto.Book;
using BookStore.Shared.Dto.Publisher;

namespace BookStore.Shared.Automapper
{
    public sealed class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            // author
            CreateMap<Author, AuthorViewModel>()
                .ForMember(_ => _.FullName, opt => opt.MapFrom(_ => $"{_.LastName[0]}. {_.FirstName}"));
            CreateMap<AuthorCreateModel, Author>();
            CreateMap<AuthorEditModel, Author>();
            CreateMap<Author, AuthorEditModel>();

            // book
            CreateMap<BookCreateModel, Book>()
                .ForMember(b => b.BookAuthors, opt => opt.MapFrom(bc => bc.AuthorsId.Select(ba => new BookAuthor(null, ba)).ToArray()));
            CreateMap<BookEditModel, Book>()
                .ForMember(b => b.BookAuthors, opt => opt.MapFrom(be => be.AuthorsId.Select(ba => new BookAuthor(be.Id, ba)).ToArray()));
            
            CreateMap<Book, BookEditModel>()
                .ForMember(be => be.AuthorsId, opt => opt.MapFrom(b => b.BookAuthors.Select(ba => ba.AuthorId).ToArray()))
                .ForMember(be => be.Genre, opt => opt.MapFrom(b => (byte)((Genre)Enum.Parse(typeof(Genre), b.Genre.ToString()))));
          
            CreateMap<Book, BookViewModel>()
                .ForMember(bv => bv.Authors, opt => opt.MapFrom(b => b.BookAuthors.Select(ba => $"{ba.Author.LastName[0]}. {ba.Author.FirstName}, ").ToArray()))
                .ForMember(bv => bv.Publisher, opt => opt.MapFrom(b =>b.Publisher.Name));

            // publisher
            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<PublisherCreateModel, Publisher>();
            CreateMap<PublisherEditModel, Publisher>();
            CreateMap<Publisher, PublisherEditModel>();
        }
    }
}
