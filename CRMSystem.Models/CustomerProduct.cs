﻿using System;

namespace CRMSystem.Models
{
    [Serializable]
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
