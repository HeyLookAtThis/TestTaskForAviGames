using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour, IPanelSwitcher
{
    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private MapPanel _mapPanel;

    private Panel _currentPanel;
    private List<Panel> _panels;

    private void Awake()
    {
        _panels = new List<Panel>()
        {
            _gamePanel,
            _winPanel,
            _mapPanel
        };

        SwitchPanel<GamePanel>();
    }

    public void SwitchPanel<T>() where T : Panel
    {
        Panel panel = _panels.FirstOrDefault(panel => panel is T);

        _currentPanel?.OnHide();
        _currentPanel = panel;
        _currentPanel.OnShow();
    }
}
