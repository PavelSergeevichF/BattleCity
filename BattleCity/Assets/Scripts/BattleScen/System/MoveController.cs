using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveController
{

    private Vector3 _target;
    private Vector3 _maxMove, _minMove;
    private Vector3 _moveVector;
    private bool _isMove = false;
    private int _step = 50;
    private int _ticMove;
    private EVectorMove _eVectorMoveEnemy;
    private ETypObject _eTypObject;

    private float _speed;
    private float _force=100;
    private List<GameObject> _sprite;

    private GreedView _greedView;
    private GameObject _moveObject;


    public delegate void GetVectorMoveDelegate(EVectorMove orientation);
    public event GetVectorMoveDelegate TransleteVectorMove;

    public MoveController(GreedView greedView, GameObject moveObject, List<GameObject> sprite, float speed)
    {
        _greedView = greedView;
        _moveObject = moveObject;
        _speed = speed;
        _sprite = sprite;
        _maxMove = new Vector3(925, 1300, 0);
        _minMove = new Vector3(-1475, -1300, 0);
        SetTargetEnemy();
    }

    public void Execute(ETypObject eTypObject, ref bool isMove)
    {
        _eTypObject = eTypObject;
        if (eTypObject == ETypObject.Enemy)
        {
            MoveEnemy(_eVectorMoveEnemy);
            if (_ticMove < 1)
            {
                SetTargetEnemy();
            }
            _ticMove--;
        }
        isMove = _isMove;
        if (_isMove) Move();
    }
    public void MoveObject(EVectorMove vectorMove)
    {
        switch (vectorMove)
        {
            case EVectorMove.Up:
                if (_moveObject.transform.position.y + 1f < _maxMove.y) SetVector(0, _step);
                ClearSprite(); _sprite[0].SetActive(true); _moveObject.GetComponent<TanckObjectView>().EVectorMove = vectorMove;
                break;
            case EVectorMove.Down:
                if (_moveObject.transform.position.y - 1f > _minMove.y) SetVector(0, -_step);
                ClearSprite(); _sprite[2].SetActive(true); _moveObject.GetComponent<TanckObjectView>().EVectorMove = vectorMove;
                break;
            case EVectorMove.Left:
                if (_moveObject.transform.position.x - 1f > _minMove.x) SetVector(-_step, 0);
                ClearSprite(); _sprite[3].SetActive(true); _moveObject.GetComponent<TanckObjectView>().EVectorMove = vectorMove;
                break;
            case EVectorMove.Right:
                if (_moveObject.transform.position.x + 1f < _maxMove.x) SetVector(_step, 0);
                ClearSprite(); _sprite[1].SetActive(true); _moveObject.GetComponent<TanckObjectView>().EVectorMove = vectorMove;
                break;
        };
    }
    
    public void MoveEnemy(EVectorMove vectorMove)
    {
        MoveObject(vectorMove);
    }
    private void SetTargetEnemy()
    {
        _ticMove = Random.Range(1, 6) * 15;
        switch (Random.Range(1, 4))
        {
            case 1:
                _eVectorMoveEnemy = EVectorMove.Up;
                break;
            case 2:
                _eVectorMoveEnemy = EVectorMove.Down;
                break;
            case 3:
                _eVectorMoveEnemy = EVectorMove.Left;
                break;
            case 4:
                _eVectorMoveEnemy = EVectorMove.Right;
                break;
        }
        TransleteVectorMove?.Invoke(_eVectorMoveEnemy);
    }
    public void ClearSprite()
    {
        foreach (var sp in _sprite)
            sp.SetActive(false);
    }
    private void SetVector(int x, int y)
    {
        if (!_moveObject.GetComponent<TanckObjectView>().Bumper.Obstacle)
        {
            _target = new Vector3
                           (
                           _moveObject.transform.position.x + x,
                           _moveObject.transform.position.y + y,
                           0);
            if (_target.x > _maxMove.x) _target.x = _maxMove.x;
            if (_target.y > _maxMove.y) _target.y = _maxMove.y;
            if (_target.x < _minMove.x) _target.x = _minMove.x;
            if (_target.y < _minMove.y) _target.y = _minMove.y;
            _isMove = true;
        } 
    }

    public void ResetTarget()
    {
        SetVector(0,0);
    }
    private void Move()
    {
        if(!_moveObject.GetComponent<TanckObjectView>().Bumper.Obstacle)
        {
            _moveObject.transform.position = Vector3.MoveTowards(_moveObject.transform.position, _target, Time.deltaTime * _speed);
            if (CheckFinish(_moveObject.transform.position, _target))
            {
                _isMove = false;
                _moveObject.transform.position = _target;
            }
        }
        
    }
    private bool CheckFinish(Vector3 pos, Vector3 target)
    {
        float errorDist = 0.01f;
        return (pos.x - errorDist < target.x && pos.x + errorDist > target.x && pos.y - errorDist < target.y && pos.y + errorDist > target.y);
    }
}
