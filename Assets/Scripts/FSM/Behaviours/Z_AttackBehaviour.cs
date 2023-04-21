using UnityEngine;
using UnityEngine.AI;

public class Z_AttackBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent; 
    
    public void Attack(IPlayer target)
    {
        if (!_agent && TryGetComponent(out _agent))
        {
            return;
        }
        
        if(!_agent.isStopped) _agent.isStopped = true;

        StartCoroutine(target.PlayerHit());
    }
}
