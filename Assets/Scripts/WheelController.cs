using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private HingeJoint hingeJoint;

    public float wheelRotation;

    [SerializeField] private GameObject wheelAnim;

    private void Awake()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        wheelRotation = hingeJoint.angle;
        wheelAnim.transform.rotation = Quaternion.Lerp(wheelAnim.transform.rotation, transform.rotation, 0.01f);
    }
}
