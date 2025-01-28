using UnityEngine;
using Zenject;

public class CursorPositionInstaller : MonoInstaller
{
    [SerializeField] private CursorPosition _cursor;

    public override void InstallBindings()
    {
        Container.Bind<CursorPosition>().FromInstance(_cursor).AsSingle();
    }
}
