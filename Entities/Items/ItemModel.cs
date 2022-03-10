using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Items
{
    public class ItemModel
    {    
        private List<Beer> Beers;
        private List<Spirit> Spirits;
        private List<Wine> Wines;
        private List<Whiskey> Whiskeys;

        
        public ItemModel(List<Beer> beers, List<Spirit> spirits, List<Wine> wines, List<Whiskey> whiskeys)
        {
            Beers = beers;
            Spirits = spirits;
            Wines = wines;
            Whiskeys = whiskeys;
        }

        public List<Beer> findAllBeers()
        {
            return this.Beers;
        }
        public List<Spirit> findAllSpirits()
        {
            return this.Spirits;
        }
        public List<Wine> findAllWines()
        {
            return this.Wines;
        }
        public List<Whiskey> findAllWhiskeys()
        {
            return this.Whiskeys;
        }

        public Beer FindBeer(string id)
        {
            return this.Beers.Single(b => b.Id.Equals(id));
        }
        public Spirit FindSpirit(string id)
        {
            return this.Spirits.Single(s => s.Id.Equals(id));
        }
        public Wine FindWine(string id)
        {
            return this.Wines.Single(w => w.Id.Equals(id));
        }
        public Whiskey FindWhiskey(string id)
        {
            return this.Whiskeys.Single(w => w.Id.Equals(id));
        }
    }
}
