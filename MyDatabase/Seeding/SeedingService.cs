using Entities.Categories;
using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Seeding
{
    public class SeedingService
    {
        ApplicationDbContext db;
        public SeedingService(ApplicationDbContext context)
        {
            db = context;
        }  

        public void SeedBeer()
        {
            BeerCategory bC1 = new BeerCategory() { Kind = "Ale" };
            BeerCategory bC2 = new BeerCategory() { Kind = "Belgian" };
            BeerCategory bC3 = new BeerCategory() { Kind = "Bock" };
            BeerCategory bC4 = new BeerCategory() { Kind = "Lager" };
            BeerCategory bC5 = new BeerCategory() { Kind = "Pilsner" };
            BeerCategory bC6 = new BeerCategory() { Kind = "Porter" };
            BeerCategory bC7 = new BeerCategory() { Kind = "Stout" };
            BeerCategory bC8 = new BeerCategory() { Kind = "Wheat" };

            List<BeerCategory> beerCategories = new List<BeerCategory>() { bC1, bC2, bC3, bC4, bC5, bC6, bC7, bC8 };
            db.BeerCategories.AddRange(beerCategories);

            Beer b1 = new Beer { Name = "Blue Moon", Description = "Blue Moon White Wheat Beer 330ml", Price = 2, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/b/l/blue-moon-beer-belgian-white-wheat-beer-single-bottle-5-4-abv_1_1.jpg", Category =  bC1};
            Beer b2 = new Beer { Name = "Moosehead", Description = "Moosehead Cracked Canoe Lager 355ml Can", Price = 2.5, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/m/o/moosehead-cracked-canoe-lager-355ml-can.jpg", Category = bC3 };
            Beer b3 = new Beer { Name = "Andwell Brewing", Description = "Crouch, Hold, Engage Rich Red IPA 500ml", Price = 3, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/a/n/andwell-brewing-co-crouch-hold-engage-rich-red-ipa-500ml.jpg", Category = bC3 };
            Beer b4 = new Beer { Name = "Kopparberg", Description = "Kopparberg Rhubarb Cider 500ml", Price = 3, PhotoUrl = "https://cdn.shopify.com/s/files/1/0079/3912/9434/products/straw-and-lime-500_500x.jpg?v=1631694902", Category = bC6 };
            Beer b5 = new Beer { Name = "Guinness", Description = "Guinness Nigerian Foreign Extra Imported Stout 600ml", Price = 3.2, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/g/u/guinness-nigerian-foreign-export-600ml.jpg", Category = bC1 };

            List<Beer> beers = new List<Beer> { b1, b2, b3, b4, b5 };
            db.Beers.AddRange(beers);
            db.SaveChanges();
        }

        public void SeedWine()
        {
            WineCategory wC1 = new WineCategory() { Kind = "Dessert" };
            WineCategory wC2 = new WineCategory() { Kind = "Red" };
            WineCategory wC3 = new WineCategory() { Kind = "Rose" };
            WineCategory wC4 = new WineCategory() { Kind = "Sparkling" };
            WineCategory wC5 = new WineCategory() { Kind = "Sweet" };
            WineCategory wC6 = new WineCategory() { Kind = "White" };
            List<WineCategory> wineCategories = new List<WineCategory>() { wC1, wC2, wC3, wC4, wC5, wC6 };
            db.WineCategories.AddRange(wineCategories);

            Wine w1 = new Wine { Name = "Campo Viejo", Description = "Campo Viejo Winemakers Blend Red Wine 75cl", Price = 7.4, PhotoUrl = "https://assets.sainsburys-groceries.co.uk/gol/8093532/1/640x640.jpg", Category = wC1 };
            Wine w2 = new Wine { Name = "Trivento", Description = "Trivento Reserve Malbec Red Wine 187ml", Price = 2.1, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/t/r/trivento-reserve-malbec-red-wine-75cl_1.jpg", Category = wC2 };
            Wine w3 = new Wine { Name = "Baron D'Arignac ", Description = "Baron D'Arignac Cabernet Sauvignon Red Wine 75cl", Price = 15.2, PhotoUrl = "https://cdn.oaks.delivery/wp-content/uploads/2017/08/baron-darignac.jpg", Category = wC1 };
            Wine w4 = new Wine { Name = "Cloudy Bay", Description = "Cloudy Bay Sauvignon Blanc Wine 1.5Ltr Magnum", Price = 44, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/c/l/cloudy-bay-sauvignon-blanc-white-wine-75cl_1.jpg", Category = wC2 };
            Wine w5 = new Wine { Name = "Maison", Description = "Maison No 9 Rose Wine 75cl", Price = 14, PhotoUrl = "https://digitalcontent.api.tesco.com/v2/media/ghs/1d20098c-11e3-4f34-8e8e-4f3035db2c3c/0457b244-cc6f-48a1-83b8-ab7095a0be7a_1708643708.jpeg?h=540&w=540" };

            List<Wine> wines = new List<Wine> { w1, w2, w3, w4, w5 };
            db.Wines.AddRange(wines);
            db.SaveChanges();
        }

        public void SeedWhiskey()
        {
            WhiskeyCategory whC1 = new WhiskeyCategory() { Kind = "Blended" };
            WhiskeyCategory whC2 = new WhiskeyCategory() { Kind = "Bourbon" };
            WhiskeyCategory whC3 = new WhiskeyCategory() { Kind = "Canadian" };
            WhiskeyCategory whC4 = new WhiskeyCategory() { Kind = "Japanese" };
            WhiskeyCategory whC5 = new WhiskeyCategory() { Kind = "Irish" };
            WhiskeyCategory whC6 = new WhiskeyCategory() { Kind = "Rye" };
            WhiskeyCategory whC7 = new WhiskeyCategory() { Kind = "Scotch" };
            WhiskeyCategory whC8 = new WhiskeyCategory() { Kind = "Single Malt" };
            WhiskeyCategory whC9 = new WhiskeyCategory() { Kind = "Tennessee" };
            List<WhiskeyCategory> whiskeyCategories = new List<WhiskeyCategory>() { whC1, whC2, whC3, whC4, whC5, whC6, whC7, whC8, whC9 };
            db.WhiskeyCategories.AddRange(whiskeyCategories);
            db.SaveChanges();

        
            Whiskey wh1 = new Whiskey { Name = "The Busker", Description = "The Busker Triple Cask Triple Smooth Irish Whiskey 70cl", Price = 20, PhotoUrl = "https://c.scdn.gr/images/sku_main_images/028500/28500414/20210427112457_the_busker_single_malt_oyiski_700ml.jpeg", Category = whC1 };
            Whiskey wh2 = new Whiskey { Name = "Jameson", Description = "Jameson Orange Spirit Drink 70cl", Price = 24, PhotoUrl = "https://cdn.shopify.com/s/files/1/0078/7038/2195/products/6112371cdf67a_430x.jpg?v=1631804706", Category = whC2 };
            Whiskey wh3 = new Whiskey { Name = "Proclamation", Description = "Proclamation Blended Irish Whiskey 70cl", Price = 27, PhotoUrl = "https://d2wwnnx8tks4e8.cloudfront.net/images/app/large/5391534150329_3.JPG", Category = whC1 };
            Whiskey wh4 = new Whiskey { Name = "Johnnie Walker", Description = "Johnnie Walker Blue Label Whisky 70cl 2.0 Icons Bottle", Price = 110, PhotoUrl = "https://www.malts.com/en-gb/static/794771079f7422e1fc94398e2a9a83bb/f08e8/5000267187204_Johnnie_Walker_Blue_Label_700ml_Icon_Bottle_CF_1_4b3feef4b1.jpg", Category = whC2 };
            Whiskey wh5 = new Whiskey { Name = "GlenDronach", Description = "The GlenDronach Original 12 Year Whisky 70cl", Price = 82, PhotoUrl = "https://cavagreco.gr/image/cache/catalog/products/spirits/whiskey/single%20malt/GlenDronach%2012%20Years%20Old%20Single%20Malt-540x540.jpg", Category = whC1 };

            List<Whiskey> whiskeys = new List<Whiskey> { wh1, wh2, wh3, wh4, wh5 };
            db.Whiskeys.AddRange(whiskeys);
            db.SaveChanges();
        }

        public void SeedSpirit()
        {
            SpiritCategory sC1 = new SpiritCategory() { Kind = "Brandy" };
            SpiritCategory sC2 = new SpiritCategory() { Kind = "Gin" };
            SpiritCategory sC3 = new SpiritCategory() { Kind = "Rum" };
            SpiritCategory sC4 = new SpiritCategory() { Kind = "Vodka" };
            List<SpiritCategory> spiritCategories = new List<SpiritCategory>() { sC1, sC2, sC3, sC4 };
            db.SpiritCategories.AddRange(spiritCategories);

            Spirit s1 = new Spirit { Name = "Ciroc", Description = "Ciroc Summer Citrus Vodka 70cl", Price = 32, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/c/i/ciroc-summer-citrus-vodka-70cl_2.jpg", Category = sC1 };
            Spirit s2 = new Spirit { Name = "Grace O'Malley", Description = "Grace O'Malley Heather Infused Irish Gin 70cl", Price = 27, PhotoUrl = "https://cdn.shopify.com/s/files/1/0575/4142/7381/products/GraceO_MalleyHeatherInfusedIrishGin70cl_600x.png?v=1636813382", Category = sC1 };
            Spirit s3 = new Spirit { Name = "Black Thistle", Description = "Black Thistle London Dry Gin 70cl", Price = 25, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/b/l/black-thistle-london-dry-gin-70cl.jpg", Category = sC2 };
            Spirit s4 = new Spirit { Name = "Bush Rum", Description = "Bush Rum Original Spiced Rum 70cl", Price = 27, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/b/l/black-thistle-london-dry-gin-70cl.jpg", Category = sC1 };
            Spirit s5 = new Spirit { Name = "Laplandia", Description = "Laplandia Espresso Vodka 20cl", Price = 10, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/l/a/laplandia-espresso-shot-vodka-70cl_temp.jpg", Category = sC2 };
            
            List<Spirit> spirits = new List<Spirit> { s1, s2, s3, s4, s5 };
            db.Spirits.AddRange(spirits);
            db.SaveChanges();
        }
    }
}
