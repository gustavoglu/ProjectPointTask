using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(x => x.AddProfile<DomainToVieModelProfile>());
        }
    }

}