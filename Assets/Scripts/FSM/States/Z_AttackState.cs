using UnityEngine;

public class Z_AttackState : Z_State
{
    public override void InitState(Z_Brain brain)
    {
        base.InitState(brain);

        OnEnter += () =>
        {
            Debug.Log("Enter Attack");
        };

        OnExit += () =>
        {
            Debug.Log("Exit Attack");
        };
    }
}
