﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Shared.Attributes.ViewAttributes
{
   public class TabAttribute:Attribute
    {
        public TabAttribute() { }
        public string Title { get; set; }
    }
}
