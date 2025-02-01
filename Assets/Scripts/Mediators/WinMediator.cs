using UnityEngine;

public class WinMediator : MonoBehaviour
{
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private RopeStorage _ropeStorage;
    [SerializeField] private KnotSpawner _knotSpawner;
    [SerializeField] private RopeSpawner _ropeSpawner;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _ropeStorage.RopesCameUndone += _winPanel.OnShow;
        _ropeStorage.RopesCameUndone += _knotSpawner.Respawn;
        _ropeStorage.RopesCameUndone += _ropeSpawner.Clear;
        _ropeStorage.RopesCameUndone += _score.OnAddWinCount;
    }

    private void OnDisable()
    {
        _ropeStorage.RopesCameUndone -= _winPanel.OnShow;
        _ropeStorage.RopesCameUndone -= _knotSpawner.Respawn;
        _ropeStorage.RopesCameUndone -= _ropeSpawner.Clear;
        _ropeStorage.RopesCameUndone -= _score.OnAddWinCount;
    }
}
