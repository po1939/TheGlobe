using Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IBookService
	{
		Task<IEnumerable<BookDto>> Get();
		Task<BookDto> Get(int id);
	}
}
