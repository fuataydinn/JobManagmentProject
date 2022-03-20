
# Job Managment Project 

## Entity Framework (Code First)

Bu projede temel olarak EF Code First ile FluentApi kullanarak iş yönetim projesi hazırlandı.
Proje detayları ; 

- Model klasoru olusturuldu; içerisinde entityler, enumlar ve dbContext sınıfı oluşturuldu.
- Entity configuration klasoru olusturuldu; içerisinde olusturulan entity sınıflarının **FluentApi** ile configrasyonu gerçekleştirildi.
* Model klasoru içerisinde Context sınıfı olusturularak veri tabanına map işlemi gerçekleştirildi, burada;   
  * DbSet<T> : Entity ile database table arasındaki ilişki ,
  * OnmodelCreating Metodu : Ayrı klasörde olusturulan FluentApi configrasyonları bu metod içerisinde cagrılır.
  * OnConfigure Metodu : Bu metod ile SqlConnectionString ile veri tabanına bağlantı gerçekleştirdik.
* EF ile **Migrationlar** olusturulur ve bu migrationlar **Update** edilerek Entitylerimizi veri tabanına aktardık.
* En son olarak proje gereksinimleri olarak Business Kuralları yazıldı.
