using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    [SerializeField] private Vector3 _followOffset = Vector3.zero;

    [SerializeField] private float _cameraMovementSpeed = 20f;
    [SerializeField] private float _cameraLookAtSpeed = 100f;

    private bool _isAiming = false;

    public Vector3 TargetPosition
    {
        get
        {
            if(!_target)
            {
                return Vector3.zero;
            }

            return _target.position;
        }
    }
    public bool IsValid => _target;

    private void Update()
    {
        
    }

    private void FollowTarget()
    {
        
    }

    public void Aim()
    {
        _isAiming = !_isAiming;
    }
}
