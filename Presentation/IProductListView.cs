﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;

namespace Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> Products);
        Model.CustomerType CustomerType { get; }
        string ErrorMessage { set; }
    }
}
