projeyi çalıştırmak için:
1) migrationslar silinmeli
2) database drop işlemi yapılmalı
3) 1 ve 2. adımdan sonra migrations alınmalı ve database update işlemi yapılmalı.

ZSStore/Infrastructure/Extensions/ServiceExtension dosyasında kullanılacak database için sqlite kullanılacaksa UseSqlite, sqlserver kullanılacaksa UseSqlServer
kullanımına dikkat edilmeli. ZSStore/appsettings.json kısmında ise kullanılacak databasein yolunu/bilgilerini doğru bir şekilde girmeniz önemlidir.

Config dosyaları Repositories/Config dosyasında tanımlanmıştır.
