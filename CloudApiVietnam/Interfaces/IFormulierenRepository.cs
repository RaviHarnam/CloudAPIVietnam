using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiVietnam.Models;

namespace CloudApiVietnam.Interfaces
{
 public interface IFormulierenRepository
 {
   void AddFormulieren(Formulieren formulier);
   void RemoveFormulieren(Formulieren formulier);
   Formulieren GetForm(int id);
   List<Formulieren> getListOfFormFilterdOnDate(DateTime date);
 }
}
