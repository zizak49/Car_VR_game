using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    public static SceneLoader Instance { get { return _instance; } }

    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        LoadTutorialScene();
    }
    private void LoadTutorialScene() 
    {
        StartCoroutine(LoadAsyncScene("Tutorial"));
    }
    public void LoadMainScene() 
    {
        SceneManager.UnloadSceneAsync("Tutorial");
        StartCoroutine(LoadAsyncScene("Main"));
    }
    IEnumerator LoadAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log(scene + " loaded");
    }
}
