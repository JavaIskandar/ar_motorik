using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
    [SerializeField]
    private GameObject loadingPanel;
    public int scene;
	// Use this for initialization
	public void OnClick () {
        if(loadingPanel != null)
        {
            if(Debuger.instance != null)
            {
                Debuger.instance.Log("clicked");
            }
            
            loadingPanel.SetActive(true);
            StartCoroutine(LoadYourAsyncScene());
        }
        else
        {
            Debuger.instance.Log("clicked");
            Application.LoadLevel(scene);
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
