using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCNR
{
    public class Consumable
    {
        string name {  get; set; }
        int id {  get; set; }
        public Consumable(string name, int id) 
        {
            this.name = name;
            this.id = id;
        }
        //take a consumable and use its id and name to provide its effect
        public void ConsumableSwitchTable(Consumable consumable) 
        {
            string ConsumName = consumable.name;
            int IdToRemove = consumable.id;
            ConsumName = ConsumName.ToLower();
            //
            switch(ConsumName)
            {
                case "strength":
                    //Change Player base damage by 1
                    ///Player.BaseDmg += 1
                    break;
                case "defense":
                    //Increase Player base damage by 1
                    ///Player.BaseDmg +=1
                    break;
                default:
                    Console.WriteLine("I don't know how to use that");
                    break;
            }
        }
    }
}
