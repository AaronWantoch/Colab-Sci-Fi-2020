using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuardBaseState
{
    public abstract void EnterState(GuardAI guard);
    public abstract void Update(GuardAI guard);
    public abstract void OnCollisionEnter(GuardAI guard);
}
