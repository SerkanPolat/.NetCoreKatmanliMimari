using AutoMapper;
using MusicMarket.Api.DTO;
using MusicMarket.Core.Models;

namespace MusicMarket.Api.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Domain to Resource
			CreateMap<Music, MusicDTO>();
			CreateMap<Artist, ArtistDTO>();

			//Resource To Domain
			CreateMap<MusicDTO, Music>();
			CreateMap<ArtistDTO, Artist>();

			CreateMap<SaveMusicDTO, Music>();
			CreateMap<Music, SaveMusicDTO>();

		}
	}
}
