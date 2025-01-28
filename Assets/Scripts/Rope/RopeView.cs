using UnityEngine;

public class RopeView : MonoBehaviour
{
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Rope _rope;

    public void SetRed()
    {
        Debug.Log("Red");
        if (_rope.LineRenderer.material != _redMaterial)
            _rope.LineRenderer.material = _redMaterial;
    }

    public void SetGreen()
    {
        Debug.Log("Green");

        if (_rope.LineRenderer.material != _greenMaterial)
            _rope.LineRenderer.material = _greenMaterial;
    }
}
