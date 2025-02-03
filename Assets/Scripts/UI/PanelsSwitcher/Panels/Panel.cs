using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public abstract class Panel : MonoBehaviour
{
    protected IPanelSwitcher Switcher;

    private Image _image;

    private float _tranparentValue = 0;
    private float _defaulValue = 1;
    private float _duration = 1f;

    private void Awake() => _image = GetComponent<Image>();

    public abstract void SwitchToNextPanel();
    public abstract void ShowingAction();

    public void OnShow()
    {
        gameObject.SetActive(true);
        _image.DOFade(_defaulValue, _duration).From(_tranparentValue).OnComplete(() => ShowingAction());
    }

    public void OnHide()
    {
        _image.DOFade(_tranparentValue, _duration).OnComplete(() => gameObject.SetActive(false));
    }

    [Inject]
    private void Construct(IPanelSwitcher switcher) => Switcher = switcher;
}
