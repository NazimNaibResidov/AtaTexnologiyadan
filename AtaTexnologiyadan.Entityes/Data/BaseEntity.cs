using System.ComponentModel.DataAnnotations;

namespace AtaTexnologiyadan.Entityes.Data
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}