using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Z_FollowBehaviour : MonoBehaviour
{
    public UnityAction OnChange;
    public void FollowTarget()
    {
        Debug.Log("Follow Target");
        
        if(Input.GetKeyDown(KeyCode.A))
            OnChange?.Invoke();
    }
}
