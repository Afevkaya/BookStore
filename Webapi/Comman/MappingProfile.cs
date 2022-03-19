using AutoMapper;
using Webapi.Application.AuthorOperations.Commands.CreateAuthor;
using Webapi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Webapi.Application.AuthorOperations.Queries.GetAuthors;
using Webapi.Application.BookOperations.Commands.CreateBook;
using Webapi.Application.BookOperations.Queries.GetBookDetail;
using Webapi.Application.BookOperations.Queries.GetBooksQuery;
using Webapi.Application.GenreOperations.Queries.GetGenreDetail;
using Webapi.Application.GenreOperations.Queries.GetGenres;
using Webapi.Entities;



namespace Webapi.Comman
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // İlk parametre source(kaynak), ikinci parametre destionation(hedef) sınıfdır.
            // Source sınıfdan destination sınıfa mapleme(dönüştürme) vardır.
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname)).ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
        }
    }


}
