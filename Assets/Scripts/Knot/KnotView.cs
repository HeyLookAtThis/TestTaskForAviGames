using UnityEngine;

public class KnotView : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _highlightedSprite;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _defaultSprite;
    }

    public void SetHighlightedSprite() => _spriteRenderer.sprite = _highlightedSprite;
    public void SetDefaultSprite() => _spriteRenderer.sprite = _defaultSprite;

    public void IncreaseOrderInLayer() => _spriteRenderer.sortingOrder++;
    public void DecreaseOrderInLayer() => _spriteRenderer.sortingOrder--;
}
