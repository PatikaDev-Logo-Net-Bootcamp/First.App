using First.App.Business.Abstract;

using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First.App.Business.Concretes
{
    public class UserService : IUserService { 

        private readonly IRepository<User> repository;
        
        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
      
        }

        public List<User> GetAllUser()
        {
            return repository.Get().ToList();
        }
    }
}
