using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TargetSpawner;

public class MarkerUI : MonoBehaviour
{

    public GameObject spawner;

    List<TargetView> targetViewList;

    private void Start()
    {
        targetViewList = new List<TargetView>();
    }

    public void SetTargetList()
    {
        foreach (Transform child in spawner.gameObject.transform)
        {
            if (child != null)
            {
                targetViewList.Add(child.gameObject.GetComponent<TargetView>());
            }
        }
    }

    private void Update()
    {
        int spanwerChildrenCount = spawner.gameObject.transform.childCount;
        if (spanwerChildrenCount > 0)
        {
            foreach (TargetView marker in targetViewList)
            {
                float minX = marker.GetImage().GetPixelAdjustedRect().width / 2;
                float maxX = Screen.width - minX;

                float minY = marker.GetImage().GetPixelAdjustedRect().height / 2;
                float maxY = Screen.height - minY;

                Vector2 pos = Camera.main.WorldToScreenPoint(marker.GetTarget().position + marker.GetOffset());

                if (Vector3.Dot((marker.GetTarget().position - transform.position), transform.forward) < 0)
                {
                    if (pos.x < Screen.width / 2)
                    {
                        pos.x = maxX;
                    }
                    else
                    {
                        pos.x = minX;
                    }
                }
                pos.x = Mathf.Clamp(pos.x, minX, maxX);
                pos.y = Mathf.Clamp(pos.y, minY, maxY);

                marker.GetImage().transform.position = pos;

                //meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
            }
        }
    


    }
}
