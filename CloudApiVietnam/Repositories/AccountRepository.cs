using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudApiVietnam.Models;

namespace CloudApiVietnam.Repositories
{
  public class AccountRepository
  {
    private ApplicationDbContext dbContext;

    public AccountRepository(ApplicationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
  }
}