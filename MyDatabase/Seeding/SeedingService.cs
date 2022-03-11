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

        
            Whiskey wh5 = new Whiskey { Name = "GlenDronach", Description = "The GlenDronach Original 12 Year Whisky 70cl", Price = 82, PhotoUrl = "https://cavagreco.gr/image/cache/catalog/products/spirits/whiskey/single%20malt/GlenDronach%2012%20Years%20Old%20Single%20Malt-540x540.jpg", Category = whC1 };
            
            Whiskey wh2 = new Whiskey { Name = "Willett Kentucky Straight", Description = "Willett Kentucky Straight Bourbon Ουίσκι 700ml", Price = 170, PhotoUrl = "https://www.kylix.gr/images/styles/large/02.01.4582.jpg", Category = whC2 };
            Whiskey wh6 = new Whiskey { Name = "Blantons Bourbon Straight From Barrel", Description = "Blantons Bourbon Straight From Barrel Ουίσκι 700ml", Price = 120, PhotoUrl = "https://www.kavakonstantakopoulos.gr/images/thumbs/0000327.jpg", Category = whC2 };
            Whiskey wh7 = new Whiskey { Name = "Evan Williams Bourbon Bottled in Bond", Description = "Evan Williams Bourbon Bottled in Bond Ουίσκι 700ml", Price = 33, PhotoUrl = "https://apostagma.eu/image/cache/catalog/096749021369-2448x3264.jpg", Category = whC2 };
            Whiskey wh8 = new Whiskey { Name = "Knob Creek Small Batch", Description = "Knob Creek Small Batch Ουίσκι Bourbon Patiently Aged 50% 700ml", Price = 42, PhotoUrl = "https://www.akros.gr/media/15518.jpg", Category = whC2 };
            Whiskey wh9 = new Whiskey { Name = "Woodford Reserve Reserve Holiday ", Description = "Woodford Reserve Reserve Holiday Select Ουίσκι Bourbon 43% 700ml", Price = 56, PhotoUrl = "https://www.wine24shop.gr/dat/F129293F/image1_zoom.jpg", Category = whC2 };
            Whiskey wh10 = new Whiskey { Name = "Yellow Rose Outlaw ", Description = "Yellow Rose Outlaw Bourbon Ουίσκι 700ml", Price = 65, PhotoUrl = "https://media02.drankenwereld.be/media/catalog/product/cache/1/image/800x800/70f758824f4feaf2bb853d4989720f7c/y/e/yellow_rose_outlaw_bourbon_whiskey_drankenwereld.jpg", Category = whC2 };
            Whiskey wh11 = new Whiskey { Name = "FEW", Description = "FEW Ουίσκι Bourbon 46.5% 700ml", Price = 70, PhotoUrl = "https://b.scdn.gr/images/sku_main_images/032926/32926467/20211210110454_few_oyiski_bourbon_46_5_700ml.jpeg", Category = whC2 };
            Whiskey wh12 = new Whiskey { Name = "The Balvenie DoubleWood 12 Y.Ο.", Description = "The Balvenie DoubleWood 12 Y.Ο. Ουίσκι Bourbon Από Βαρέλια Virgin Oak 43% 700ml", Price = 62, PhotoUrl = "https://www.woudenbergdranken.nl/beeld/36227/balvenie.american.oak.jpg", Category = whC2 };
            Whiskey wh13 = new Whiskey { Name = "James E. Pepper 1776 Straight", Description = "James E. Pepper 1776 Straight Bourbon 100 Proof Ουίσκι 700ml", Price = 40, PhotoUrl = "https://cdn.shopify.com/s/files/1/0045/4967/3089/products/james_e_pepper_1776_rye_2000x.jpg?v=1595978275", Category = whC2 };
            Whiskey wh14 = new Whiskey { Name = "Buffalo Trace George T Stagg Kentucky Straight", Description = "Buffalo Trace George T Stagg Kentucky Straight Bourbon Ουίσκι 700ml", Price = 170, PhotoUrl = "https://cdn.shopify.com/s/files/1/0173/0930/products/38ca87ab52503f71d111c239f5d6446ab113866d.jpg?v=1619768712", Category = whC2 };
            
            Whiskey wh15 = new Whiskey { Name = "Kinahan's Small Batch ", Description = "Kinahan's Small Batch Ουίσκι Blended Malt 45% 700ml", Price = 34, PhotoUrl = "https://cdn.shopify.com/s/files/1/0269/0183/9966/products/kinahans-small-batch-irish-whiskey-46-abv-0-7l-75349-viski-irlandiya-kupit-viski-kinahans-400_849x.jpg?v=1631777385", Category = whC1 };
            Whiskey wh16 = new Whiskey { Name = "Mackmyra Brukswhisky", Description = "Mackmyra Brukswhisky Blended Malt Ουίσκι 700ml", Price = 47, PhotoUrl = "https://eshop.cavanektar.gr/wp-content/uploads/2020/11/08020350.jpg", Category = whC1 };
            Whiskey wh17 = new Whiskey { Name = "Johnnie Walker Black Label Islay Origin", Description = "Johnnie Walker Black Label Islay Origin Ουίσκι Blended Malt 47% 700ml", Price = 40, PhotoUrl = "https://delhidutyfree.co.in/pub/media/catalog/product/cache/fc260a2b26538f7a220ac21cbf347203/2/0/2002298_1.jpg", Category = whC1 };
            Whiskey wh18 = new Whiskey { Name = "Loch Lomond Reserve", Description = "Loch Lomond Reserve Blended Malt Ουίσκι 700ml", Price = 25, PhotoUrl = "https://static.specsonline.com/wp-content/uploads/2020/10/081406502046.jpg", Category = whC1 };
            Whiskey wh19 = new Whiskey { Name = "Spencerfield Spirit Sheep Dip", Description = "Spencerfield Spirit Sheep Dip Blended Malt Ουίσκι 200ml", Price = 16, PhotoUrl = "https://apostagma.eu/image/cache/catalog/089744761477-3120x3120.jpg", Category = whC1 };
            Whiskey wh20 = new Whiskey { Name = "Douglas Laing Rock Island Sherry Edition", Description = "Douglas Laing Rock Island Sherry Edition Ουίσκι Blended Malt 46.8% 700ml", Price = 80, PhotoUrl = "https://web-whisky-live.s3-eu-west-1.amazonaws.com/s3fs-public/styles/uc_product_full/public/DSC00002_5.JPG?itok=p8rtHcXD", Category = whC1 };
            Whiskey wh21 = new Whiskey { Name = "Kamiki Sakura & Cedar ", Description = "Kamiki Sakura & Cedar Ουίσκι Blended Malt 48% 500ml", Price = 70, PhotoUrl = "https://bigbarrel.co.nz/content/images/thumbs/005/0059944_kamiki-sakura-wood-48-sakura-tree-cedar-cask-finish-japanese-whisky-500ml.jpeg", Category = whC1 };
            Whiskey wh22 = new Whiskey { Name = "Douglas Laing Big Peat Peatrichor Edition", Description = "Douglas Laing Big Peat Peatrichor Edition Ουίσκι Blended Malt 53.8% 700ml", Price = 56, PhotoUrl = "https://whisky.my/cdn-cgi/image/width=1000,height=1000,fit=crop,quality=80,format=auto,onerror=redirect,metadata=none/wp-content/uploads/Big-peat-1.jpg", Category = whC1 };
            Whiskey wh23 = new Whiskey { Name = "Famous Grouse 12 Years Old", Description = "Famous Grouse 12 Years Old Blended Malt Ουίσκι 700ml", Price = 40, PhotoUrl = "https://www.dreamworksdutyfree.com/wp-content/uploads/2018/09/FAMOUS-GROUSE-GOLD-RESERVE-12-YEARS-OLD-1L.jpg", Category = whC1 };
            Whiskey wh24 = new Whiskey { Name = "Spencerfield Spirit Feathery ", Description = "Spencerfield Spirit Feathery Blended Malt Whisky Ουίσκι 200ml", Price = 40, PhotoUrl = "https://cdn2.whiskyworld.de/produkt/the-feathery-blended-malt-whisky-bm-f1100.tif?h=420&w=420&s=822626b48d3f79b6bf26fdf225715955", Category = whC1 };
            
            Whiskey wh25 = new Whiskey { Name = "Stalk & Barrel Blue Blend", Description = "Stalk & Barrel Blue Blend Canadian Whisky 750ml", Price = 30, PhotoUrl = "http://fountaindelivery.com/wp-content/uploads/2019/10/cq5dam.web_.1280.1280-1316.jpeg", Category = whC3 };
            Whiskey wh26 = new Whiskey { Name = "Canadian Club 6 Year Old ", Description = "Canadian Club 6 Year Old Distilled 1967 Bot.1970s", Price = 90, PhotoUrl = "https://img.thewhiskyexchange.com/900/brbon_can53.jpg", Category = whC3 };
            Whiskey wh27 = new Whiskey { Name = "Canadian Club 100% Rye  ", Description = "Canadian Club 100% Rye 750ml ABV: 40% ", Price = 25, PhotoUrl = "https://cdn.caskers.com/catalog/product/cache/ce56bc73870585a38310c58e499d2fd4/c/a/canadian-club-100_-rye01.jpg", Category = whC3 };
            Whiskey wh28 = new Whiskey { Name = "Lot 40 Canadian Rye Whisky", Description = "Lot 40 Canadian Rye Whisky 750ml", Price = 40, PhotoUrl = "https://bigkmarketliquor.com/wp-content/uploads/2020/11/Lot-40-Canadian-Rye-Whisky-600x720.jpg", Category = whC3 };
            Whiskey wh29 = new Whiskey { Name = "Gibson's Finest 12-year-old", Description = "Gibson's Finest 12-year-old Canadian Whisky 750ml ", Price = 25, PhotoUrl = "https://static.specsonline.com/wp-content/uploads/reload/008366487255.jpg", Category = whC3 };
            Whiskey wh30 = new Whiskey { Name = "Canadian Club 43 Year", Description = "Canadian Club 43 Year Canadian Whisky 750ml ", Price =45, PhotoUrl = "https://orders.newsfilecorp.com/files/7294/66586_canadianclub.jpg", Category = whC3 };
            Whiskey wh31 = new Whiskey { Name = "Canadian Club 12-year-old", Description = "Canadian Club 12-year-old 750ml ", Price =25, PhotoUrl = "https://www.binnys.com/globalassets/catalogs/binnys/13/1313/131351/131351.jpg?width=1000&height=1000&mode=BoxPad&bgcolor=fff", Category = whC3 };
            Whiskey wh32 = new Whiskey { Name = "Canadian Club Original 1858", Description = "Canadian Club Original 1858 700ml ", Price =20, PhotoUrl = "https://www.connosr.com/image/2/750/750/2/images/products/canadian-club-classic-12-year-old-9017.jpg", Category = whC3 };
            Whiskey wh33 = new Whiskey { Name = "Canadian Ltd Canadian", Description = "Canadian Ltd Canadian Whisky 1.75L ", Price =15, PhotoUrl = "https://cdn.powered-by-nitrosell.com/product_images/26/6463/large-185230-a.jpg", Category = whC3 };
            Whiskey wh34 = new Whiskey { Name = "Crown Royal", Description = "Crown Royal Canadian Whiskey 750 ml ", Price =25, PhotoUrl = "https://applejack.com/site/images/Crown-Royal-Canadian-Whiskey-750-ml_1.png", Category = whC3 };
            
            Whiskey wh1 = new Whiskey { Name = "The Busker", Description = "The Busker Triple Cask Triple Smooth Irish Whiskey 70cl", Price = 20, PhotoUrl = "https://nutsaboutwine.ie/wp-content/uploads/2021/03/the-busker-single-malt.jpg", Category = whC5 };
            Whiskey wh3 = new Whiskey { Name = "Proclamation", Description = "Proclamation Blended Irish Whiskey 70cl", Price = 27, PhotoUrl = "https://d2wwnnx8tks4e8.cloudfront.net/images/app/large/5391534150329_3.JPG", Category = whC5 };
            Whiskey wh35 = new Whiskey { Name = "The Sexton ", Description = "The Sexton Irish Whiskey", Price = 40, PhotoUrl = "https://www.kylix.gr/images/styles/large/02.01.4424.jpg", Category = whC5 };
            Whiskey wh36 = new Whiskey { Name = "Slane  ", Description = "Slane Irish Whiskey 750ml", Price = 40, PhotoUrl = "https://cdn.whiskyshop.com/media/catalog/product/cache/2e26a3c2dde6ca2e925d95b5afe00706/s/l/slane_ss_1.jpg", Category = whC5 };
            Whiskey wh37 = new Whiskey { Name = "Teeling Small Batch ", Description = "Teeling Small Batch Irish Whiskey 750ml", Price = 30, PhotoUrl = "https://www.rrselection.com/cache/thumbs/5aedc7671509df213b9907a4/0x0-none/rr_selection_Teeling_Whiskey_Small_Batch_Rum_Cask_Finish_darilna_skatla.jpg", Category = whC5 };
            Whiskey wh38 = new Whiskey { Name = "Knappogue Castle 16 Year Old Single Malt", Description = "Knappogue Castle 16 Year Old Single Malt Irish Whiskey 700ml", Price = 100, PhotoUrl = "https://www.comptoir-irlandais.com/5913-thickbox_default/knappogue-castle-16-years-old.jpg", Category = whC5 };
            Whiskey wh39 = new Whiskey { Name = "Green Spot Single Pot Still", Description = "Green Spot Single Pot Still Whiskey 70cl 700ml", Price = 50, PhotoUrl = "https://cdn.shopify.com/s/files/1/1771/5883/products/gs.png?v=1611027862", Category = whC5 };
            Whiskey wh40 = new Whiskey { Name = "McConnell’s", Description = "McConnell’s Irish Whiskey700ml", Price = 100, PhotoUrl = "https://www.binnys.com/globalassets/catalogs/binnys/10/1011/101122/101122.jpg?width=690&height=690&mode=BoxPad&bgcolor=fff", Category = whC5 };
            Whiskey wh41 = new Whiskey { Name = "Jameson", Description = "Jameson Irish Whiskey 700ml", Price = 21, PhotoUrl = "https://www.houseofwine.gr/how/pub/media/catalog/product/cache/04a61031f3eed06cbf15d459d0b61ca5/6/4/647-jameson.jpg", Category = whC5 };
            Whiskey wh42 = new Whiskey { Name = "Roe & Co", Description = "Roe & Co Irish Whiskey Ουίσκι 700ml", Price = 100, PhotoUrl = "https://www.thanopoulos.gr/754078/roe-co-irish-whiskey-ouiski-blended-dublin-700ml.jpg", Category = whC5 };
            
            Whiskey wh43 = new Whiskey { Name = "Yamazaki 12 year old", Description = "yamazaki 12 year old Japanese whisky 700ml", Price = 220, PhotoUrl = "https://www.cavatheodoridis.gr/images/uploads/YAMAZAKIIIIIIIIIIIIII.jpg", Category = whC4 };
            Whiskey wh44 = new Whiskey { Name = "Hakushu 12 Year", Description = "Hakushu 12 Year Japanese whisky 700ml", Price = 250, PhotoUrl = "https://www.kylix.gr/images/styles/large/02.01.3172.jpeg", Category = whC4 };
            Whiskey wh45 = new Whiskey { Name = "Hibiki ", Description = "Hibiki Japanese Harmony Whisky 700ml", Price = 130, PhotoUrl = "https://ngt.gr/wp-content/uploads/2021/11/suntory_distillery_hibiki_japanese_harmony_700ml.jpeg", Category = whC4 };
            Whiskey wh46 = new Whiskey { Name = "Hatozaki", Description = "Hatozaki Japanese Whiskey 700ml", Price = 35, PhotoUrl = "https://assets.gy.digital/ZdunR6eoC4_YXCXYGY3SLYHkkAo=/x/filters:fill(white)/s3.gy.digital%2Fanthidis_gr%2Fuploads%2Fasset%2Fdata%2F9392%2F45225.jpg", Category = whC4 };
            Whiskey wh47 = new Whiskey { Name = "Nikka coffey grain", Description = "nikka coffey grain whisky 750ml", Price = 65, PhotoUrl = "https://www.kavakonstantakopoulos.gr/images/thumbs/0000370.jpg", Category = whC4 };
            Whiskey wh48 = new Whiskey { Name = "Yamazaki 18 Year Old Single Malt", Description = "Yamazaki 18 Year Old Single Malt Japanese Whisky 750ml", Price = 650, PhotoUrl = "https://www.houseofwine.gr/how/pub/media/catalog/product/cache/04a61031f3eed06cbf15d459d0b61ca5/y/a/yamazaki18.jpg", Category = whC4 };
            Whiskey wh49 = new Whiskey { Name = "Akashi White Oak", Description = "Akashi White Oak Japanese Blended Whisky 750ml", Price = 50, PhotoUrl = "https://forwhiskeylovers.com/sites/default/files/styles/uc_product_full/public/store/akashi-white-oak-japanese-whisky-1.jpg?itok=5RZSs_fm", Category = whC4 };
            Whiskey wh50 = new Whiskey { Name = "Kamiki Cedar Cask", Description = "Kamiki Cedar Cask Japanese Whisky 750ml", Price = 49, PhotoUrl = "https://www.tabaccheriatoto13.com/23351-home_default/kamiki-japanese-blended-malt-whisky-cedar-casks-vol48-cl50.jpg", Category = whC4 };
            Whiskey wh51 = new Whiskey { Name = "Sensei", Description = "Sensei Whiskey Japanese  750ml", Price = 40, PhotoUrl = "https://cdn.shopify.com/s/files/1/0425/4092/5091/products/image_0696b939-d4bd-4a20-b42c-32f07aa85891_large.jpg?v=1638176299", Category = whC4 };
            Whiskey wh52 = new Whiskey { Name = "Matsui Sakura Cask Single", Description = "Matsui Sakura Cask Single MaltWhiskey Japanese  750ml", Price = 130, PhotoUrl = "https://cavagreco.gr/image/cache/catalog/products/spirits/whiskey/single%20malt/Matsui%20Sakura-1080x1080.jpg", Category = whC4 };
            
            Whiskey wh53 = new Whiskey { Name = "Hochstadter's Slow & Low", Description = "Hochstadter's Slow & Low Rock and Rye  750ml", Price = 22, PhotoUrl = "https://cdn11.bigcommerce.com/s-e8559/images/stencil/1280x1280/products/7811/7963/hochstadters-slow-and-low-rock-and-rye-whiskey__89285.1529690393.jpg?c=2", Category = whC6 };
            Whiskey wh54 = new Whiskey { Name = "Jim Beam", Description = "Jim Beam Rye Whiskey   750ml", Price = 22, PhotoUrl = "https://cdn.webshopapp.com/shops/7950/files/342904841/650x750x2/jim-beam-jim-beam-rye.jpg", Category = whC6 };
            Whiskey wh55 = new Whiskey { Name = "Angel's Envy Rum Cask Rye", Description = "Angel's Envy Rum Cask Rye Whiskey  750ml", Price = 90, PhotoUrl = "https://cdn.caskers.com/catalog/product/cache/ce56bc73870585a38310c58e499d2fd4/a/n/angel_s-envy-rye-1.jpg", Category = whC6 };
            Whiskey wh56 = new Whiskey { Name = "Rittenhouse", Description = "rittenhouse rye whiskey 750ml", Price = 40, PhotoUrl = "https://d3r6kbofdnmd8.cloudfront.net/media/catalog/product/cache/image/1536x/a4e40ebdc3e371adff845072e1c73f37/1/0/101138_rittenhouse_rye_700_nl_3.jpg", Category = whC6 };
            Whiskey wh57 = new Whiskey { Name = "Sazerac ", Description = "Sazerac Rye Whiskey 750ml  750ml", Price = 27, PhotoUrl = "https://uptownspirits.com/wp-content/uploads/2021/10/Sazerac-Rye-Whiskey-750ml-1.jpg", Category = whC6 };
            Whiskey wh58 = new Whiskey { Name = "Hudson Ny", Description = "Hudson Ny Rye Whiskey   750ml", Price = 42, PhotoUrl = "https://citywinecellar.com/media/catalog/product/cache/9d26d59329362867a375d7ebcb87e847/0/8/083664874514.jpg", Category = whC6 };
            Whiskey wh59 = new Whiskey { Name = "WhistlePig 15 Year", Description = "WhistlePig 15 Year Rye Whiskey 750ml", Price = 90, PhotoUrl = "https://www.drinksupermarket.com/media/catalog/product/cache/0288c1cb4e2e8b328879830e17ef5901/w/h/whistlepig-15yo-vermont-rye-whiskey-750ml_temp.jpg", Category = whC6 };
            Whiskey wh60 = new Whiskey { Name = "Barrell Seagrass ", Description = "Barrell Seagrass Rye Whiskey 750ml", Price = 75, PhotoUrl = "https://norfolkwineandspirits.com/wp-content/uploads/2021/04/barrell-seagrass-rye-whiskey-1000x1000-1.jpg", Category = whC6 };
            Whiskey wh61 = new Whiskey { Name = "FEW Straight ", Description = "FEW Straight Rye Whiskey 750ml", Price = 50, PhotoUrl = "https://cdn.caskers.com/catalog/product/cache/ce56bc73870585a38310c58e499d2fd4/f/e/few-straight-rye-whiskey-1.jpg", Category = whC6 };
            Whiskey wh62 = new Whiskey { Name = "Wilderness Trail", Description = "Wilderness Trail Rye Whiskey 750ml", Price = 70, PhotoUrl = "https://cdn.shopify.com/s/files/1/0404/4898/3190/products/Untitleddesign-2021-01-07T135748.889_1250x.png?v=1610339669", Category = whC6 };

            Whiskey wh4 = new Whiskey { Name = "Johnnie Walker", Description = "Johnnie Walker Blue Label Scotch  Whisky 70cl 2.0 Icons Bottle", Price = 110, PhotoUrl = "https://www.malts.com/en-gb/static/794771079f7422e1fc94398e2a9a83bb/f08e8/5000267187204_Johnnie_Walker_Blue_Label_700ml_Icon_Bottle_CF_1_4b3feef4b1.jpg", Category = whC7 };
            Whiskey wh63 = new Whiskey { Name = "Laphroaig 10 Year Old Islay Single Malt", Description = " Laphroaig 10 Year Old Islay Single Malt Scotch Whisky 750ml", Price = 60, PhotoUrl = "https://cdn11.bigcommerce.com/s-e6b77/images/stencil/1280x1280/products/17062/17422/laphroaig-10-year-old-islay-single-malt-scotch__84406.1607774460.jpg?c=2", Category = whC7 };
            Whiskey wh64 = new Whiskey { Name = "The Famous Grouse", Description = " The Famous Grouse Scotch Whisky 750ml", Price = 20, PhotoUrl = "https://thepartysource.com/image/cache/catalog/inventory/FAMOUS-GROUSE-BLENDED-SCOTCH-750-ML-500x500.jpg", Category = whC7 };
            Whiskey wh65 = new Whiskey { Name = "Johnnie Walker Double Black Label", Description = " Johnnie Walker Double Black Label Blended Scotch Whisky 750ml", Price = 35, PhotoUrl = "https://d2j6dbq0eux0bg.cloudfront.net/images/64027105/2553508905.jpg", Category = whC7 };
            Whiskey wh66 = new Whiskey { Name = "Ardbeg  Uigeadail ", Description = " Ardbeg  Uigeadail Scotch Whisky 750ml", Price = 100, PhotoUrl = "https://cdn2.bigcommerce.com/server5500/tpbc2s65/products/3165/images/3318/ardbeg_corryvreckan750__77792.1366400925.1280.1280.jpg?c=2", Category = whC7 };
            Whiskey wh67 = new Whiskey { Name = " The Macallan Sherry Oak 12 Year Old", Description = " The Macallan Sherry Oak 12 Year Old Single Malt Scotch Whisky 750ml", Price = 70, PhotoUrl = "https://cdn.shopify.com/s/files/1/0227/0581/products/Macallan-12-Year-Old-Sherry-Oak-Scotch-Whisky-750ML-BTL_6_600x.jpg?v=1644151337", Category = whC7 };
            Whiskey wh68 = new Whiskey { Name = "Johnnie Walker High", Description = "Johnnie Walker High Rye Blended Scotch Whisky 750ml", Price = 35, PhotoUrl = "https://www.binnys.com/globalassets/catalogs/binnys/12/1233/123319/123319.jpg?width=690&height=690&mode=BoxPad&bgcolor=fff", Category = whC7 };
            Whiskey wh69 = new Whiskey { Name = "Shackleton", Description = " Shackleton Blended Malt Scotch Whisky 750ml", Price = 35, PhotoUrl = "https://www.marketviewliquor.com/mm5/graphics/00000001/SHACKLETONSCOTCH.jpg", Category = whC7 };
            Whiskey wh70 = new Whiskey { Name = "Grant's Family Reserve", Description = "Grant's Family Reserve Scotch Whisky 750ml", Price = 16, PhotoUrl = "https://www.thewhiskyworld.com/images/grants-family-reserve-p1389-15276_image.jpg", Category = whC7 };
            Whiskey wh71 = new Whiskey { Name = "Royal Salute 21 Year", Description = " Royal Salute 21 Year Scotch Whisky 750ml", Price = 150, PhotoUrl = "https://www.stansliquor.com/wp-content/uploads/2021/09/image_a4b8a9da-9625-4435-a49f-10230afb7b77_1024x1024.jpg", Category = whC7 };




            List<Whiskey> whiskeys = new List<Whiskey> { wh1, wh2, wh3, wh4, wh5,wh6,wh7,wh8,wh9,wh10,wh11,wh12,wh13,wh14,
                                                         wh15,wh16,wh17,wh18,wh19,wh20,wh21,wh22,wh23,wh24,
                                                         wh25,wh26,wh27,wh28,wh29,wh30,wh31,wh32,wh33,wh34,
                                                         wh35,wh36,wh37,wh38,wh39,wh40,wh41,wh42,
                                                         wh43,wh44,wh45,wh46,wh47,wh48,wh49,wh50,wh51,wh52,
                                                         wh53,wh54,wh55,wh56,wh57,wh58,wh59,wh60,wh61,wh62,
                                                         wh63,wh64,wh65,wh66,wh67,wh68,wh69,wh70,wh71};

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
