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

            Wine w1 = new Wine { Name = "Campo Viejo", Description = "Campo Viejo Winemakers Blend Red Wine 75cl", Price = 7.4, PhotoUrl = "https://assets.sainsburys-groceries.co.uk/gol/8093532/1/640x640.jpg", Category = wC2 };
            Wine w2 = new Wine { Name = "Trivento", Description = "Trivento Reserve Malbec Red Wine 187ml", Price = 2.1, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/t/r/trivento-reserve-malbec-red-wine-75cl_1.jpg", Category = wC2 };
            Wine w3 = new Wine { Name = "Baron D'Arignac ", Description = "Baron D'Arignac Cabernet Sauvignon Red Wine 75cl", Price = 15.2, PhotoUrl = "https://cdn.oaks.delivery/wp-content/uploads/2017/08/baron-darignac.jpg", Category = wC2 };
            Wine w4 = new Wine { Name = "Cloudy Bay", Description = "Cloudy Bay Sauvignon Blanc Wine 1.5Ltr Magnum", Price = 44, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/c/l/cloudy-bay-sauvignon-blanc-white-wine-75cl_1.jpg", Category = wC6 };
            Wine w5 = new Wine { Name = "Maison", Description = "Maison No 9 Rose Wine 75cl", Price = 14, PhotoUrl = "https://digitalcontent.api.tesco.com/v2/media/ghs/1d20098c-11e3-4f34-8e8e-4f3035db2c3c/0457b244-cc6f-48a1-83b8-ab7095a0be7a_1708643708.jpeg?h=540&w=540", Category = wC3 };
            Wine w6 = new Wine { Name = "Vietti Moscato d’Asti", Description = "Region: Piedmont, Italy | ABV: 5% | Tasting notes: Canned peaches, Candied ginger, Honeysuckle ", Price = 14, PhotoUrl = "https://cdn11.bigcommerce.com/s-d0rwkfplpd/images/stencil/1280x1280/products/1652/2844/Vajra_-_Moscato__86496.1612829179.jpg?c=2", Category = wC5 };
            Wine w7 = new Wine { Name = "Mega Spileo - Domaine", Description = "Cavino Deus Rosato 200ml", Price = 14, PhotoUrl = "https://www.thanopoulos.gr/883015-large_default/rosato-krasi-roze-imiafrodes-deus-200ml.jpg", Category = wC4 };
            Wine w8 = new Wine { Name = "Château d'Yquem", Description = "Château d'Yquem 375ml 1999", Price = 220, PhotoUrl = "https://media-verticommnetwork1.netdna-ssl.com/wines/chateau-dyquem-375ml-228006-s706.jpg", Category = wC1 };

            List<Wine> wines = new List<Wine> { w1, w2, w3, w4, w5,w6 ,w7,w8};
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

            Spirit s1 = new Spirit { Name = "Ciroc", Description = "Ciroc Summer Citrus Vodka 70cl", Price = 32, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/c/i/ciroc-summer-citrus-vodka-70cl_2.jpg", Category = sC4 };
            Spirit s2 = new Spirit { Name = "Grace O'Malley", Description = "Grace O'Malley Heather Infused Irish Gin 70cl", Price = 27, PhotoUrl = "https://cdn.shopify.com/s/files/1/0575/4142/7381/products/GraceO_MalleyHeatherInfusedIrishGin70cl_600x.png?v=1636813382", Category = sC2 };
            Spirit s3 = new Spirit { Name = "Black Thistle", Description = "Black Thistle London Dry Gin 70cl", Price = 25, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/b/l/black-thistle-london-dry-gin-70cl.jpg", Category = sC2 };
            Spirit s4 = new Spirit { Name = "Bush Rum", Description = "Bush Rum Original Spiced Rum 70cl", Price = 27, PhotoUrl = "https://www.ocado.com/productImages/527/527016011_0_640x640.jpg?identifier=afc0efa6b1c816a4315eba0bd71e35ae", Category = sC3 };
            Spirit s5 = new Spirit { Name = "Laplandia", Description = "Laplandia Espresso Vodka 20cl", Price = 10, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/l/a/laplandia-espresso-shot-vodka-70cl_temp.jpg", Category = sC4 };
            Spirit s6 = new Spirit { Name = "Remy Martin X.O", Description = "Remy Martin X.O CRISTALLO 0,7LT", Price = 35, PhotoUrl = "https://static1.s123-cdn-static-a.com/uploads/1087315/800_5aea22d00fb66.jpg", Category = sC1 };
            Spirit s7= new Spirit { Name = "Ed Hardy", Description = "Ed Hardy Βότκα 40% 1000ml", Price = 78, PhotoUrl = "https://d3r6kbofdnmd8.cloudfront.net/media/catalog/product/cache/image/1536x/a4e40ebdc3e371adff845072e1c73f37/9/8/98541_ed-hardy-vodka-10l-40-vol.jpg", Category = sC4 };
            Spirit s8= new Spirit { Name = "Serkova", Description = "Serkova Βότκα 700ml", Price = 14, PhotoUrl = "https://s1.sklavenitis.gr/images/1600x1600/1/files/ProductMedia/Products/2327237/1.jpg", Category = sC4 };
            Spirit s9= new Spirit { Name = "Absolut", Description = "Absolut Βότκα 500ml", Price = 14, PhotoUrl = "https://d3hz4baxchepgp.cloudfront.net/medias/sys_master/h8b/hec/8832233537566.jpg", Category = sC4 };
            Spirit s10= new Spirit { Name = "Absolut Cirton", Description = "Absolut Cirton Βότκα 700ml", Price = 14, PhotoUrl = "https://www.gourmetencasa-tcm.com/15206/absolut-citron-1l.jpg", Category = sC4 };
            Spirit s11= new Spirit { Name = "Diwisa Trojka Black Liqueur", Description = "Diwisa Trojka Black Liqueur Βότκα 700ml", Price = 18, PhotoUrl = "https://www.e-alfasigma.gr/image/cache/data/POTA/VODKA/TROJKA/3376564_001-1100x1100.jpg", Category = sC4 };
            Spirit s12= new Spirit { Name = "Stolichnaya Citros", Description = "Stolichnaya Citros Βότκα 700ml", Price = 18, PhotoUrl = "http://www.absoluteliquorstore.com.sg/images/source/Vodka/Stolichnaya_Stoli_Citros_Vodka_-_700ml.jpg", Category = sC4 };
            Spirit s13= new Spirit { Name = "Belvedere", Description = "Belvedere Βότκα 700ml", Price = 38, PhotoUrl = "https://eshop.cavanektar.gr/wp-content/uploads/2020/10/09010102.jpg", Category = sC4 };
            Spirit s14= new Spirit { Name = "Beluga", Description = "Beluga Βότκα 700ml", Price = 34, PhotoUrl = "https://www.vintagecava.gr/media/catalog/product/cache/1/thumbnail/600x/17f82f742ffe127f42dca9de82fb58b1/b/e/beluga-700ml.jpg", Category = sC4 };
            Spirit s15= new Spirit { Name = "Absolut Elyx", Description = "Absolut Elyx Βότκα 700ml", Price = 43, PhotoUrl = "https://www.vintagecava.gr/media/catalog/product/cache/1/thumbnail/600x/17f82f742ffe127f42dca9de82fb58b1/a/b/absolut-elyx-700ml_1.jpg", Category = sC4 };
            Spirit s16= new Spirit { Name = "Tanqueray ", Description = "Tanqueray London Dry Τζιν 47% 700ml", Price = 22, PhotoUrl = "https://eshop.cavanektar.gr/wp-content/uploads/2020/10/10010002.jpg", Category = sC2 };
            Spirit s17= new Spirit { Name = "Hendrick's", Description = "Hendrick's Gin 700ml", Price = 33, PhotoUrl = "https://static.wixstatic.com/media/5aaf03_6aeaa65d38fb41979aba1fe3f22a2895~mv2.jpg/v1/fill/w_800,h_800,al_c,q_85/5aaf03_6aeaa65d38fb41979aba1fe3f22a2895~mv2.jpg", Category = sC2 };
            Spirit s18= new Spirit { Name = "Etsu Handcrafted", Description = "Etsu Handcrafted Τζιν 700ml", Price = 34, PhotoUrl = "https://www.cavarokos.gr/image/cache/catalog/product/5127-1200x1200.jpg", Category = sC2 };
            Spirit s19= new Spirit { Name = "Schwarzwald Monkey ", Description = "Schwarzwald Monkey 47 Dry Τζιν 500ml", Price = 40, PhotoUrl = "https://d3hz4baxchepgp.cloudfront.net/medias/sys_master/h24/h55/9290153328670.jpg", Category = sC2 };
            Spirit s20= new Spirit { Name = "Bombay Sapphire Distillery", Description = "Bombay Sapphire Distillery Τζιν 700ml", Price = 22, PhotoUrl = "http://www.gowine.gr/media/catalog/product/cache/1/thumbnail/600x600/9df78eab33525d08d6e5fb8d27136e95/1/0/105-96000.jpg", Category = sC2 };
            Spirit s21= new Spirit { Name = "Tanqueray Flor De Sevilla", Description = "Tanqueray Flor De Sevilla Τζιν 700ml", Price = 22, PhotoUrl = "https://s1.sklavenitis.gr/images/ProductDetail/1/files/ProductMedia/Products/1522551/1.jpg", Category = sC2 };
            Spirit s22= new Spirit { Name = "Beefeater Pink ", Description = "Beefeater Pink Τζιν 700ml", Price = 20, PhotoUrl = "https://d3hz4baxchepgp.cloudfront.net/medias/sys_master/h2a/h5a/9286644400158.jpg", Category = sC2 };
            Spirit s23= new Spirit { Name = "Silent Pool", Description = "Silent Pool Τζιν 700ml", Price = 45, PhotoUrl = "https://www.oinognosia.wine/wp-content/uploads/2019/08/silent-pool-gin.jpg", Category = sC2 };
            Spirit s24= new Spirit { Name = "Ron Barcelo Imperial", Description = "Ron Barcelo Imperial Ρούμι 700ml", Price = 27, PhotoUrl = "https://www.e-alfasigma.gr/image/cache/data/POTA/ROUMI/RON%20BARCELO/Ron-Barcelo-Imperial-1100x1100.jpeg", Category = sC3 };
            Spirit s25= new Spirit { Name = "Don Papa Baroko", Description = "Don Papa Baroko Ρούμι 700ml", Price = 43, PhotoUrl = "https://www.kavakonstantakopoulos.gr/images/thumbs/0002711.jpg", Category = sC3 };
            Spirit s26= new Spirit { Name = "Captain Morgan Spiced Gold", Description = "Captain Morgan Spiced Gold Ρούμι 700ml", Price = 16, PhotoUrl = "https://oldcellar.gr/image/cache/catalog/products/%CE%A1%CE%9F%CE%A5%CE%9C%CE%99/20150209085207_18061904-orig-800x800h.jpg.webp", Category = sC3 };
            Spirit s27= new Spirit { Name = "Bacardi Carta Blanca", Description = "Bacardi Carta Blanca Ρούμι 700ml", Price = 18, PhotoUrl = "https://www.thanopoulos.gr/882272/bacardi-roumi-leuko-1lt.jpg", Category = sC3 };
            Spirit s28= new Spirit { Name = "Ron Millonario XO Reserva Especial ", Description = "Ron Millonario XO Reserva Especial Ρούμι 700ml", Price = 108, PhotoUrl = "https://www.akros.gr/media/17515.jpg", Category = sC3 };
            Spirit s29= new Spirit { Name = "Eminente Reserva 7 Year Old ", Description = "Eminente Reserva 7 Year Old Ρούμι 700ml", Price = 52, PhotoUrl = "https://www.akros.gr/media/29422.jpg", Category = sC3 };
            Spirit s30= new Spirit { Name = "Diplomatico Planas", Description = "Diplomatico Planas Ρούμι 700ml", Price = 30, PhotoUrl = "https://www.kylix.gr/images/styles/large/02.01.4142.jpg", Category = sC3 };
            Spirit s31= new Spirit { Name = "Matusalem Insolito ", Description = "Matusalem Insolito Ρούμι 40% 700ml", Price = 41, PhotoUrl = "https://www.gourmetencasa-tcm.com/17177-large_default/matusalem-insolito-wine-cask-limited-edition-70cl.jpg", Category = sC3 };
            Spirit s32= new Spirit { Name = "Flor De Cana 4 Year Old Extra Seco", Description = "Flor De Cana 4 Year Old Extra Seco Ρούμι 700ml", Price = 20, PhotoUrl = "https://www.akros.gr/media/25955.jpg", Category = sC3 };
            Spirit s33= new Spirit { Name = "Καλλικούνης Alexander X.O.", Description = "Καλλικούνης Alexander X.O. Brandy 700ml", Price = 30, PhotoUrl = "https://drink-shop.gr/wp-content/uploads/2019/02/kalikouni-xo-600x600.jpg", Category = sC1};
            Spirit s34= new Spirit { Name = "Vecchia Romagna", Description = "Vecchia Romagna Brandy 700ml", Price =25, PhotoUrl = "https://themaltbar.gr/tmb/wp-content/uploads/2018/08/Vecchia-Romagna.jpg", Category = sC1};
            Spirit s35= new Spirit { Name = "Bache Gabrielsen Tre Kors", Description = "Bache Gabrielsen Tre Kors Brandy 700ml", Price =35, PhotoUrl = "https://static.cognac-expert.com/7526-large_default/bache-gabrielsen-vs-cognac-3-kors-fine.jpg", Category = sC1};
            Spirit s36= new Spirit { Name = "Metaxa Grand Fine ", Description = "Metaxa Grand Fine (Κεραμικό) Brandy 700ml", Price =50, PhotoUrl = "https://drink-shop.gr/wp-content/uploads/2019/10/metaxa_grand_fine_keramiko_brandy_700ml.jpeg", Category = sC1};
            Spirit s37= new Spirit { Name = "Pierre Ferrand 10 Generations ", Description = "Pierre Ferrand 10 Generations, Κονιάκ, 500ml", Price =40, PhotoUrl = "https://d3r6kbofdnmd8.cloudfront.net/media/catalog/product/cache/image/1536x/a4e40ebdc3e371adff845072e1c73f37/1/0/103507_pierre-ferrand-10-generations-cognac-05l-46-vol.jpg", Category = sC1};
            Spirit s38= new Spirit { Name = "Barsol Pisco Primero Quebranta", Description = "Barsol Pisco Primero Quebranta, Μπράντυ, 700ml", Price =31, PhotoUrl = "https://www.e-alfasigma.gr/image/cache/data/APOSTAGMATA/BARSOL/BARSOL-600x600.jpg", Category = sC1};
            Spirit s39= new Spirit { Name = "Remy Martin Louis XIII", Description = "Remy Martin Louis XIII Μπράντυ, 700ml", Price =95, PhotoUrl = "https://atmliquors.com/wp-content/uploads/2020/07/Remy-Martin-Louis-XIIIx-600x600.jpg", Category = sC1};
            
            List<Spirit> spirits = new List<Spirit> { s1, s2, s3, s4, s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,
                                                      s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,
                                                      s33,s34,s35,s36,s37,s38,s39};
            db.Spirits.AddRange(spirits);
            db.SaveChanges();
        }
    }
}
