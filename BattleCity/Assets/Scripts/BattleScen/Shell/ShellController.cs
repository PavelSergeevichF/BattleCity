using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShellController
{
    private ShellView _shellView;

    public ShellController(ShellView shellView)
    {
        _shellView = shellView;
    }

    public void Execute()
    {
        _shellView.transform.position = Vector3.MoveTowards(_shellView.transform.position, _shellView.TargetObject.transform.position, Time.deltaTime * _shellView.Speed);
    }
}
