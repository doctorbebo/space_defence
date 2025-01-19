using System.Collections.Generic;
using UnityEngine;

namespace Targeting
{
    public interface ITargetFinder
    {
        public IEnumerable<Transform> ViableTargets { get; }
    }
}