﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        public GameObject attackPrefabLeft;
        public GameObject attackPrefabRight;

        private void Start()
        {
            //この方法では取得できない
            //animator = GetComponent<Animator>();

            //１階層下のAnimatorを取得
            animator = this.transform.Find("UnitRoot").gameObject.GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                //animator.SetInteger("Direction", 3);

                this.transform.localScale = new Vector2(1.5f, 1.5f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                //animator.SetInteger("Direction", 2);

                this.transform.localScale = new Vector2(-1.5f, 1.5f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                //animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                //animator.SetInteger("Direction", 0);
            }

            //ベクトルを正規化する（0または1）
            dir.Normalize();
            
            //animator.SetBool("IsMoving", dir.magnitude > 0);

            //Parametar名が違うので改造
            animator.SetBool("Run", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;

            //スペースキーで攻撃
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");

                //向きを調べる
                if (this.transform.localScale.x > 0.0f)
                {
                    //左向き
                    GameObject attack = Instantiate(attackPrefabLeft);
                    //座標のコピー（このスクリプトの位置）
                    attack.transform.position = this.transform.position;
                }
                else
                {
                    //右向き
                    GameObject attack = Instantiate(attackPrefabRight);
                    //座標のコピー（このスクリプトの位置）
                    attack.transform.position = this.transform.position;
                }
            }
        }
    }
}
