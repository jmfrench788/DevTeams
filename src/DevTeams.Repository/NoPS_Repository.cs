using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NoPluralSight_Repository
{
    private readonly List<Developer> _noPluralSight = new List<Developer>();

      public bool AddDevToNoPluralSight(Developer developer)
        {
            foreach(var Developer in _noPluralSight)
            {
                if(developer.HasPluralsight == false)
                {
                    _noPluralSight.Add(developer);
                    return true;
                }  
            }
            return false;
          
        }
         public List<Developer> GetAllPSDevelopers()
        {
            return _noPluralSight;
        }
}