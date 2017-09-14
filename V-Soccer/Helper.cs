using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V_Soccer.Models;

namespace V_Soccer
{
    public class Helper
    {
        private static DataContext db = new DataContext();

        public static Gener CheckGener(string gener)
        {
            var genero = db.Geners.Where(g => g.Name == gener).FirstOrDefault();
            if(genero == null)
            {
                genero = new Gener { Name = gener };
                db.Geners.Add(genero);
                db.SaveChanges();
                return genero;
            }
            else
            {
                return genero;
            }
        }
    }
}