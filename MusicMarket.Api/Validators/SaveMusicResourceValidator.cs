using FluentValidation;
using MusicMarket.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.Api.Validators
{
	//FluentValidation Kutuphanesinin kullanimi
	//https://medium.com/@yunus.unver/fluent-validation-k%C3%BCt%C3%BCphanesinin-temel-kullan%C4%B1m%C4%B1-5573684b804b#:~:text=Projelerimizde%20veri%20taban%C4%B1na%20kay%C4%B1t%20ekleme,Data%20Annotation%27lar%20ile%20tan%C4%B1mlar%C4%B1z.
	public class SaveMusicResourceValidator : AbstractValidator<SaveMusicDTO>
	{
		public SaveMusicResourceValidator()
		{
			RuleFor(m => m.Name)
				.NotEmpty()
				.MaximumLength(50)
				.WithMessage("Isim Alani Bos Gecilemez");

			RuleFor(m => m.ArtistId)
				.NotNull().WithMessage("Artis Id Bos Gecilemez");
		}
	}
}
