﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Orange
{
    //Class for creating an admin.
    public class Admin : Person
    {
        public Admin()
        {
            UserName = "ADMIN";
            Password = "ADMIN";
            IsAdmin = true;
        }
    }
}
