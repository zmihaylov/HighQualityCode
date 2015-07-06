using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassChef
{
    public class Chef
    {
        private string chefName;

        public Chef(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.chefName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.chefName = value;
            }
        }

        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);

            Console.WriteLine(this.Name + " cooked " + bowl);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Peel(Vegetable product)
        {
            product.Weight -= 10;
        }

        private void Cut(Vegetable product)
        {
            product.IsCutToPieces = true;
        }
    }
}
