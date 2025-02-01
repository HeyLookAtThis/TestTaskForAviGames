using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinPanel : MonoBehaviour, IPanel
{

    [SerializeField] private ParticleSystem _leftParticle;
    [SerializeField] private ParticleSystem _rightParticle;

    private Image _image;
    private IPanelSwitcher _switcher;
    private Coroutine _toMapPanelSwitcher;

    private void Awake() => _image = GetComponent<Image>();

    public void OnShow()
    {
        gameObject.SetActive(true);

        float tranparentValue = 0;
        float defaulValue = 1;
        float duration = 0.25f;
        int loops = 2;

        _image.DOFade(defaulValue, duration).From(tranparentValue).SetLoops(loops, LoopType.Yoyo).OnComplete(() => SwitchToMapPanel());
    }

    public void OnHide() => gameObject.SetActive(false);

    private void PlayParticles()
    {
        _leftParticle.Play();
        _rightParticle.Play();
    }

    private void SwitchToMapPanel()
    {
        PlayParticles();

        if (_toMapPanelSwitcher != null)
            StopCoroutine(_toMapPanelSwitcher);

        _toMapPanelSwitcher = StartCoroutine(PanelSwitcher());
    }

    private IEnumerator PanelSwitcher()
    {
        float seconds = 3f;
        var waitTime = new WaitForSeconds(seconds);
        bool isTicked = false;

        while(isTicked == false)
        {
            isTicked = true;
            yield return waitTime;
        }

        if (isTicked)
        {
            _switcher.SwitchPanel<MapPanel>();
            yield break;
        }
    }

    [Inject]
    private void Construct(IPanelSwitcher switcher) => _switcher = switcher;
}
