﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendProj.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public int? role { get; set; } //0 - default, 1 - admin
        public string? Salt { get; set; }
        public List<string>? ExtraEducationsList { get; set; }

        [Column(TypeName = "jsonb")]
        public Person? Data { get; set; }
    }

    public class Person
    {
        public string? FIO { get; set; }
        public string? Doljnost { get; set; }
        public string? DateOfEmploy { get; set; }
        public string? Birthday { get; set; }
        public int? Experience { get; set; }
        public string? PrevWorkPlace { get; set; }
        public string? Education { get; set; }  // где и какое
        public string? EducationOutsideUniversity { get; set; }
        public byte[]? Image { get; set; }
        public string? About { get; set; }
        public string? Achievments { get; set; }
    }
}