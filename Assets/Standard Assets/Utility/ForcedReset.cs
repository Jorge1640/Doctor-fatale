using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI; // para usar Image

// Si quieres obligar a que tenga un componente de UI
[RequireComponent(typeof(Image))]
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // si se presiona el botón "ResetObject" (mapeado en Input)
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            // recarga la escena actual
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
