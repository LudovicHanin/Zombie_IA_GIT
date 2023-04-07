using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public abstract class Z_State : StateMachineBehaviour
{
    public event UnityAction OnEnter = null;
    public event UnityAction OnUpdate = null;
    public event UnityAction OnExit = null;

    protected Z_Brain _brain = null;

    public virtual void InitBrain(Z_Brain brain)
    {
        _brain = brain;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
        AnimatorControllerPlayable controller)
    {
        OnEnter?.Invoke();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
        AnimatorControllerPlayable controller)
    {
        OnUpdate?.Invoke();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        OnExit?.Invoke();
    }
}
