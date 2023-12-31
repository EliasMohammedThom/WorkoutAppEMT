﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Models
{
    public class Workout
    {
        [Key]
        public int? Id { get; set; }
        public int? ScheduleId { get; set; }
        public string? UserId { get; set; }
        public DateOnly Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<ExercisesAPI>? Exercises { get; set;}

    }
}
