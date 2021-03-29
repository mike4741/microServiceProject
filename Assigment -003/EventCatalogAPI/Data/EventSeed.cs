using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        public  static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
        }
    }
}
