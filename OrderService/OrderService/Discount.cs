using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService
{
    public class Discount
    {
        public Discount()
        {
            Type = 0;
            Modifier = 1;
        }

        public Discount(DiscountType type, float modifier)
        {
            Type = type;
            Modifier = modifier;
        }

        public DiscountType Type { get; set; }

        public float Modifier { get; set; }
    }
}
