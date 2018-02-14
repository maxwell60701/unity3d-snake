using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public interface Isnakehead
    {
        void Move();
        Vector3 Turn();

        void CreateBody();
    }
}
