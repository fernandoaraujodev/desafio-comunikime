using System;
using System.ComponentModel.DataAnnotations;

namespace LojaDiversosAPI.Domains
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ficar em branco")]
        [StringLength(40, ErrorMessage = "O nome deve ter entre 3 a 40 caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ficar em branco")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public float Price { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ficar em branco")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public int AvailableQuantity { get; set; }

        [MaxLength(1024, ErrorMessage = "Esse campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        public string UrlImage { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }

        //Construtor
        public Product(string name, int availableQuantity, float price, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            AvailableQuantity = availableQuantity;
            Price = price;
            Description = description;

            CreationDate = DateTime.Now;
            ChangeDate = DateTime.Now;
        }
    }
}
