﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture
{
    public interface IUnitofWork
    {
        void Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}