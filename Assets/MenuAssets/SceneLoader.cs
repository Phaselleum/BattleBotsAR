using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNumber;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
    public void Select() {
        OnMouseDown();
    }
}
