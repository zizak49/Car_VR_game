using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollision : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private Collider collider, grabCollider;

    public void Grab() {
        Physics.IgnoreCollision(player, collider, true);
        Physics.IgnoreCollision(player, grabCollider, true);
    }
    public void Relese() {
        Physics.IgnoreCollision(player, collider, false);
        Physics.IgnoreCollision(player, grabCollider, false);
    }
}
