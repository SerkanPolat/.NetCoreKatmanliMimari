using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMarket.Services
{
	public class ArtistService : IArtistService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ArtistService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Artist> CreateArtist(Artist newArtist)
		{
			await _unitOfWork.Artists.AddSync(newArtist);
			await _unitOfWork.CommitAsync();
			return newArtist;
		}

		public async Task DeleteArtist(Artist artist)
		{
			_unitOfWork.Artists.Remove(artist);
			await _unitOfWork.CommitAsync();
		}

		public async Task<IEnumerable<Artist>> GetAllArtists()
		{
			return await _unitOfWork.Artists.GetAllAsync();
		}

		public async Task<Artist> GetArtistById(int id)
		{
			return await _unitOfWork.Artists.GetByIdAsync(id);
		}

		public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
		{
			artistToBeUpdated.Name = artist.Name;
			await _unitOfWork.CommitAsync();
		}
	}
}
