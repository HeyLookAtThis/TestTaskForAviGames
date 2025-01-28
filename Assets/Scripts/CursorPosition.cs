using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public Vector3 Value { get; private set; }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = -_camera.transform.position.z;
        Value = _camera.ScreenToWorldPoint(mousePosition);
    }
}
