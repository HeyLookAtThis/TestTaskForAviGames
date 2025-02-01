using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour, IPanelSwitcher
{
    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private MapPanel _mapPanel;

    private IPanel _currentPanel;
    private List<IPanel> _panels;

    private void Awake()
    {
        _panels = new List<IPanel>()
        {
            _gamePanel,
            _winPanel,
            _mapPanel
        };

        SwitchPanel<GamePanel>();
    }

    public void SwitchPanel<T>() where T : IPanel
    {
        IPanel panel = _panels.FirstOrDefault(panel => panel is T);

        _currentPanel?.OnHide();
        _currentPanel = panel;
        _currentPanel.OnShow();
    }
}
