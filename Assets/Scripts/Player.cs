using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    NetworkView view;
    Rigidbody2D rigidbody2d;

    void Start()
    {
        view = GetComponent<NetworkView>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (view.isMine)
        {
            InputMovement();
        }
    }

    void InputMovement()
    {

        Vector2 vec = transform.position;
            if (Input.GetKey(KeyCode.W))
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.up * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.S))
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.down * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.left * speed * Time.deltaTime);
    }
}