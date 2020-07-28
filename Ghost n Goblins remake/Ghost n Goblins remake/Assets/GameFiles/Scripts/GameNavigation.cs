using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Author:Andrew Devlin this script is to navigate thought scenes though the use of button. 
/// The way this code works is all the scenes that need to be navigated though must be in the scene to build which is located in the build settings. 
/// </summary>
public class GameNavigation : MonoBehaviour
{
    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
    }
}
