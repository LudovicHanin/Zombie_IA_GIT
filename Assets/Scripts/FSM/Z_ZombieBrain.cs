using UnityEngine;

public class Z_ZombieBrain : Z_Brain
{
    [SerializeField] private Z_FollowBehaviour _followBehaviour = null;
    [SerializeField] private Z_AttackBehaviour _attackBehaviour = null;

    [SerializeField] private string targetFound = "TargetFound";

    public Z_FollowBehaviour FollowBehaviour => _followBehaviour;
    public Z_AttackBehaviour AttackBehaviour => _attackBehaviour;

    protected override void InitFSM()
    {
        base.InitFSM();

        FollowBehaviour.OnChange += () =>
        {
            _fsm.SetBool(targetFound, true);
        };
    }
}
