using System;
using System.ComponentModel.DataAnnotations.Schema;
using LawApp.Common.Models.Interfaces;

namespace LawApp.Common.Models.Domain
{
    public class User : IHasId
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
