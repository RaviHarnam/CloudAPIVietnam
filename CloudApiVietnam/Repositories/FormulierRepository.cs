using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudApiVietnam.Interfaces;
using CloudApiVietnam.Models;

namespace CloudApiVietnam.Repositories
{
  public class FormulierRepository : IFormulierenRepository
  {
    private ApplicationDbContext dbContext;

    public FormulierRepository(ApplicationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public void AddFormulieren(Formulieren formulier)
    {
      dbContext.Formulieren.Add(formulier);
      dbContext.SaveChanges();
    }

    public void RemoveFormulieren(Formulieren formulier)
    {
      dbContext.Formulieren.Remove(formulier);
      dbContext.SaveChanges();
    }

    public Formulieren GetForm(int id)
    {
      Formulieren form = dbContext.Formulieren.Where(f => f.Id == id).FirstOrDefault();
      return form;

    }

    public List<Formulieren> getListOfFormFilterdOnDate(DateTime date)
    {
      //filter op alles boven deze specifieke datum.
      List<Formulieren> listOfFormFilterdOnDate = dbContext.Formulieren.Where(f => f.Created > date).ToList();

      return listOfFormFilterdOnDate;
    }
  }
}