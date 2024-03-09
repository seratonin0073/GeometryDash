using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f; //�������� ����
    public float jumpStrenght = 3f; //���� �������
    private Rigidbody2D rb2d; //��������� �� ������ ��'����
    private bool isJump = false; //�� ���� � ��������

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if(Input.GetMouseButtonDown(0) && isJump)
        {
            rb2d.AddForce(Vector2.up * jumpStrenght, ForceMode2D.Impulse);
            isJump = false;
        }
        
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }

}
