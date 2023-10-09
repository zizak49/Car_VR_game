using TMPro;
using UnityEngine;

public class DriveState : State
{
    public DriveState(float accelerationForce, TextMeshProUGUI text) : base(accelerationForce, text)
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
