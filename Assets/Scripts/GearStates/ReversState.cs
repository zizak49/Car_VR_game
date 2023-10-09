using TMPro;
using UnityEngine;

public class ReversState : State
{
    public ReversState(float accelerationForce, TextMeshProUGUI text) : base(accelerationForce, text)
    {
    }

    public override void EnterState()
    {
        text.color = Color.green;
    }

    public override void ExitState()
    {
        text.color = Color.white;
    }
}
