using System.Collections;
using UnityEditor;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public void Quit()
    {          
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
