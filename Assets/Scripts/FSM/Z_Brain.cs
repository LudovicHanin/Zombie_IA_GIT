using System;
using UnityEngine;

public class Z_Brain : MonoBehaviour
{
    [SerializeField] protected Animator _fsm = null;
    public virtual bool IsValid => _fsm;

    protected virtual void Start()
    {
        InitFSM();
    }

    protected virtual void Update()
    {
        UpdateFSM();
    }

    protected virtual void InitFSM()
    {
        if (!_fsm)
        {
            _fsm = GetComponent<Animator>();
        }
        
        if(!IsValid)return;

        Z_State[] states = _fsm.GetBehaviours<Z_State>();
        for (int i = 0; states != null && i < states.Length; i++)
        {
            states[i].InitState(this);
        }
    }

    protected virtual void UpdateFSM()
    {
        
    }
}
