using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.Api.DTO;
using MusicMarket.Api.Validators;
using MusicMarket.Core.Models;
using MusicMarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMarket.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMusicService _musicService;
		public MusicsController(IMusicService musicService,IMapper mapper)
		{
			_mapper = mapper;
			_musicService = musicService;
		}
		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
		{
			var musics = await _musicService.GetAllWithArtist();
			var musicResources = _mapper.Map<IEnumerable<Music>,IEnumerable<MusicDTO>>(musics);
			return Ok(musicResources);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<MusicDTO>> GetMusicsByArtistId(int id)
		{
			var musics = await _musicService.GetMusicsByArtistId(id);
			var musicRes = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(musics);
			return Ok(musicRes);
		}
		[HttpPost("")]
		public async Task<ActionResult<MusicDTO>> CreateMusic([FromBody] SaveMusicDTO saveMusicDTO)
		{
			try
			{
				var validator = new SaveMusicResourceValidator();
				var validationResult = await validator.ValidateAsync(saveMusicDTO);
				if (!validationResult.IsValid)
				{
					return BadRequest(validationResult.Errors);
				}
				var musicToCreate = _mapper.Map<SaveMusicDTO, Music>(saveMusicDTO);
				await _musicService.CreateMusic(musicToCreate);
				var createdMusic = await _musicService.GetMusicById(musicToCreate.Id);
				var musicDTO = _mapper.Map<Music, MusicDTO>(createdMusic);

				return Ok(musicDTO);
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
				return null;
			}
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<MusicDTO>> UpdateMusic(int id,[FromBody] SaveMusicDTO UpdateMusicModel)
		{
			try
			{
				var validator = new SaveMusicResourceValidator();
				var valResult = validator.Validate(UpdateMusicModel);
				if (!valResult.IsValid)
				{
					return BadRequest(valResult.Errors);
				}


				var musicToBeUpdated = await _musicService.GetMusicById(id);
				if (musicToBeUpdated == null)
				{
					return NotFound();
				}

				var UpdateMusic = _mapper.Map<SaveMusicDTO, Music>(UpdateMusicModel);
				await _musicService.UpdateMusic(musicToBeUpdated, UpdateMusic);
				var UpdatedMusic = await _musicService.GetMusicById(id);
				var UpdatedMusicResource = _mapper.Map<Music, MusicDTO>(UpdatedMusic);
				return Ok(UpdatedMusicResource);
			}catch(Exception e)
			{
				return BadRequest("Error");
			}
		}
		
	}
}
