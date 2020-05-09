using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace _200423_ExoEntity5.Objects
{
	public  class CartProductAssociation
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		[Index] [ForeignKey("CartId")]
		virtual public Cart ForeignCart {get;set;}
		[Index] [ForeignKey("ProductId")]
		virtual public Product ForeignProduct {get;set;}
	}
}
