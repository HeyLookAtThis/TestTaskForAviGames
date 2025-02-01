using UnityEngine;

public class MapPanel : MonoBehaviour, IPanel
{
    public void OnHide() => gameObject.SetActive(false);
    public void OnShow() => gameObject.SetActive(true);
}
