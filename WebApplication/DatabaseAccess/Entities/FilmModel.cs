﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Entities
{
    public class FilmModel
    {
        public Guid Id { get; set; }

        public int FilmId { get; set; }

        [MaxLength(50)]
        public string NameRu { get; set; }

        [MaxLength(50)]
        public string NameEn { get; set; }

        [MaxLength(10)]
        public string Year { get; set; }

        [MaxLength(10)]
        public string KinopoiskRating { get; set; }

        [MaxLength(50)]
        public string PosterUrlPreview { get; set; }

        [MaxLength(50)]
        public string WebUrl { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public Guid UserFilmsDataId { get; set; }

        public UserFilmData UserFilmData { get; set; }

        public Guid FilmsRatingId { get; set; }

        public FilmsRating FilmsRating { get; set; }
    }
}
