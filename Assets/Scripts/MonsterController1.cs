using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController1 : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //この方法では取得できない
        //animator = GetComponent<Animator>();

        //１階層下のAnimatorを取得
        animator = this.transform.Find("UnitRoot").gameObject.GetComponent<Animator>();
    
        // もし敵を倒したあと敵のオブジェクトを削除
        Destroy(gameObject, 0.5f);
    }
}