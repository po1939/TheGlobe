using AutoMapper;
using Common.Helpers;
using Contracts;
using Data.DTOs;
using Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.Services
{
	public class BookService : IBookService
	{
		private readonly IRepository _repository;
		private readonly AppSettings _appSettings;
		private readonly IMapper _mapper;

		public BookService(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<BookDto>> Get()
		{
			var bookList = _repository.GetAll<Book>().AsEnumerable();
			return _mapper.Map<IEnumerable<BookDto>>(bookList);
		}

		public async Task<BookDto> Get(int id)
		{
			return null;
		}


	}
}
