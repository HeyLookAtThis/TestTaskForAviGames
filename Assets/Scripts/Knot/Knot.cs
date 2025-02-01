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
    private UnityAction _startedMoving;
    private UnityAction _stoppedMoving;

    public event UnityAction<Vector2> PositionChanged
    {
        add => _positionChanged += value;
        remove => _positionChanged -= value;
    }

    public event UnityAction StartedMoving
    {
        add => _startedMoving += value;
        remove => _startedMoving -= value;
    }

    public event UnityAction StoppedMoving
    {
        add => _stoppedMoving += value;
        remove => _stoppedMoving -= value;
    }

    public KnotView View => _view;
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
        _view.IncreaseOrderInLayer();
        _view.PlayClick();
        _startedMoving?.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _canMove = false;
        _view.DecreaseOrderInLayer();
        _stoppedMoving?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerPress == null)
            _view.SetHighlightedSprite();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerPress == null)
            _view.SetDefaultSprite();
    }

    public void SetPosition(Vector3 position) => transform.position = position;
    public void Initialize(CursorPosition cursorPosition) => _cursor = cursorPosition;
}
