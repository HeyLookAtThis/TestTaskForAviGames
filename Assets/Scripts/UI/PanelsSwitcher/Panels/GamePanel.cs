using UnityEngine;

public class GamePanel : MonoBehaviour, IPanel
{
    public void OnHide() => gameObject.SetActive(false);
    public void OnShow() => gameObject.SetActive(true);
}
