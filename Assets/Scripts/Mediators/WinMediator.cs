using UnityEngine;

public class WinMediator : MonoBehaviour
{
    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private RopeStorage _ropeStorage;
    [SerializeField] private KnotStorage _knotStorage;
    [SerializeField] private KnotSpawner _knotSpawner;
    [SerializeField] private RopeSpawner _ropeSpawner;
    [SerializeField] private Score _score;

    private void Update()
    {
        if (_knotStorage.Checker.IsKnotsFree && _ropeStorage.Checker.IsRopesFree)
        {
            _knotSpawner.Disable();
            _ropeSpawner.Clear();
            _score.AddWinCount();
            _gamePanel.SwitchToNextPanel();
            gameObject.SetActive(false);
        }
    }
}
