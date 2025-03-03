﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer;
class DummyProduct : ASubject
{
    public void ChangePrice(float price)
    {
        Notify(price);
    }
}