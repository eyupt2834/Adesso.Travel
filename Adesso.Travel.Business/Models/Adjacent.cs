using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Travel.Business.Models
{
    public class Adjacent
    {
        public List<int> CreateAdjacentList(int toFrom, int toWhere)
        {
            var Adjacents = new List<int>();
   
            var modToWhere = toWhere % 10 == 0 ? 10 : toWhere % 10;
            var modToFrom = toFrom % 10 == 0 ? 10 : toFrom % 10;

            if (toFrom > toWhere)
            {
                for (int i = toFrom; i >= toWhere; i--)
                {
                    var mod = i % 10 == 0 ? 10 : i % 10;

                    if (modToFrom <= modToWhere)
                    {
                        if (modToFrom <= mod && modToWhere >= mod)
                        {
                            Adjacents.Add(i);
                        }
                    }
                    else
                    {
                        if (modToFrom >= mod && modToWhere <= mod)
                        {
                            Adjacents.Add(i);
                        }
                    }
                }
            }
            else
            {

                for (int i = toFrom; i <= toWhere; i++)
                {
                    var mod = i % 10 == 0 ? 10 : i % 10;

                    if (modToFrom <= modToWhere)
                    {
                        if (modToFrom <= mod && modToWhere >= mod)
                        {
                            Adjacents.Add(i);
                        }
                    }
                    else
                    {
                        if (modToFrom >= mod && modToWhere <= mod)
                        {
                            Adjacents.Add(i);
                        }
                    }
                }
            }

            return Adjacents;
        }
    }
}
