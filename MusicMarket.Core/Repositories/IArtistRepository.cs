using MusicMarket.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMarket.Core.Repositories
{
	public interface IArtistRepository:IRepository<Artist>
	{
		Task<IEnumerable<Artist>> GetAllWithMusicAsync();
		Task<Artist> GetWithMusicByIdAsync(int id);
	}
}
