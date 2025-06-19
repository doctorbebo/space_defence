using UnityEngine;

public interface IBehaviourSequence
{
    MonoBehaviour Behaviour { get; }
    bool Finished { get; }
}