﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Infrastructure
{
    public interface IAdoNetDbFactory
    {
        AdoNetDbContext Init();
    }
}
