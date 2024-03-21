using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f; //швидкість руху
    public float jumpStrenght = 3f; //сила стрибка
    private Rigidbody2D rb2d; //посилання на фізику об'єкта
    private bool isJump = false; //чи можу я стрибати
    public GameObject deathParticle;//система частинок для програшу

    public float rotateSpeed = 2;//швидкість обертання
    private float rotateZ = 0.0f;//поточний кут

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
            transform.GetChild(0).eulerAngles = new Vector3(0, 0, rotateZ -= 90f);
        }
        
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameObject part = Instantiate(deathParticle, 
                transform.position, Quaternion.identity);
            Destroy(part, 0.5f);
            Application.LoadLevel(0);
            Destroy(gameObject);
        }
    }

}
