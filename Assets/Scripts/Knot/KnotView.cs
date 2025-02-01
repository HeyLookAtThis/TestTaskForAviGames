using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(AudioSource))]
public class KnotView : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _highlightedSprite;
    [SerializeField] private AudioClip _clip;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        _spriteRenderer.sprite = _defaultSprite;

        _audioSource.loop = false;
        _audioSource.clip = _clip;
    }

    public void DoFade()
    {
        float tranparentValue = 0;
        float duration = 0.25f;
        int loops = 2;

        _spriteRenderer.DOFade(tranparentValue, duration).SetLoops(loops, LoopType.Yoyo);
    }

    public void SetHighlightedSprite() => _spriteRenderer.sprite = _highlightedSprite;
    public void SetDefaultSprite() => _spriteRenderer.sprite = _defaultSprite;

    public void IncreaseOrderInLayer() => _spriteRenderer.sortingOrder++;
    public void DecreaseOrderInLayer() => _spriteRenderer.sortingOrder--;

    public void PlayClick() => _audioSource.Play();
}
