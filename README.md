# Inventory Management System

ASP.NET MVC application for inventory management built with C# 7.3 and Entity Framework.

## Features

- ✅ Product CRUD operations
- ✅ Category management
- ✅ Stock tracking
- ✅ Supplier management
- ✅ Reports and analytics
- ✅ User authentication (ASP.NET Identity)
- ✅ Responsive UI with Bootstrap 4

## Technologies

- **C# 7.3** (Tuple enhancements, Expression variables in initializers)
- **ASP.NET MVC 5**
- **Entity Framework 6**
- **SQL Server 2016**
- **Bootstrap 4**
- **jQuery 3.3**

## Requirements

- .NET Framework 4.7.2
- Visual Studio 2017+
- SQL Server 2016+

## Installation

1. Open solution in Visual Studio
2. Restore NuGet packages
3. Update connection string in `Web.config`
4. Run migrations: `Update-Database`
5. Press F5 to run

## C# 7.3 Features Used

```csharp
// Tuple enhancements
public (int ProductId, string Name, decimal Price) GetProductInfo()
{
    return (Id, Name, Price);
}

// Expression variables in initializers
var product = new Product
{
    Category = categories.FirstOrDefault(c => c.Id == categoryId) ?? new Category()
};

// Attribute on backing fields
[field: NonSerialized]
public event EventHandler StockChanged;
```

## Project Structure

```
InventorySystem/
├── Controllers/
│   ├── ProductsController.cs
│   ├── CategoriesController.cs
│   └── ReportsController.cs
├── Models/
│   ├── Product.cs
│   ├── Category.cs
│   ├── Supplier.cs
│   └── StockMovement.cs
├── Views/
│   ├── Products/
│   ├── Categories/
│   └── Reports/
├── Data/
│   └── AppDbContext.cs
└── Migrations/
```

## Database Schema

- **Products** (Id, Name, SKU, Price, Stock, CategoryId)
- **Categories** (Id, Name, Description)
- **Suppliers** (Id, Name, Contact, Email)
- **StockMovements** (Id, ProductId, Quantity, Type, Date)

## Screenshots

- Dashboard with inventory overview
- Product listing with search/filter
- Stock movement reports
- Low stock alerts

## Author

David Badell - 2018

## License

MIT
