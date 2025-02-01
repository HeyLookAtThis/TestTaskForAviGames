using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(AudioSource))]
public class RopeView : MonoBehaviour
{
    private const int BegginingPositionIndex = 0;
    private const int EndginingPositionIndex = 1;

    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private AudioClip _stretchingSound;

    private LineRenderer _lineRenderer;
    private AudioSource _audioSource;

    private Coroutine _stretcher;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _stretchingSound;
        _audioSource.loop = false;
    }

    public void SetLineBeggining(Vector2 position) => _lineRenderer.SetPosition(BegginingPositionIndex, position);
    public void SetLineEnding(Vector2 position) => _lineRenderer.SetPosition(EndginingPositionIndex, position);

    public void SetRed()
    {
        if (_lineRenderer.material != _redMaterial)
            _lineRenderer.material = _redMaterial;
    }

    public void SetGreen()
    {
        if (_lineRenderer.material != _greenMaterial)
            _lineRenderer.material = _greenMaterial;
    }

    public void PlayStretching()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
            BeginIncreaseVolume();
        }
    }

    public void OnStopStretching() => _audioSource.Stop();

    private void BeginIncreaseVolume()
    {
        StopIncreaseVolume();
        _stretcher = StartCoroutine(StretchVolumeIncreaser());
    }

    private void StopIncreaseVolume()
    {
        if (_stretcher != null)
            StopCoroutine(_stretcher);
    }

    private IEnumerator StretchVolumeIncreaser()
    {
        var waitTime = new WaitForEndOfFrame();

        float minValue = 0;
        float maxValue = 1;

        _audioSource.volume = minValue;

        while (_audioSource.volume < maxValue)
        {
            _audioSource.volume += Time.deltaTime;
            yield return waitTime;
        }

        if (_audioSource.volume == maxValue || _audioSource.isPlaying == false)
            yield break;
    }
}
