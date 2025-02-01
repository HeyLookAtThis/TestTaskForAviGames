using UnityEngine;

public class SkipMediator : MonoBehaviour
{
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private SkipButton _skipButton;
    [SerializeField] private KnotSpawner _knotSpawner;
    [SerializeField] private RopeSpawner _ropeSpawner;

    private void OnEnable()
    {
        _skipButton.AddListener(_winPanel.OnShow);
        _skipButton.AddListener(_knotSpawner.Respawn);
        _skipButton.AddListener(_ropeSpawner.Clear);
    }

    private void OnDisable()
    {
        _skipButton.RemoveListener(_winPanel.OnShow);
        _skipButton.RemoveListener(_knotSpawner.Respawn);
        _skipButton.RemoveListener(_ropeSpawner.Clear);
    }
}
