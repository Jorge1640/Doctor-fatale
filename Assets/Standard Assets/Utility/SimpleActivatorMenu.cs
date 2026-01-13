using System;
using UnityEngine;
using UnityEngine.UI;   // Necesario para usar Text

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // Referencia al texto en la UI (Canvas > Text)
        public Text camSwitchButton;

        // Referencia a los objetos/cámaras en la escena
        public GameObject[] objects;

        private int m_CurrentActiveObject;

        private void OnEnable()
        {
            // el objeto activo empieza desde el primero en el array
            m_CurrentActiveObject = 0;

            // Desactivamos todos menos el primero
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == m_CurrentActiveObject);
            }

            UpdateText();
        }

        public void NextCamera()
        {
            int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_CurrentActiveObject = nextactiveobject;

            UpdateText();
        }

        private void UpdateText()
        {
            if (camSwitchButton != null && objects.Length > 0)
            {
                camSwitchButton.text = "Camera: " + objects[m_CurrentActiveObject].name;
            }
        }
    }
}
