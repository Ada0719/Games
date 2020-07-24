using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string sceneToChangeTo)
    {
        //Application.loadScene("Name of Leverl");
        //SceneManager.LoadScene("Name of Leverl");
        SceneManager.LoadSceneAsync(sceneToChangeTo);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();// This doesn't work in the Editor
    }
}
