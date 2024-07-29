﻿using Dapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Ecomm_Project_11.Data;

namespace Ecomm_Project_11.DataAccess.Repository.IRepository
{
    public interface ISPCall:IDisposable
    {
       void Execute (string procedureName,DynamicParameters param=null);
       T Single<T>(string procedureName, DynamicParameters param = null);
       T OneRecord<T>(string procedureName, DynamicParameters param = null);
       IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);
        Tuple<IEnumerable<T1>,IEnumerable<T2>> List<T1,T2>(string procedureName, DynamicParameters param = null);
    }
}
