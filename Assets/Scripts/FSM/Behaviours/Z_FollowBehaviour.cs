using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Z_FollowBehaviour : MonoBehaviour
{
    public UnityAction OnChange;

    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private float speed = 10;
    public void FollowTarget(Vector3 targetPosition)
    {
        Debug.Log("Follow Target");

        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * speed);
        
        if(Input.GetKeyDown(KeyCode.A))
            OnChange?.Invoke();
    }
    
    public void FollowTarget(IPlayer target)
    {
        // Debug.Log("Follow Target");
        //
        if (target == null)
        {
            Debug.Log("Target in Follow Target is Null");
            return;
        }
        //
        // Vector3 targetPosition = target.PlayerTransform.position;
        //
        // Vector3 direction = (targetPosition - transform.position).normalized;
        // direction.y = 0f;
        // transform.Translate(direction * Time.deltaTime * speed);
        //
        // if(Input.GetKeyDown(KeyCode.A))
        //     OnChange?.Invoke();

        if (!_agent)
        {
            Debug.Log("No Agent");
            return;
        }

        _agent.SetDestination(target.PlayerTransform.position);
    }
}
