﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookKeeping.Common.DTOs
{
    public class PlanDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Начало должно быть указано")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Завершение должно быть указано")]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "Имя должно быть указано")]
        [StringLength(maximumLength: 30, ErrorMessage = "Имя не должно превышать 10 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Баланс должен быть указан")]
        [Range(1, 50000, ErrorMessage = "Баланс может быть от 1 до 50'000")]
        public int Balance { get; set; }

        public IList<int> UserMembers { get; set; }
    }
}
