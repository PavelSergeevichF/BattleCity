using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShellController
{

    private Vector3 _maxMove, _minMove;
    private ShellView _shellView;

    public ShellController(ShellView shellView)
    {
        _shellView = shellView;
        _maxMove = new Vector3(1000, 1400, 0);
        _minMove = new Vector3(-1575, -1400, 0);
    }

    public void Execute()
    {
        _shellView.transform.position = Vector3.MoveTowards(_shellView.transform.position, _shellView.TargetObject.transform.position, Time.deltaTime * _shellView.Speed);
        if (_shellView.transform.position.x > _maxMove.x) _shellView.Destroy();
        if (_shellView.transform.position.y > _maxMove.y) _shellView.Destroy();
        if (_shellView.transform.position.x < _minMove.x) _shellView.Destroy();
        if (_shellView.transform.position.y < _minMove.y) _shellView.Destroy();
        if (_shellView.SOPlayerData.EStatusLevel!= EStatusLevel.Default) _shellView.Destroy();
    }
}
