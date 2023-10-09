using System.Collections;
using UnityEngine;

public class GarageDoorController : MonoBehaviour
{
    [SerializeReference] private Animator garageDoorAnimator;

    public void PlayOpenDoorAnim()
    {
        garageDoorAnimator.SetTrigger("Open");

        SceneLoader.Instance.LoadMainScene();
    }
    public void PlayCloseDoorAnim() 
    {
        garageDoorAnimator.SetTrigger("Close");
    }
}
