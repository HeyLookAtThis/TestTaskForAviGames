using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Button))]
public class SkipButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private CanvasGroup _canvasGroup;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();
    private void OnEnable() => AddListener(OnHide);
    private void OnDisable() => RemoveListener(OnHide);

    public void AddListener(UnityAction action) => _button.onClick.AddListener(action);
    public void RemoveListener(UnityAction action) => _button.onClick.RemoveListener(action);

    private void OnHide()
    {
        float tranparentValue = 0;
        float duration = 0.25f;

        _canvasGroup.DOFade(tranparentValue, duration).OnComplete(() => gameObject.SetActive(false));
    }
}