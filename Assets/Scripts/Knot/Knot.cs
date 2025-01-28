using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

public class Knot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private KnotView _view;

    private bool _canMove;

    private CursorPosition _cursor;

    private UnityAction<Vector2> _positionChanged;

    public event UnityAction<Vector2> PositionChanged
    {
        add => _positionChanged += value;
        remove => _positionChanged -= value;
    }

    public Vector2 Position => transform.position;

    private void Update()
    {
        if(_canMove == false) 
            return;

        SetPosition(_cursor.Value);
        _positionChanged?.Invoke(transform.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _canMove = true;
    }
    public void OnPointerUp(PointerEventData eventData) => _canMove = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerPress == null)
        _view.SetHighlightedSprite();
    }
    public void OnPointerExit(PointerEventData eventData) => _view.SetDefaultSprite();

    public void SetPosition(Vector3 position) => transform.position = position;
    public void Initialize(CursorPosition cursorPosition) => _cursor = cursorPosition;
}
