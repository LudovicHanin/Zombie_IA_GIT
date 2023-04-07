using UnityEngine;

public class Z_Brain : MonoBehaviour
{
    [SerializeField] protected Animator _fsm = null;

    public virtual bool IsValid => _fsm;
    
    protected virtual void InitFSM()
    {
        
    }

    protected virtual void UpdateFSM()
    {
        
    }
}
