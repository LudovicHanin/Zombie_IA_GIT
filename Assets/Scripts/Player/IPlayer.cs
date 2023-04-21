using System.Collections;
using UnityEngine;

public interface IPlayer
{
    public Transform PlayerTransform { get; }

    public IEnumerator PlayerHit();
}
