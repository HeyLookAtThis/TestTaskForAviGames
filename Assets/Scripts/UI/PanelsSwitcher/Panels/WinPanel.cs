using System.Collections;
using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField] private ParticleSystem _leftParticle;
    [SerializeField] private ParticleSystem _rightParticle;

    private Coroutine _waitingTicker;

    public override void SwitchToNextPanel() => Switcher.SwitchPanel<MapPanel>();

    public override void ShowingAction()
    {
        PlayParticles();

        if (_waitingTicker != null)
            StopCoroutine(_waitingTicker);

        _waitingTicker = StartCoroutine(Ticker());
    }

    private void PlayParticles()
    {
        _leftParticle.Play();
        _rightParticle.Play();
    }

    private IEnumerator Ticker()
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
            SwitchToNextPanel();
            yield break;
        }
    }
}
