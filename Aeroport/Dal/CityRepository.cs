﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    public class CityRepository : BaseRepository<City>
    {
        public CityRepository(AeroportContext context)
            : base(context)
        {

        }
    }
}
