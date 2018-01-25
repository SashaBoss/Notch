using System;

using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Entity
{
    [Table("Order")]
    public class OrderEM
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
    }
}