using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetView : MonoBehaviour
{
    private TargetController _targetController;

    [SerializeField]
    private Image _targetImage;

    public void SetTargetController(TargetController targetController)
    {
        _targetController = targetController;
    }

    public void SetImage(Sprite targetSprite)
    {
        _targetImage.sprite = targetSprite;
    }

    public Image GetImage()
    {
        return _targetImage;
    }
    public Transform GetTarget()
    {
        return _targetController.GetTarget();
    }
    public Vector3 GetOffset()
    {
        return _targetController.GetOffset();
    }

}
