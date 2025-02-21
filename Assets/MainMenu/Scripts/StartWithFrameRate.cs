
using UnityEngine;

public class StartWithFrameRate : MonoBehaviour
{
    private void Awake() 
    {
        Application.targetFrameRate = 500;
    }
}
