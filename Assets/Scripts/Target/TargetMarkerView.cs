using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMarkerView : MonoBehaviour
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
    public Vector3 GetTargetPosition()
    {
        return _targetController.GetTargetPosition();
    }
    public Vector3 GetTargetOffset()
    {
        return _targetController.GetTargetOffset();
    }
    public void SetCanvasAsParent(Canvas canvas)
    {
        gameObject.transform.SetParent(canvas.gameObject.transform);
        gameObject.transform.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.transform.localScale = Vector3.one;
    }
    public void DisableMarker()
    {
        gameObject.SetActive(false);
    }
    public void EnableMarker()
    {
        gameObject.SetActive(true);
    }
}
