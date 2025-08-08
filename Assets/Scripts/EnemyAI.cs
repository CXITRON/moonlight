using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyAI : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    public LayerMask playerLayer;

    public int ailvl;
    /* 1: ����� ��󿡰� �̵�, ���� �Ÿ� �����ϸ� �Ѿ� �Ǵ� ���� ����     #���
     * 2: ����� ��󿡰� �̵��ϸ� �����Ͽ� ������ ȸ��                 #����Ʈ��
     * 3: �̵� ������ ����Ͽ� ���� ����, ���� ���� �κ� ȸ��            # �� ����
     */
    

    public float lockOnDistance;
    public float attackDistance;

    public int health;
    public int maxHealth;

    public int attackDamage;
    public int attackType;
    /* 1: ����
     * 2: ���Ÿ�
     * 3: ����
     * 4: ����� �� �� ����
     */

    public float moveSpeed;
    public float maxSpeed;

    public float dist;
    

    
    




    public GameObject player;
    public GameObject ilight;
    public GameObject target;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        

            // ���� ��� Ÿ����
        if (target == null)
        {
            var PlayerObj = Physics2D.OverlapCircle(transform.position, lockOnDistance, playerLayer);
            if (PlayerObj != null)
            {
                Debug.Log("Target Found: " + PlayerObj.name);
                target = PlayerObj.gameObject;
                ilight.GetComponent<Light2D>().intensity = 3;
            }
        }

        else if (target != null) {
            if (target.transform.position.x < this.transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else if (target.transform.position.x >= this.transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
        }

        
 
    }

    void FixedUpdate()
    {
        if(target != null) 
        {
            dist = Vector3.Distance(this.transform.position, target.transform.position);
            if(dist > attackDistance)
            {
                if (target.transform.position.x < this.transform.position.x)
                {
                   
                    rigid.AddForce(Vector2.right * moveSpeed * -1, ForceMode2D.Impulse);
                    //Debug.Log("LLL");
                }
                else if (target.transform.position.x >= this.transform.position.x)
                {
                    spriteRenderer.flipX = false;
                    rigid.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
                }

                if (rigid.velocity.x > maxSpeed)
                {
                    rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
                }
                else if (rigid.velocity.x < maxSpeed * (-1))
                {
                    rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
                }
            }
            
        }
    }
}
