using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_Rental_MVC.Repositories
{
    public interface IRepository<T1, T2, T3, T4> where T1: class
    {


        Task<IEnumerable<T1>> GetAll(T3 text, T4 text2);
        Task<T1> GetById(T2 id);
        Task<T1> Insert(T1 Entity);
        Task Delete(T2 id);
        Task Save();
        Task Update(/*T2 id,*/ T1 Entity);




    
        
    }
}
