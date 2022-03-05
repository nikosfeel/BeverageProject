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

            Beer b1 = new Beer { Name = "Blue Moon", Description = "Blue Moon White Wheat Beer 330ml", Price = 2, PhotoUrl = " " };
            Beer b2 = new Beer { Name = "Moosehead", Description = "Moosehead Cracked Canoe Lager 355ml Can", Price = 2.5, PhotoUrl = " " };
            Beer b3 = new Beer { Name = "Andwell Brewing", Description = "Crouch, Hold, Engage Rich Red IPA 500ml", Price = 3, PhotoUrl = " " };
            Beer b4 = new Beer { Name = "Birra Moretti", Description = "Birra Moretti Premium Lager 330ml", Price = 2.7, PhotoUrl = " " };
            Beer b5 = new Beer { Name = "Innis & Gunn", Description = "Innis & Gunn Lager 12x 330ml", Price = 3.2, PhotoUrl = " " };

            Wine w1 = new Wine { Name= "Campo Viejo", Description= "Campo Viejo Winemakers Blend Red Wine 75cl", Price= 7.4, PhotoUrl=" " };
            Wine w2 = new Wine { Name= "Trivento", Description= "Trivento Reserve Malbec Red Wine 187ml", Price= 2.1, PhotoUrl=" " };
            Wine w3 = new Wine { Name= "Marismeno ", Description= "Sanchez Romate Fino Marismeno Sherry 75cl", Price= 15.2, PhotoUrl=" " };
            Wine w4 = new Wine { Name= "Liquid Diamond", Description= "Liquid Diamond Sauvignon Blanc White Wine 75cl", Price= 17, PhotoUrl=" " };
            Wine w5 = new Wine { Name= "La Capilla", Description= "La Capilla Crianza Red Wine 75cl", Price= 14, PhotoUrl=" " };

            Whiskey wh1 = new Whiskey { Name = "The Busker", Description = "The Busker Triple Cask Triple Smooth Irish Whiskey 70cl", Price =20, PhotoUrl =" "};
            Whiskey wh2 = new Whiskey { Name = "Jameson", Description = "Jameson Orange Spirit Drink 70cl", Price =24, PhotoUrl =" "};
            Whiskey wh3 = new Whiskey { Name = "Proclamation", Description = "Proclamation Blended Irish Whiskey 70cl", Price =27, PhotoUrl =" "};
            Whiskey wh4 = new Whiskey { Name = "Johnnie Walker", Description = "Johnnie Walker Blue Label Whisky 70cl 2.0 Icons Bottle", Price =110, PhotoUrl =" "};
            Whiskey wh5 = new Whiskey { Name = "Glenmorangie", Description = "Glenmorangie A Tale Of Winter Whisky 70cl", Price =82, PhotoUrl =" "};

            Spirit s1 = new Spirit { Name = "Ciroc", Description = "Ciroc Summer Citrus Vodka 70cl", Price =32, PhotoUrl = "" };
            Spirit s2 = new Spirit { Name = "Grace O'Malley", Description = "Grace O'Malley Heather Infused Irish Gin 70cl", Price =27, PhotoUrl = "" };
            Spirit s3 = new Spirit { Name = "Black Thistle", Description = "Bush Rum Original Spiced Rum 70cl", Price =25, PhotoUrl = "" };
            Spirit s4 = new Spirit { Name = "Bush Rum", Description = "Black Thistle London Dry Gin 70cl", Price =27, PhotoUrl = "" };
            Spirit s5 = new Spirit { Name = "Laplandia", Description = "Laplandia Espresso Vodka 20cl", Price =10, PhotoUrl = "" };
        }
    }
}
