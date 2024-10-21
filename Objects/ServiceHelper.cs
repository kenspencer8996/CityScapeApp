﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public static class ServiceHelper
    {
        public static IServiceProvider Services { get; set; }
        public static void Initialize(IServiceProvider serviceProvider) =>
            Services = serviceProvider;
        public static T GetService<T>() => Services.GetService<T>();
    }
}
