using UnityEngine;

public class SkipMediator : MonoBehaviour
{
    [SerializeField] private SkipButton _skipButton;
    [SerializeField] private KnotSpawner _knotSpawner;
    [SerializeField] private RopeSpawner _ropeSpawner;

    private void OnEnable()
    {
        _skipButton.AddListener(_knotSpawner.Disable);
        _skipButton.AddListener(_ropeSpawner.Clear);
    }

    private void OnDisable()
    {
        _skipButton.RemoveListener(_knotSpawner.Disable);
        _skipButton.RemoveListener(_ropeSpawner.Clear);
    }
}
