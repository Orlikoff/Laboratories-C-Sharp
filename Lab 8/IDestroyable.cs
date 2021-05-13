using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    interface IDestroyable
    {
        const string message = "The Device Is Being Destroyed!";
        public void DestroySelf();
    }
}
