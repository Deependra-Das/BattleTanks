using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetModel
{
    private TargetController _targetController;

    private TargetTypes _targetType;
    private Sprite _img;
    private Transform _target;
    private Vector3 _offset;

    public TargetModel(
        TargetTypes targetType,
        Sprite img, 
        Transform target,
        Vector3 offset)
    {
        _targetType = targetType;
        _img = img;
        _target = target;
        _offset = offset;

        Debug.Log(target.position);
    }
    public void SetTargetController(TargetController targetController)
    {
        _targetController = targetController;
    }

    public Sprite GetTargetSprite()
    {
        return _img;
    }
    public Transform GetTarget()
    {
        return _target;
    }
    public Vector3 GetOffset()
    {
        return _offset;
    }
}
