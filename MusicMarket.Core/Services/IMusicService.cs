using MusicMarket.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMarket.Core.Services
{
	public interface IMusicService
	{
		Task<IEnumerable<Music>> GetAllMusics();
		Task<Music> GetMusicById(int id);
		Task<Music> CreateMusic(Music newMusic);
		Task UpdateMusic(Music musicToBeUpdated, Music music);
		Task DeleteMusic(Music music);
		Task<IEnumerable<Music>> GetAllWithArtist();
		Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId);
	}
}
