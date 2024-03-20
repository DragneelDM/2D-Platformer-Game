using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public void MoveMe(Transform parent,Vector2 endpos){
        transform.parent = parent;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, endpos, Time.deltaTime);
    }
}
