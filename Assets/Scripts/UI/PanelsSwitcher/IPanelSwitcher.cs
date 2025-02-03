public interface IPanelSwitcher
{
    void SwitchPanel<T>() where T : Panel;
}
