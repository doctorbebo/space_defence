using System.Collections.Generic;
using UnityEngine;

namespace Ordnance
{
    public interface ITargetFinder
    {
        public IEnumerable<Transform> ViableTargets { get; }
    }
}