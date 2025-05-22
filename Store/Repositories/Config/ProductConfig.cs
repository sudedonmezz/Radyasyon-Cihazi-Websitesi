using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            
            builder.HasData(
             new Product
                {
                    ProductId = 1,
                    ProductName = "Geiger Müller Tabanlı Elektronik Dozimetre",
                    CategoryId = 1,
                    ProductWeight = 0.3,
                    ProductPrice = 7500,
                    ProductDescription = "Kişisel radyasyon dozimetresi; Geiger-Müller tüpü ile gama ve X-ışını tespiti yapar.",
                    ProductTechnicalSpecs = "Dedektör: Geiger-Müller tüpü, Enerji Aralığı: 50 keV – 3 MeV, Ekran: LCD, Alarm: Sesli ve titreşimli",
                    ProductUsageAreas = "Nükleer tesisler, hastaneler, radyasyon güvenliği uygulamaları",
                    ProductDocumentsPath = "/documents/geiger-dokuman.pdf",
                    ImageUrl = "/images/1.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 2,
                    ProductName = "Katı Hal Dedektörlü Elektronik Dozimetre",
                    CategoryId = 1,
                    ProductWeight = 0.25,
                    ProductPrice = 8900,
                    ProductDescription = "Yüksek hassasiyetli kişisel dozimetre; düşük doz tespiti yapar.",
                    ProductTechnicalSpecs = "Dedektör: Katı hal dedektörü, Enerji Aralığı: 50 keV – 3 MeV, Ekran: LCD, Alarm: Sesli ve titreşimli",
                    ProductUsageAreas = "Nükleer enerji santralleri, tıbbi görüntüleme merkezleri",
                    ProductDocumentsPath = "/documents/katihal-dokuman.pdf",
                    ImageUrl = "/images/2.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 3,
                    ProductName = "Wbext OSL Dozimetri",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 2000,
                    ProductDescription = "Geniş bantlı OSL dozimetri sistemi; farklı radyasyon türlerine karşı hassasiyet sağlar.",
                    ProductTechnicalSpecs = "Dedektör: Geniş bant OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tesisler, araştırma laboratuvarları",
                    ProductDocumentsPath = "/documents/wbext-osl.pdf",
                    ImageUrl = "/images/3.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 4,
                    ProductName = "Hasta OSL Dozimetri-MOSFET",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1800,
                    ProductDescription = "Hastaların maruz kaldığı radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Radyoterapi, nükleer tıp uygulamaları",
                    ProductDocumentsPath = "/documents/hasta-osl.pdf",
                    ImageUrl = "/images/4.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 5,
                    ProductName = "Bilek Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1600,
                    ProductDescription = "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tıp, radyoloji bölümleri",
                    ProductDocumentsPath = "/documents/ekstremite-osl.pdf",
                    ImageUrl = "/images/5.jpg",
                    ShowCase=false
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Tüm Vücut Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1600,
                    ProductDescription = "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tıp, radyoloji bölümleri",
                    ProductDocumentsPath = "/documents/ekstremite-osl.pdf",
                    ImageUrl = "/images/6.jpg",
                    ShowCase=true
                },
                

                new Product
                {
                    ProductId = 7,
                    ProductName = "Yüzük Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1600,
                    ProductDescription = "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tıp, radyoloji bölümleri",
                    ProductDocumentsPath = "/documents/ekstremite-osl.pdf",
                    ImageUrl = "/images/7.jpg",
                    ShowCase=false
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Göz(Lens) Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1600,
                    ProductDescription = "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tıp, radyoloji bölümleri",
                    ProductDocumentsPath = "/documents/ekstremite-osl.pdf",
                    ImageUrl = "/images/8.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 9,
                    ProductName = "Ortam Dozimetresi",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 1600,
                    ProductDescription = "Ellerde ve bileklerde maruz kalınan radyasyon dozunu ölçmek için kullanılan OSL dozimetresi.",
                    ProductTechnicalSpecs = "Dedektör: Alümina tabanlı OSL, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Nükleer tıp, radyoloji bölümleri",
                    ProductDocumentsPath = "/documents/ekstremite-osl.pdf",
                    ImageUrl = "/images/9.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 10,
                    ProductName = "Nötron Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 3500,
                    ProductDescription = "Nötron radyasyonuna maruz kalınan dozları ölçmek için kullanılan sistem.",
                    ProductTechnicalSpecs = "Dedektör: Nötron hassas dedektör, Enerji Aralığı: Termal – 15 MeV",
                    ProductUsageAreas = "Nükleer reaktörler, araştırma laboratuvarları",
                    ProductDocumentsPath = "/documents/notron.pdf",
                    ImageUrl = "/images/10.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 11,
                    ProductName = "Radon Dozimetre",
                    CategoryId = 2,
                    ProductWeight = null,
                    ProductPrice = 2800,
                    ProductDescription = "Radon gazına maruz kalınan dozları ölçmek için kullanılan sistem.",
                    ProductTechnicalSpecs = "Dedektör: Radon hassas dedektör, Enerji Aralığı: 5 keV – 40 MeV",
                    ProductUsageAreas = "Yer altı madenleri, evler, ofisler",
                    ProductDocumentsPath = "/documents/radon.pdf",
                    ImageUrl = "/images/11.jpg",
                    ShowCase=true
                },

                

                new Product
                {
                    ProductId = 12,
                    ProductName = "Geiger Müller Tabanlı Survey Metre",
                    CategoryId = 3,
                    ProductWeight = 1.2,
                    ProductPrice = 11000,
                    ProductDescription = "Çevresel radyasyon seviyelerini ölçmek için kullanılan taşınabilir cihaz.",
                    ProductTechnicalSpecs = "Dedektör: Geiger-Müller tüp, Enerji Aralığı: 30 keV – 3 MeV",
                    ProductUsageAreas = "Sanayi, çevre izleme, sağlık fizik laboratuvarları",
                    ProductDocumentsPath = "/documents/gm-survey.pdf",
                    ImageUrl = "/images/12.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 13,
                    ProductName = "Katı Hal Dedektörlü Survey Metre",
                    CategoryId = 3,
                    ProductWeight = 1.1,
                    ProductPrice = 13500,
                    ProductDescription = "Katı hal dedektörlü gelişmiş survey metre.",
                    ProductTechnicalSpecs = "Dedektör: Katı hal dedektör, Enerji Aralığı: 30 keV – 3 MeV",
                    ProductUsageAreas = "Nükleer tesisler, laboratuvarlar",
                    ProductDocumentsPath = "/documents/katihal-survey.pdf",
                    ImageUrl = "/images/13.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 14,
                    ProductName = "Yüzey Kontaminasyon Ölçer",
                    CategoryId = 4,
                    ProductWeight = 0.9,
                    ProductPrice = 9900,
                    ProductDescription = "Yüzeylerdeki alfa, beta kontaminasyonunu tespit eder.",
                    ProductTechnicalSpecs = "Dedektör: Plastik scinitillation, Enerji Aralığı: 20 keV – 2 MeV",
                    ProductUsageAreas = "Laboratuvarlar, hastaneler, sınır güvenliği",
                    ProductDocumentsPath = "/documents/yuzey.pdf",
                    ImageUrl = "/images/14.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 15,
                    ProductName = "Geiger Müller Tabanlı Radyasyon Alan Monitörü",
                    CategoryId = 5,
                    ProductWeight = 1.4,
                    ProductPrice = 12500,
                    ProductDescription = "Sabit olarak kurulan alan monitörü; gamma radyasyon takibi yapar.",
                    ProductTechnicalSpecs = "Dedektör: GM tüp, Aralık: 50 keV – 3 MeV, Çıkış: Analog/dijital",
                    ProductUsageAreas = "Nükleer reaktörler, sınır kapıları",
                    ProductDocumentsPath = "/documents/alan-monitor-gm.pdf",
                    ImageUrl = "/images/15.jpg",
                    ShowCase=true
                },

                new Product
                {
                    ProductId = 16,
                    ProductName = "Katı Hal Dedektörlü Radyasyon Alan Monitörü",
                    CategoryId = 5,
                    ProductWeight = 1.3,
                    ProductPrice = 13900,
                    ProductDescription = "Yüksek hassasiyetli sabit radyasyon izleme cihazı.",
                    ProductTechnicalSpecs = "Dedektör: Katı hal dedektör, Aralık: 50 keV – 3 MeV",
                    ProductUsageAreas = "Nükleer alanlar, tıbbi merkezler",
                    ProductDocumentsPath = "/documents/alan-monitor-katihal.pdf",
                    ImageUrl = "/images/16.jpg",
                    ShowCase=false
                },

                new Product
                {
                    ProductId = 17,
                    ProductName = "Baca Dedektör",
                    CategoryId = 6,
                    ProductWeight = 2.0,
                    ProductPrice = 17500,
                    ProductDescription = "Bacadan yayılan radyoaktif partikülleri tespit eden cihaz.",
                    ProductTechnicalSpecs = "Dedektör: Partikül sayım dedektörü, Aralık: 0.1 µCi/m3 – 100 µCi/m3",
                    ProductUsageAreas = "Nükleer santraller, filtre izleme sistemleri",
                    ProductDocumentsPath = "/documents/baca.pdf",
                    ImageUrl = "/images/17.jpg",
                    ShowCase=true
                }

            );
        }
    }
}