using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ParallaxLevel : MonoBehaviour
{
    [SerializeField] GameObject parallaxStage;
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;
    [SerializeField] float durationTime = 5f;
    [SerializeField] float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > durationTime){
            CreateStage();
            elapsedTime = 0;
        }
    }

    void CreateStage(){
        Instantiate(parallaxStage, startPos, Quaternion.identity);;
        parallaxStage.GetComponent<MoveGround>().MoveMe(transform, endPos);
    }
}
