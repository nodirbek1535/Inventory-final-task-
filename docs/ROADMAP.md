# INVENTORY MANAGEMENT SYSTEM — To'liq Texnik Topshiriq (TZ) va Roadmap

Inventory Management Web Application — ASP.NET Core (.NET 10) + React + Bootstrap

---

## 1. LOYIHA MAQSADI

Foydalanuvchilar o'zining ixtiyoriy "inventarlari"ni (qoliplarini) yaratishi, maydonlarni xohlagancha nomlashi va boshqalar ham shu qolip asosida ma'lumot (item) kiritishi mumkin bo'lgan universal veb-ilova yaratish. Asosiy maqsad — dinamik jadvallar yaratmasdan, universal ma'lumotlar bazasi orqali har xil turdagi narsalarni (kitoblar, kompyuterlar, qo'ylar va h.k.) bitta ilovada boshqarish.

---

## 2. ASOSIY TALABLAR

1. **Custom IDs (Noyob ID lar):** Har bir inventar o'z ID formatiga ega bo'lishi kerak. ID faqat bitta inventar doirasida yagona (unique) bo'lishi shart. Bu DB darajasida `UNIQUE INDEX (InventoryId, CustomId)` orqali himoyalanadi.
2. **Custom Fields (Maxsus maydonlar):** Foydalanuvchilar o'zlari maydon qo'sha olishi kerak (string, number, multiline, boolean, date).
3. **Optimistic Locking:** Ikki kishi bir vaqtda bitta yozuvni tahrirlasa, "overwriting" (ustiga yozib yuborish) bo'lmasligi shart.
4. **Auto-save:** Inventar sozlamalarini tahrirlashda har 7-10 soniyada avtomatik saqlanishi kerak (Debouncing).
5. **Real-time Comments:** Item yoki Inventory ostida yozilgan kommentariyalar sahifani yangilamasdan paydo bo'lishi kerak (SignalR).
6. **Images via Cloud:** Rasmlar to'g'ridan-to'g'ri bulutga (Azure Blob/Cloudinary) yuklanishi kerak, DB ga emas.
7. **Jadval UI Qoidalari:** Jadval qatorlarida (Data rows) hech qanday tugmalar (Edit, Delete) bo'lmasligi shart. Toolbar ishlatilishi kerak.

### Qo'shimcha talablar

- Public va Private inventarlar.
- O'zbek va Ingliz tillarini qo'llab-quvvatlash.
- Dark va Light mavzular (Themes).
- Authentication (Google OAuth, Telegram OAuth yoki Email/Password).
- Full-text search (PostgreSQL yordamida barcha inventarlar bo'ylab qidiruv).

---

## 3. TEXNOLOGIYALAR STACKI

### Backend

- **ASP.NET Core 10** Web API
- **Entity Framework Core 10**
- **PostgreSQL** (Full-text search uchun juda muhim)
- **SignalR** — Real-time WebSockets
- **Azure Blob Storage** — Rasmlar uchun
- **JWT Bearer Authentication**
- **MailKit** — Email yuborish
- **Serilog** — Logging

### Frontend

- **React + Vite**
- **Bootstrap 5**
- **Axios** — HTTP client
- **React Router DOM v6**
- **react-beautiful-dnd** — Custom ID bloklarini sudrab tashlash uchun
- **@microsoft/signalr** — WebSocket klient
- **react-i18next** — Ko'p tillilik uchun
- **react-hook-form** — Formalar uchun

---

## 4. DATABASE SXEMASI

Dinamik jadvallar yaratish taqiqlangan! Barcha Itemlar bitta jadvalda turadi.

### 4.1. Users

| Field        | Type          | Izoh              |
| ------------ | ------------- | ----------------- |
| Id           | Guid          | PK                |
| Username     | nvarchar(100) | NOT NULL          |
| Email        | nvarchar(256) | UNIQUE INDEX      |
| PasswordHash | nvarchar(max) | Oauth bo'lsa null |
| Role         | nvarchar(50)  | User/Admin        |
| Theme        | nvarchar(20)  | "light" / "dark"  |
| Language     | nvarchar(10)  | "en" / "uz"       |

### 4.2. Inventories (Shablon)

| Field    | Type          | Izoh                                             |
| -------- | ------------- | ------------------------------------------------ |
| Id       | Guid          | PK                                               |
| Title    | nvarchar(200) |                                                  |
| Category | nvarchar(100) |                                                  |
| OwnerId  | Guid          | FK -> Users                                      |
| Version  | int           | **Concurrency Token (Optimistic Locking)** |

### 4.3. FieldConfigurations (Shablon maydonlari)

| Field       | Type          | Izoh                                     |
| ----------- | ------------- | ---------------------------------------- |
| Id          | Guid          | PK                                       |
| InventoryId | Guid          | FK -> Inventories                        |
| FieldType   | nvarchar(50)  | "String", "Numeric", "Boolean"...        |
| SlotIndex   | int           | 1, 2, 3 (Items jadvalidagi ustun raqami) |
| Title       | nvarchar(200) | Maydon nomi UI uchun                     |

### 4.4. Items (Universal Ma'lumotlar jadvali)

| Field            | Type          | Constraints | Izoh                           |
| ---------------- | ------------- | ----------- | ------------------------------ |
| Id               | Guid          | PK          | Baza uchun                     |
| InventoryId      | Guid          | FK          | Qaysi shablonga tegishliligi   |
| CustomId         | nvarchar(200) |             | User ko'radigan ID (Kitob-001) |
| StringField1..3  | nvarchar      | NULL        | Dinamik matn                   |
| NumericField1..3 | decimal       | NULL        | Dinamik raqam                  |
| BooleanField1..3 | boolean       | NULL        | Dinamik checkbox               |
| CreatedByUserId  | Guid          | FK          | Kim yaratgani                  |
| Version          | int           |             | **Concurrency Token**    |

**Muhim Migration SQL:**

```sql
CREATE UNIQUE INDEX IX_Items_InventoryId_CustomId ON Items(InventoryId, CustomId);
```

---

## 5. BACKEND PROJEKT STRUKTURASI (The Standard)

```
InvenTrack.sln
│
├── InvenTrack.Api/                        ← Presentation layer
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── InventoriesController.cs
│   │   └── ItemsController.cs
│   ├── Hubs/
│   │   └── CommentHub.cs                 ← SignalR
│   ├── Program.cs
│   └── appsettings.json
│
├── InvenTrack.Core/                       ← Business logic (Hech qanday DB kutubxonasi bo'lmaydi)
│   ├── Models/
│   │   ├── Users/
│   │   ├── Inventories/
│   │   └── Items/
│   ├── Services/
│   │   ├── Foundations/                  ← CRUD + Validation
│   │   │   ├── Users/
│   │   │   ├── Inventories/
│   │   │   └── Items/
│   │   ├── Processings/                  ← ID Generation, Image link extracting
│   │   └── Orchestrations/               ← Multi-service flows
│   └── Brokers/                          ← Abstractions
│       ├── Storages/IStorageBroker.cs
│       ├── DateTimes/IDateTimeBroker.cs
│       └── Blobs/IBlobBroker.cs
│
├── InvenTrack.Infrastructure/             ← External dependencies
│   ├── Brokers/
│   │   ├── Storages/
│   │   │   ├── StorageBroker.cs
│   │   │   ├── StorageBroker.Items.cs
│   │   │   └── AppDbContext.cs
│   │   └── Blobs/BlobBroker.cs
│   └── Persistence/Migrations/
│
└── InvenTrack.Tests.Unit/
```

---

## 6. BROKERS

### IStorageBroker.Items

| Method              | Vazifasi                                                |
| ------------------- | ------------------------------------------------------- |
| `InsertItemAsync` | Yangi yozuv                                             |
| `SelectAllItems`  | IQueryable (Full-text search qo'shish mumkin)           |
| `UpdateItemAsync` | **Muhim:** Concurrency exception ni otishi mumkin |

### IBlobBroker

| Method              | Vazifasi                                        |
| ------------------- | ----------------------------------------------- |
| `UploadFileAsync` | Faylni bulutga yuklab, public Link ni qaytaradi |

---

## 7. FOUNDATION SERVICES

### IItemService

| Method              | Vazifasi                                      | Exceptionlar                                                            |
| ------------------- | --------------------------------------------- | ----------------------------------------------------------------------- |
| `AddItemAsync`    | Validatsiya va DB ga saqlash                  | DuplicateKey (Unique Index), SqlException                               |
| `ModifyItemAsync` | DB dan eskisi olinadi, Versiya solishtiriladi | **DbUpdateConcurrencyException -> DependencyValidationException** |

**Diqqat:** ExceptionHandling The Standard dagi TryCatch orqali qilinadi. Task 4 dan nusxa oling.

---

## 8. PROCESSING & ORCHESTRATION SERVICES

### IIdGenerationService

- **Vazifasi:** Bitta `Inventory` dagi barcha `IdElement` larni oladi (masalan: "TEXT-", "DATE-", "SEQUENCE"). Shu zapros tushgan paytdagi qiymatlardan "CustomId" stringini yasab beradi.

### IItemOrchestrationService

- Foydalanuvchi "Save" ni bosganda:
  1. IIdGenerationService orqali ID yasaladi.
  2. Rasmlar bo'lsa IBlobBroker orqali yuklanadi.
  3. IItemService orqali DB ga saqlanadi.

---

## 9. CONTROLLERS

| HTTP  | Route                              | Action                                |
| ----- | ---------------------------------- | ------------------------------------- |
| POST  | `/api/inventories/{invId}/items` | Create item                           |
| GET   | `/api/inventories/{invId}/items` | Get items for table                   |
| PATCH | `/api/inventories/{id}/settings` | Auto-save debounced update            |
| GET   | `/api/search?q=text`             | Full text search (PostgreSQL backend) |

---

## 10. FRONTEND STRUKTURASI (React)

```
frontend/
├── src/
│   ├── api/
│   │   └── axiosClient.js          ← Interceptors (JWT)
│   ├── components/
│   │   ├── inventories/
│   │   │   ├── ItemTable.jsx       ← BUTTONLARSIZ!
│   │   │   ├── ItemToolbar.jsx     ← Tanlanganda chiqadi
│   │   │   └── IdBuilder.jsx       ← Drag-and-drop ID bloklar
│   │   ├── comments/
│   │   │   └── RealtimeChat.jsx    ← SignalR client
│   ├── pages/
│   │   ├── Dashboard.jsx
│   │   └── InventoryView.jsx
│   ├── i18n/
│   │   ├── en.json
│   │   └── uz.json
```

### Auto-save Mantiqi (React)

- `useEffect` va `setTimeout` orqali formadagi o'zgarishlar (isDirty) kuzatib boriladi. 7 soniya davomida foydalanuvchi yozishdan to'xtasa, `axios.patch` jo'natiladi.

### UI Cheklovlari (Qat'iy!)

- `<td>` ichida Edit/Delete tugmasi umuman bo'lmasin. Faqat Chap tomonda checkbox bo'lsin.
- UI Airtable yoki Notion ga o'xshagan "Data-centric" bo'lsin.

---

## 11. ISHLASHNI BOSHLASH TARTIBI (CHECKLIST)

1. [ ] C# .NET 10 Solution yaratish.
2. [ ] Task 4 dan User va Auth brokerlarini `Infrastructure` ga ko'chirish.
3. [ ] Barcha Modellar (`Inventory`, `Item`, `FieldConfig`...) ni yaratish.
4. [ ] `AppDbContext` ichida fluent-API orqali `Unique Index` (Composite) qo'shish.
5. [ ] Optimistic Locking uchun `Version` ustunini isConcurrencyToken qilish.
6. [ ] PostgreSQL ulab, birinchi Migratsiyani qilish.
7. [ ] The Standard Foundation Servislarni (Inventory va Item uchun) xato ushlagichlari bilan yozish.
8. [ ] SignalR Hub ni .NET da ulash.
9. [ ] React Vite loyihasini ochish.
1. [ ] Tailwind/Bootstrap ni ulab Theme (Dark/Light) mantiqini qo'shish.
1. [ ] Toolbar + Checkbox li Jadvalni tayyorlash.
1. [ ] Drag-and-drop ID Builder (react-beautiful-dnd) komponentini yozish.
1. [ ] SignalR ulab, real-time kommentariyalarni test qilish.
1. [ ] Azure ga DB va Ilovani deploy qilish.
1. [ ] Video yozib himoyaga tayyorlanish.

---

> Ushbu Roadmap Task 4 uslubida mukammal darajada loyihani yig'ishga mo'ljallangan. Kodlarni The Standard ga moslab, xuddi oldingi loyihadagidek papkama-papka o'zingiz yozishingiz mumkin. Omad!
