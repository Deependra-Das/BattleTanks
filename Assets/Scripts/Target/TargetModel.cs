using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TargetModel
{
    private TargetController _targetController;

    private TargetTypes _targetType;
    private GameObject _targetObject;
    private Sprite _img;
    private Vector3 _position;
    private Vector3 _rotation;
    private Vector3 _offset;

    public TargetModel(
        TargetTypes targetType,
        GameObject targetObject,
        Sprite img,
        Vector3 position,
        Vector3 rotation,
        Vector3 offset)
    {
        _targetType = targetType;
        _targetObject = targetObject;
        _img = img;
        _position = position;
        _rotation = rotation;
        _offset = offset;
    }
    public void SetTargetController(TargetController targetController)
    {
        _targetController = targetController;
    }

    public Sprite GetTargetSprite()
    {
        return _img;
    }
    public GameObject GetTargetObject()
    {
        return _targetObject;
    }
    public Vector3 GetTargetPosition()
    {
        return _position;
    }
    public Vector3 GetTargetRotation()
    {
        return _rotation;
    }
    public Vector3 GetTargetOffset()
    {
        return _offset;
    }
}
