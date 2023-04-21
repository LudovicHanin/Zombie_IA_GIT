using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private Material playerMat;
    
    public Transform PlayerTransform => transform;

    private void Start()
    {
        PlayerManager.Instance.AddPlayer(this);

        if (!playerMat) playerMat = GetComponent<Material>();
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.RemovePlayer(this);
    }
    
    public IEnumerator PlayerHit()
    {
        if (!playerMat)
        {
            Debug.Log("No Material for player");
            yield break;
        }

        Color color = playerMat.color;
        playerMat.color = Color.red;
        
        yield return new WaitForSeconds(1.5f);
        
        playerMat.color = color;
    }
}
