using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
	public class MusicRepository : Repository<Music>, IMusicRepository
	{
		private MusicMarketDbContext MusicMarketDbContext
		{
			get { return _context as MusicMarketDbContext; }
		}
	public MusicRepository(MusicMarketDbContext context): base(context){ }

		public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
		{
			return await MusicMarketDbContext.Musics.Include(a => a.Artist).ToListAsync();
		}

		public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
		{
			return await MusicMarketDbContext.Musics.Include(a => a.Artist).Where(a => a.ArtistId == artistId).ToListAsync();
		}

		public async Task<Music> GetWithArtistByIdAsync(int id)
		{
			return await MusicMarketDbContext.Musics
				.Include(a => a.Artist)
				.SingleOrDefaultAsync(a => a.Id == id);
		}
	}
}
