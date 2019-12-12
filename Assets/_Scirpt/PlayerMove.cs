using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{

    public int PlayerHP = 1;
    private int GoldCount;
    public float moveForce = 365f;//运动力大小
    public float MoveSpeed = 5f;
    public float jumpForce = 300f;//角色跳跃时力大小
    public bool isAttack = false;
    public GameObject Bullet;

    public float Attacktimer=1f;
    private float Jumptimer=0.5f;

    private Transform groundCheck;//检测角色是否在地面上的对象
    private bool grounded = false;//默认角色不在地面上
    public Animator anim;//角色对象上的Animator组件
    public BoxCollider2D PlayerCollider;

    public Text HPtext;
    public Text Goldtext;
    public Button UpButton;
    public Button LeftButton;
    public Button RightButton;

    public Button SkillButton; //技能按钮
    public Image ShowImage; //冷却
    public Text ShowText; //冷却时间文本

    private const float MaxTime = 2.0f;
    private float CountTime;


    [HideInInspector]
    public bool facingRight = true;//角色是否朝向右侧
    [HideInInspector]
    public bool jump = false;//角色是否在跳跃

    private Rigidbody2D player;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        UpButton.onClick.AddListener(JumpButton);

        LeftButton.onClick.AddListener(LeftRun);
        RightButton.onClick.AddListener(RightRun);

        StopSkill();
        SkillButton.onClick.AddListener(SkillStart);
	}
	
	// Update is called once per frame
	void Update ()
    {

        Run();
        Jump();
        ShowHP();
        ShowGold();
        Attacktimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        else if (SkillButton.interactable==false)
        {
            if(ShowImage.fillAmount<=1&&ShowImage.fillAmount>0)
            {
                CountTime += Time.deltaTime;
                ShowImage.fillAmount = (MaxTime - CountTime) / MaxTime;
                ShowText.text = Mathf.CeilToInt(MaxTime - CountTime).ToString();
                if(ShowImage.fillAmount==0)
                {
                    StopSkill();
                }
            }
        }
	}

    void Run()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        //小豆人角色面朝右，按下向左方向键，需要翻转角色；
        else if (h < 0 && facingRight)
            Flip();
            player.velocity = new Vector2(h * MoveSpeed, player.velocity.y);
        
    }


    public  void LeftRun()
    {
        
            player.velocity = new Vector2(MoveSpeed, player.velocity.y);
    }

    public void RightRun()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);
    }

    public void Jump()
    {
        Jumptimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space)&&grounded==true&&Jumptimer>0.5f)
        {
            anim.SetBool("Jump", true);
            VideoController.Instance.PlaySound("跳");
            player.AddForce(new Vector2(0f, jumpForce));
            Jumptimer = 0;
        }
    }

    //按钮控制跳跃
    public void JumpButton()
    {
        Jumptimer += Time.deltaTime;
        if (grounded == true && Jumptimer > 0.5f)
        {
            anim.SetBool("Jump", true);
            VideoController.Instance.PlaySound("跳");
            player.AddForce(new Vector2(0f, jumpForce));
            Jumptimer = 0;
        }
    }
    //控制小人镜像翻转
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //技能
    public void SkillStart()
    {
        DownSkill();
    }

    //按下技能按钮
    public void DownSkill()
    {
        SkillButton.interactable = false;
        ShowImage.fillAmount = 1.0f;
        ShowText.text = MaxTime.ToString();
        CountTime = 0;
    }

    //技能冷却
    public void StopSkill()
    {
        SkillButton.interactable = true;
        ShowImage.fillAmount = 0f;
        ShowText.text = string.Empty;
        CountTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("Jump", false);

        }
        else if(collision.gameObject.tag == "mush")
        {
            VideoController.Instance.PlaySound("吃到蘑菇或花");
            anim.SetBool("GetEat", true);
            PlayerHP += 1;
            
                PlayerCollider.size = new Vector2(0.2f, 0.3f);
                anim.SetBool("Bigrun", true);
            
        }
    }

    public void OnDamage(int damage)
    {
        PlayerHP -= damage;

        if(PlayerHP<=0)
        {
            VideoController.Instance.PlaySound("死亡1");
            anim.SetBool("Die", true);
            Destroy(PlayerCollider);
        }
        else
        {
            anim.SetBool("Bigrun", false);
            anim.SetBool("GetEat", false);
            PlayerCollider.size = new Vector2(0.1f, 0.2f);
        }
    }

    public void ShowHP()
    {
        HPtext.text = "生命值：" + PlayerHP;
    }

    public void ShowGold()
    {
        Goldtext.text = "金币数：" + GoldCount;
    }

    public void ChangGold(int count)
    {
        GoldCount += count;
    }

    //得到条件进行攻击
    public void Attack()
    {
        if (isAttack==true)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            Attacktimer = 0;
        }
    }
}
