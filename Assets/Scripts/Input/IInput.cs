using System;

public interface IInput
{
    public event Action SlapClicked;
    public event Action MegaSlapClicked;
    public event Action ArmorClicked;
}
