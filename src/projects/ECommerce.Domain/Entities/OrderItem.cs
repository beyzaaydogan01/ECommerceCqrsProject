﻿using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class OrderItem : Entity<Guid>
{

    // Elma * 3 25 
    // Elma
    // 3 

    // Armut 
    // Armut
    // 3

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

}