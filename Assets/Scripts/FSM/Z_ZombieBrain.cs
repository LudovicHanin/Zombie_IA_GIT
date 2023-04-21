using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Z_ZombieBrain : Z_Brain
{
    [SerializeField] private Z_FollowBehaviour _followBehaviour = null;
    [SerializeField] private Z_AttackBehaviour _attackBehaviour = null;

   [SerializeField] private string inAttackRangeName = "InAttackRange";

    private IPlayer target;

    private bool inAttackRange = false;
    
    public IPlayer Target => target;

    public Z_FollowBehaviour FollowBehaviour => _followBehaviour;
    public Z_AttackBehaviour AttackBehaviour => _attackBehaviour;

    protected override void InitFSM()
    {
        base.InitFSM();

        // FollowBehaviour.OnChange += () =>
        // {
        //     _fsm.SetBool(inAttackRange, true);
        // };
    }

    protected override void UpdateFSM()
    {
        base.UpdateFSM();

        IPlayer searchTarget = GetNearestPlayer();
        if (target == null || target != searchTarget)
        {
            target = searchTarget;
        }

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.PlayerTransform.position);

            if (distance < 2 && !inAttackRange)
            {
                _fsm.SetBool(inAttackRangeName, true);
                inAttackRange = true;
                _attackBehaviour.Attack(target);
            }
            else if(inAttackRange && distance > 2)
            {
                _fsm.SetBool(inAttackRangeName, false);
                inAttackRange = false;
            }
        }
        else
        {
            Debug.Log("Target Null");
        }
    }

    IPlayer GetNearestPlayer()
    {
        List<IPlayer> players = PlayerManager.Instance.Players;
        Vector3 position = transform.position;
        IPlayer nearestPlayer = players[0];
        float nearestDistance = Single.MaxValue;
        foreach (IPlayer player in players)
        {
            float distance = Vector3.Distance(position, player.PlayerTransform.position);
            if (nearestDistance > distance)
            {
                nearestPlayer = player;
                nearestDistance = distance;
            }
        }

        return nearestPlayer;
    }
}
