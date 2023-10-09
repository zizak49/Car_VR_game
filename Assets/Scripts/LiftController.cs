using System.Collections;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private Transform minHeight;
    [SerializeField] private Transform maxHeight;
    private Vector3 currentHeight;

    [SerializeField] private float liftMoveTime;
    [SerializeField] private GameObject lift;

    void Start()
    {
        currentHeight = lift.transform.position;
    }

    public void MoveUp() 
    {
        StartCoroutine(Move(maxHeight.position));
    }

    public void MoveDown()
    {
        StartCoroutine(Move(minHeight.position));
    }

    IEnumerator Move(Vector3 target) 
    {
        float time = 0;
        while (time < liftMoveTime)
        {
            lift.transform.position = Vector3.Lerp(currentHeight, target, time/liftMoveTime);
            time += Time.deltaTime;
            yield return null;
        }
        currentHeight = lift.transform.position;
    }
}
