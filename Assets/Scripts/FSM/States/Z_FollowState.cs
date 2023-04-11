using UnityEngine;
using UnityEngine.Animations;

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

        // OnUpdate += () =>
        // {
        //     zombieBrain.FollowBehaviour.FollowTarget(zombieBrain.Target);
        // };

        OnExit += () =>
        {
            Debug.Log("Exit Follow");
        };
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
        AnimatorControllerPlayable controller)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex, controller);
        
        Z_ZombieBrain zombieBrain = (Z_ZombieBrain) _brain;
        if (!_brain)
        {
            Debug.Log("No Brain");
            return;
        }
        
        zombieBrain.FollowBehaviour.FollowTarget(zombieBrain.Target);
    }
}
