﻿using Azure;
using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public ICollection<SubCategory> SubCategories { get; set; }
}
