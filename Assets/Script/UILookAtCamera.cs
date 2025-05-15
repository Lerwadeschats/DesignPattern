using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {;
        transform.LookAt(_mainCamera.transform.position - _mainCamera.transform.forward);
    }
}
