using TMPro;
using UnityEngine;

public class ParkedState : State
{
    public ParkedState(float accelerationForce, TextMeshProUGUI text) : base(accelerationForce, text)
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
