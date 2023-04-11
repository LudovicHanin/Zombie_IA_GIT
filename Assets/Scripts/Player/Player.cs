using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public Transform PlayerTransform => transform;

    private void Start()
    {
        PlayerManager.Instance.AddPlayer(this);
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.RemovePlayer(this);
    }
}
