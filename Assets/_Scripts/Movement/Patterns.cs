using System;
using System.Collections.Generic;
using Movement.Steps;
using UnityEngine;

namespace Movement
{
    public static class Patterns
    {
        public enum Names
        {
            Alpha
        }
        
        public static IEnumerable<Step> Retrieve(Names name)
        {
            return name switch
            {
                Names.Alpha => Alpha,
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }

        private static IEnumerable<Step> Alpha => new Step[] 
        {
            new MoveForward(25, 5),
            new Turn(25, 60, new Vector3(0f, 5f, 0f)),
            new MoveForward(25, 5)
        };
    }
}