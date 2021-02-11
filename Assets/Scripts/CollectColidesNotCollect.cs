using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectColidesNotCollect : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D notCollect)
    {

        Vector3 originalPos = transform.localPosition;
        float x = originalPos.x + 2f;
        transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
    }

}
