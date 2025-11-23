# 📚 DigitalLibrary

## برای  [مشاهده دوره](https://toplearn.com/c/5969) کلیک کنید

Welcome to **DigitalLibrary**!  
A practical ASP.NET Core (Razor Pages) project for managing a digital library — created as a hands-on assignment for the [TopLearn.com](https://toplearn.com/) course.  
This project is ideal for ASP.NET Core learners aiming to practice CRUD operations, authentication, file management, and real-world web-app structure.  
✨

---

### 🎯 Project Overview

- Manage digital books with categories, cover images, and downloadable files
- User authentication and role-based access (Admin panel)
- Book download tracking and personal user library
- Simple, real-world CRUD operations (Create, Read, Update, Delete)
- Built with Entity Framework Core & Identity (no third-party mappers or advanced architectures)

---

### 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/masterZarei/DigitalLibrary.git
   cd DigitalLibrary
   ```

2. **Open the project in Visual Studio or VS Code**

3. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

4. **Database setup**
   - Edit your `appsettings.json` to set the SQL Server connection string.
   - Run EF Core migrations if needed, or let the app create the DB on first run.

5. **Run the project**
   ```bash
   dotnet run
   ```
   - The app is available by default at `https://localhost:5001` or `http://localhost:5000`.

---

### 🗂️ Project Structure

```
DigitalLibrary/
  ├── Data/                 # ApplicationDbContext, EF Core Migrations
  ├── Models/               # Book, Category, User, DownloadedBook, ...
  ├── Pages/                # Razor Pages: UI, Admin panel, Book management
  │   ├── Admin/Books/      # Admin CRUD for books
  │   ├── Panel/            # User dashboard & personal library
  │   └── ...               # Public pages (Index, BookDetails, etc.)
  ├── wwwroot/              # Static files, uploaded images and books
  ├── Program.cs            # Application entry point and configuration
  └── README.md
```

---

### 🛠️ Technologies Used

- ASP.NET Core Razor Pages
- Entity Framework Core (Code-First)
- SQL Server
- ASP.NET Core Identity (Authentication & Authorization)
- Bootstrap (for UI)

---

### 📚 Key Learning Points

- EF Core integration and migrations in ASP.NET Core
- Identity authentication & custom user fields
- File upload & static file serving
- Razor Pages for CRUD & admin panels
- Role-based access and policy authorization

---


به **DigitalLibrary** خوش آمدید!  
این پروژه یک کتابخانه دیجیتال بر بستر ASP.NET Core (Razor Pages) است که به عنوان پروژه عملی دوره سایت [TopLearn.com](https://toplearn.com/) پیاده‌سازی شده است.  
## لینک دوره: [دوره کتابخانه آنلاین](https://toplearn.com/c/5969)
مناسب برای تمرین عملیات CRUD، احراز هویت، مدیریت فایل و پیاده‌سازی ساختار واقعی یک وب‌اپلیکیشن در دات‌نت کور.  
✨

---

### 🎯 معرفی پروژه

- مدیریت کتاب‌ها با دسته‌بندی، تصویر و فایل دانلودی
- احراز هویت کاربران و نقش مدیر (پنل مدیریت)
- ثبت دانلودهای هر کاربر و کتابخانه شخصی برای هر فرد
- عملیات پایه‌ای CRUD (افزودن، ویرایش، حذف، مشاهده)
- استفاده از EF Core و Identity (بدون استفاده از معماری‌های پیچیده)

---

### 🚀 شروع سریع

1. **کلون کردن مخزن**
   ```bash
   git clone https://github.com/masterZarei/DigitalLibrary.git
   cd DigitalLibrary
   ```

2. **باز کردن پروژه در Visual Studio یا VS Code**

3. **بازیابی بسته‌های NuGet**
   ```bash
   dotnet restore
   ```

4. **تنظیم دیتابیس**
   - رشته اتصال دیتابیس SQL Server را در `appsettings.json` وارد کنید.
   - در صورت نیاز مایگریشن EF Core را اجرا کنید یا اجازه دهید برنامه دیتابیس را ایجاد کند.

5. **اجرای پروژه**
   ```bash
   dotnet run
   ```
   - پیش‌فرض: برنامه روی `https://localhost:5001` یا `http://localhost:5000` اجرا خواهد شد.

---

### 🗂️ ساختار پوشه‌ها

```
DigitalLibrary/
  ├── Data/                 # کانتکست و مهاجرت‌های EF Core
  ├── Models/               # مدل‌های Book, Category, User و ...
  ├── Pages/                # Razor Pages: رابط کاربری، مدیریت، پنل کاربر
  │   ├── Admin/Books/      # مدیریت کتاب‌ها توسط ادمین
  │   ├── Panel/            # داشبورد و کتابخانه کاربر
  │   └── ...               # صفحات عمومی (خانه، جزئیات کتاب و ...)
  ├── wwwroot/              # فایل‌های استاتیک، تصاویر و کتاب‌ها
  ├── Program.cs            # نقطه شروع و تنظیمات پروژه
  └── README.md
```

---

### 🛠️ تکنولوژی‌های استفاده شده

- ASP.NET Core Razor Pages
- Entity Framework Core (Code-First)
- SQL Server
- ASP.NET Core Identity (احراز هویت و نقش‌ها)
- Bootstrap (رابط کاربری)
---

### 📚 نکات کلیدی آموزشی

- کار با EF Core و مهاجرت‌ها (Migrations) در ASP.NET Core
- پیاده‌سازی احراز هویت و نقش‌ها با Identity
- بارگذاری فایل و ارائه فایل‌های استاتیک
- استفاده از Razor Pages برای CRUD و پنل مدیریت
- محدودسازی دسترسی با نقش و سیاست امنیتی

