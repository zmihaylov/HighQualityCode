using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassChef
{
    public class Bowl
    {
        private ICollection<Vegetable> itemsInBolw;

        public Bowl()
        {
            this.itemsInBolw = new List<Vegetable>();
        }

        public ICollection<Vegetable> ItemsInBowl
        {
            get
            {
                return new List<Vegetable>(this.itemsInBolw);
            }
        }

        public void Add(Vegetable product)
        {
            this.itemsInBolw.Add(product);
        }

        public override string ToString()
        {
            string listOfProducts = "";
            foreach (var product in this.ItemsInBowl)
            {
                listOfProducts += product + "; ";   
            }
            return listOfProducts;
        }
    }
}
