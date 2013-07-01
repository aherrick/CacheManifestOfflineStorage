using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CacheMainfestOfflineStorage.Models
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
    }
}