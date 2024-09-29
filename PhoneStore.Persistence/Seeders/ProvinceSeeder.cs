using Microsoft.EntityFrameworkCore;
using PhoneStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Persistence.Seeders
{
    public class ProvinceSeeder
    {
        public static void SeedProvinces(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, NameEnglish = "Kabul", Name = "کابل" },
                new Province { Id = 2, NameEnglish = "Kapisa", Name = "کاپيسا" },
                new Province { Id = 3, NameEnglish = "Parwan", Name = "پروان" },
                new Province { Id = 4, NameEnglish = "Wardak", Name = "میدان وردک" },
                new Province { Id = 5, NameEnglish = "Logar", Name = "لوگر" },
                new Province { Id = 6, NameEnglish = "Ghazni", Name = "غزني" },
                new Province { Id = 7, NameEnglish = "Paktia", Name = "پکتيا" },
                new Province { Id = 8, NameEnglish = "Nangarhar", Name = "ننگرهار" },
                new Province { Id = 9, NameEnglish = "Laghman", Name = "لغمان" },
                new Province { Id = 10, NameEnglish = "Kunar", Name = "کنر" },
                new Province { Id = 11, NameEnglish = "Badakhshan", Name = "بدخشان" },
                new Province { Id = 12, NameEnglish = "Takhar", Name = "تخار" },
                new Province { Id = 13, NameEnglish = "Baghlan", Name = "بغلان" },
                new Province { Id = 14, NameEnglish = "Kunduz", Name = "کندوز" },
                new Province { Id = 15, NameEnglish = "Samangan", Name = "سمنگان" },
                new Province { Id = 16, NameEnglish = "Balkh", Name = "بلخ" },
                new Province { Id = 17, NameEnglish = "Jawzjan", Name = "جوزجان" },
                new Province { Id = 18, NameEnglish = "Faryab", Name = "فارياب" },
                new Province { Id = 19, NameEnglish = "Badghis", Name = "بادغيس" },
                new Province { Id = 20, NameEnglish = "Herat", Name = "هرات" },
                new Province { Id = 21, NameEnglish = "Farah", Name = "فراه" },
                new Province { Id = 22, NameEnglish = "Nimroz", Name = "نيمروز" },
                new Province { Id = 23, NameEnglish = "Hilmand", Name = "هلمند" },
                new Province { Id = 24, NameEnglish = "Kandahar", Name = "کندهار" },
                new Province { Id = 25, NameEnglish = "Zabul", Name = "زابل" },
                new Province { Id = 26, NameEnglish = "Uruzgan", Name = "ارزگان" },
                new Province { Id = 27, NameEnglish = "Ghor", Name = "غور" },
                new Province { Id = 28, NameEnglish = "Bamyan", Name = "باميان" },
                new Province { Id = 29, NameEnglish = "Paktika", Name = "پکتيکا" },
                new Province { Id = 30, NameEnglish = "Nuristan", Name = "نورستان" },
                new Province { Id = 31, NameEnglish = "Sar i Pul", Name = "سرپل" },
                new Province { Id = 32, NameEnglish = "Khost", Name = "خوست" },
                new Province { Id = 33, NameEnglish = "Panjshir", Name = "پنجشير" },
                new Province { Id = 34, NameEnglish = "Daikundi", Name = "دايکندي" }
                );
        }
    }
}
