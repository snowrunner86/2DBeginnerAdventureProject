using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;

    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; ;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }


        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        DuckoController player = other.gameObject.GetComponent<DuckoController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}

