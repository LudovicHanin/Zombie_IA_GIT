using UnityEngine;

public class Z_FollowState : Z_State
{
    public override void InitState(Z_Brain brain)
    {
        base.InitState(brain);

        Z_ZombieBrain zombieBrain = (Z_ZombieBrain) _brain;
        if (!_brain)
        {
            Debug.Log("No Brain");
            return;
        }

        OnEnter += () =>
        {
            Debug.Log("Enter Follow");
        };

        OnUpdate += () =>
        {
            zombieBrain.FollowBehaviour.FollowTarget();
        };

        OnExit += () =>
        {
            Debug.Log("Exit Follow");
        };
    }
}
