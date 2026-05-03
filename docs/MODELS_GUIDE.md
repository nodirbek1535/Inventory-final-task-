# Modellarni Yaratish Bo'yicha Qo'llanma (MODELS_GUIDE)

Siz `Models` papkasida ochishingiz kerak bo'lgan C# klasslarning tuzilishi (properties) quyidagicha bo'lishi kerak. Barcha `Id` lar `Guid` bo'ladi.

## 1. User
*Foydalanuvchi ma'lumotlari. Task 4 dagi bilan deyarli bir xil.*
```csharp
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } // Social login bo'lsa null bo'lishi mumkin
    public string Role { get; set; } // User, Admin
    public string Language { get; set; } // "en" yoki "uz"
    public string Theme { get; set; } // "light" yoki "dark"
    public bool IsBlocked { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    
    // Relations
    public ICollection<Inventory> Inventories { get; set; }
}
```

## 2. Inventory
*Inventar (shablon) ning o'zi.*
```csharp
public class Inventory
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } // Markdown formatida saqlanadi
    public string Category { get; set; } // Equipment, Furniture, Books...
    public string ImageUrl { get; set; } // Azure blob link
    public bool IsPublic { get; set; } // Hamma tahrirlay oladimi yoki yo'qmi
    public Guid OwnerId { get; set; } // Inventar egasi
    
    // Concurrency Token
    public int Version { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    
    // Relations
    public User Owner { get; set; }
    public ICollection<Item> Items { get; set; }
    public ICollection<FieldConfiguration> FieldConfigurations { get; set; }
    public ICollection<IdElement> IdElements { get; set; }
    public ICollection<InventoryTag> InventoryTags { get; set; }
}
```

## 3. FieldConfiguration
*Inventardagi maydonlarning sozlamalari (nomi, turi).*
```csharp
public class FieldConfiguration
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; }
    
    public string FieldType { get; set; } // "String", "Numeric", "MultiLine", "Boolean", "Link"
    public int SlotIndex { get; set; } // 1 dan 3 gacha (Item jadvalidagi String1, String2 ni bildiradi)
    
    public string Title { get; set; } // Maydonning UIdagi nomi
    public string Description { get; set; } // Yordamchi matn
    public bool IsVisibleInTable { get; set; } // Jadvalda ko'rinadimi?
    public int DisplayOrder { get; set; } // Tartibi
    
    public Inventory Inventory { get; set; }
}
```

## 4. IdElement
*Custom ID generatsiya qilish uchun qismlar.*
```csharp
public class IdElement
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; }
    
    public string ElementType { get; set; } // FixedText, Sequence, DateTime, Guid
    public string FixedTextValue { get; set; } // Faqat ElementType FixedText bo'lsa ishlaydi
    public string FormatOptions { get; set; } // Masalan: sequence uchun "0000" (prefix zeros)
    public int DisplayOrder { get; set; }
    
    public Inventory Inventory { get; set; }
}
```

## 5. Item
*Eng muhim "Suyak" jadvali. Barcha ma'lumotlar shu yerda turadi.*
```csharp
public class Item
{
    public Guid Id { get; set; } // Baza uchun Ichki ID
    public Guid InventoryId { get; set; }
    public string CustomId { get; set; } // Foydalanuvchi ko'radigan yig'ilgan ID
    
    // Maxsus maydonlar (Topshiriq bo'yicha har bir turdan kamida 3 ta)
    public string StringField1 { get; set; }
    public string StringField2 { get; set; }
    public string StringField3 { get; set; }
    
    public string MultiLineField1 { get; set; }
    public string MultiLineField2 { get; set; }
    public string MultiLineField3 { get; set; }
    
    public decimal? NumericField1 { get; set; }
    public decimal? NumericField2 { get; set; }
    public decimal? NumericField3 { get; set; }
    
    public bool? BooleanField1 { get; set; }
    public bool? BooleanField2 { get; set; }
    public bool? BooleanField3 { get; set; }
    
    public string LinkField1 { get; set; } // Rasmlar uchun
    public string LinkField2 { get; set; }
    public string LinkField3 { get; set; }
    
    public Guid CreatedByUserId { get; set; }
    
    // Concurrency Token
    public int Version { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    
    // Relations
    public Inventory Inventory { get; set; }
    public User CreatedByUser { get; set; }
    public ICollection<Like> Likes { get; set; }
}
```

## Eslatma:
Qolgan kichik jadvallar (`Tag`, `Like`, `Comment`) ni ham xuddi shunday mantiq bilan yozib chiqaverasiz. Barcha modellaringiz tayyor bo'lgach, ularni `StorageBroker` ga qo'shib initial migratsiyani amalga oshirasiz. Omad!
