using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
public class KnotView : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    //private Image _image;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        //_image = GetComponent<Image>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
    }
}
