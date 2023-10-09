using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GearController : MonoBehaviour
{
    private State currentState, neutralState, driveState, reversState, parkedState;

    [SerializeField] private TextMeshProUGUI neutralText;
    [SerializeField] private TextMeshProUGUI driveText;
    [SerializeField] private TextMeshProUGUI reversText;
    [SerializeField] private TextMeshProUGUI parkedText;

    [SerializeField] private CarController carController;

    private void Start()
    {
        neutralState = new NeutralState(0, neutralText);
        driveState = new DriveState(carController.AccelerationForce, driveText);
        reversState = new ReversState(-carController.AccelerationForce, reversText);
        parkedState = new ParkedState (0, parkedText);

        currentState = parkedState;
        ChangeGearToPark();
    }

    public void ChangeGearToDrive() 
    {
        currentState.ExitState();
        currentState = driveState;
        currentState.EnterState();
        Debug.Log(currentState.ToString());
    }

    public void ChangeGearToRevers()
    {
        currentState.ExitState();
        currentState = reversState;
        currentState.EnterState();
        Debug.Log(currentState.ToString());
    }

    public void ChangeGearToNeutral()
    {
        currentState.ExitState();
        currentState = neutralState;
        currentState.EnterState();
        Debug.Log(currentState.ToString());
    }

    public void ChangeGearToPark()
    {
        currentState.ExitState();
        currentState = parkedState;
        currentState.EnterState();
        Debug.Log(currentState.ToString());
    }

    public State GetCurrentGearState() { return currentState; }
}
