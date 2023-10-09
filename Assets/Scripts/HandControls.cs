using UnityEngine;

public class HandControls : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotationSpeed = 100f;

    private Transform followTarget;
    private Rigidbody body;

    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    public bool isActive = true;

    private void Start()
    {
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();

        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
        body.maxAngularVelocity = float.PositiveInfinity;
    }

    private void Update()
    {
        PhysicsMove();
    }   

    private void PhysicsMove() 
    {     
        var positionWithOffset = followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(followTarget.position, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * followSpeed * distance * Time.deltaTime;

        var rotationnWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationnWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);

        if (Mathf.Abs(axis.magnitude) != Mathf.Infinity)
        {
            if (angle > 180.0f) 
            { 
                angle -= 360.0f; 
            }
            body.angularVelocity = angle * axis * Mathf.Deg2Rad * rotationSpeed * Time.deltaTime;
        }
    }

    private void EnableHandCollision() 
    {
        if (!isActive)
        {
            body.detectCollisions = true;
        }
    }

    private void DisableHandCollision() 
    {
        if (isActive)
        {
            body.detectCollisions = false;
        }
    }
}
