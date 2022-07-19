using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type1 : Enemy_Base
{


    [SerializeField, Header("最小位置")]
    private float TurnPointMin;

    [SerializeField, Header("最大位置")]
    private float TurnPointMax;

    private bool moveDirectionRight;

    Animator animator;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        DamageInvincibleTimeMax = 120;
        // パラメータ　//
        player = GameObject.FindWithTag("Player").GetComponent<Player>();   // プレイヤー情報を取得
        hp = 2;                         // 体力       【2】
        speed = player.speed * 0.5f;    // 移動速度    【プレイヤーの移動速度 * 0.5】
        damage = 2;                     // ダメージ    【未定】
        rb = GetComponent<Rigidbody>();
        moveDirectionRight = true;
        sprite = GetComponent<SpriteRenderer>();


        //        animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        animator.SetLayerWeight((int)this.color + 1, 1.0f);

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isDeleting) return;
        Move();

        if (transform.position.x < TurnPointMin && !moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = true;
            sprite.flipX = true;
        }
        if (TurnPointMax < transform.position.x && moveDirectionRight)
        {
            speed = speed * -1.0f;
            moveDirectionRight = false;
            sprite.flipX = false;
        }
    }

    public override void Attack()
    {
        Debug.Log("Enemy_Type1 Attack");
    }

    public override void Move()
    {
        // Debug.Log("Enemy_Type1 Move");

        // 横移動のみ
        rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
    }

    //インスタンス生成時に必要情報をセット（移動最小位置、移動最大位置、色）
    public void StateSet(Vector3 initpos,float min, float max,int color)
    {
        TurnPointMax = max;
        TurnPointMin = min;

        StartPos = new Vector3(initpos.x, initpos.y, initpos.z);

        animator = GetComponent<Animator>();
        animator.SetLayerWeight(color + 1, 1.0f);
    }

    //Enemy1の死亡時処理
    public override void DeathProcess()
    {
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().Enemy_1_RespornOrder(StartPos, TurnPointMin, TurnPointMax);
    }
}