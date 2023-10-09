using TMPro;

public abstract class State
{
    public float accelerationForce;
    public TextMeshProUGUI text;

    public State(float accelerationForce, TextMeshProUGUI text)
    {
        this.accelerationForce = accelerationForce;
        this.text = text;
    }

    public abstract void EnterState();
    public abstract void ExitState();
}
