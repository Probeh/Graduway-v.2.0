using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public abstract class BaseModel
    {
        // ======================================= //
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        // ======================================= //
        protected BaseModel()
        {
            this.Created = DateTime.Now;
        }
        protected BaseModel(string title, string description) : this()
        {
            this.Title = title;
            this.Description = description;
        }
    }
}