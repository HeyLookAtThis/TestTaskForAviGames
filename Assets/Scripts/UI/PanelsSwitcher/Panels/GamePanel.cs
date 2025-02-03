using UnityEngine;

public class GamePanel : Panel
{
    [SerializeField] private RopeStorage _ropeStorage;
    [SerializeField] private SkipButton _skipButton;

    private void OnEnable()
    {
        _skipButton.AddListener(SwitchToNextPanel);
    }

    private void OnDisable()
    {
        _skipButton.RemoveListener(SwitchToNextPanel);
    }

    public override void ShowingAction()
    {
    }

    public override void SwitchToNextPanel() => Switcher.SwitchPanel<WinPanel>();
}
