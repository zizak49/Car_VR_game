using UnityEngine;

public class CarController : MonoBehaviour
{
    private XRIDefaultInputActions inputActions;
    private new Rigidbody rigidbody;

    [SerializeField] private float accelerationForce = 50f;
    [SerializeField] private float brakingForce = 300f;

    [SerializeField] private WheelCollider frontR;
    [SerializeField] private WheelCollider frontL;

    [SerializeField] private Vector3 centerOfMass;

    [SerializeField] private GearController gearController;

    public float AccelerationForce { get => accelerationForce; set => accelerationForce = value; }
    public float BrakingForce { get => brakingForce; set => brakingForce = value; }

    private void OnEnable()
    {
        inputActions.XRIRightHandInteraction.Enable();
        inputActions.XRILeftHandInteraction.Enable();
    }
    private void OnDisable()
    {
        inputActions.XRIRightHandInteraction.Disable();
        inputActions.XRILeftHandInteraction.Disable();
    }

    private void Awake()
    {
        GameManager.Instance.DrivingPlayerObj = gameObject;
        inputActions = new XRIDefaultInputActions();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigidbody.centerOfMass = centerOfMass;
    }

    private void FixedUpdate()
    {
        if (inputActions.XRIRightHandInteraction.ActivateValue.ReadValue<float>() > 0.01f)
        {
            frontL.motorTorque = gearController.GetCurrentGearState().accelerationForce;
            frontR.motorTorque = gearController.GetCurrentGearState().accelerationForce;
        }
        else
        {
            frontL.motorTorque = 0;
            frontR.motorTorque = 0;
        }

        if (inputActions.XRILeftHandInteraction.ActivateValue.ReadValue<float>() > 0.01f)
        {
            frontL.brakeTorque = brakingForce;
            frontR.brakeTorque = brakingForce;
        }
        else
        {
            frontL.brakeTorque = 0;
            frontR.brakeTorque = 0;
        }
    }
}
