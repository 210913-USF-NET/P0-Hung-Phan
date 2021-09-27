using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBL;
using Models;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
  public partial class CartMenu : IMenu
    {
    public void Start()
    {
        Console.WriteLine("How the fuck do I do this?");
    }

    public void AddCartToDB(Dictionary<CProduct, int> shoppingCart){
        
    }
    }
}
