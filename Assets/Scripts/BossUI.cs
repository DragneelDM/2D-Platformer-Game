using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    GameObject child1;
    GameObject child2;
    Animator animator;

    int bossDamage;
    void Start()
    {
        child1 = transform.GetChild(0).gameObject;
        child2 = transform.GetChild(1).gameObject;
        child1.SetActive(false);
        child2.SetActive(false);
        animator = child1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("GetRekt", bossDamage);
    }

    public void CallGuys(){
        child1.SetActive(true);
        child2.SetActive(true);
    }

    public void UpdateUI(){
        bossDamage++;
    }
}
