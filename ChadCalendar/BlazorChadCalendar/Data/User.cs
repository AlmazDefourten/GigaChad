﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChadCalendar.Data
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int WorkingHoursFrom { get; set; }
        public int WorkingHoursTo { get; set; }
        public int TimeZone { get; set; }
        public int RemindEveryNDays { get; set; }
        public List<Duty> Duties { get; set; }
    }
}
