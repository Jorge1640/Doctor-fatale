using UnityEngine;

public class TempParentLogic : MonoBehaviour
{
    public static TempParentLogic Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
