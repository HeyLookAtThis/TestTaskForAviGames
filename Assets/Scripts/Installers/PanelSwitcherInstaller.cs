using UnityEngine;
using Zenject;

public class PanelSwitcherInstaller : MonoInstaller
{
    [SerializeField] private PanelSwitcher _switcher;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PanelSwitcher>().FromInstance(_switcher).AsSingle();
    }
}
