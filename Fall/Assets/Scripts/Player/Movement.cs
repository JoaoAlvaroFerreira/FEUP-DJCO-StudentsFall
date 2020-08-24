using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public float speed = 5f;  // How long it takes to reach max
    public float smothing_movement;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        /*Vector2 mouse = Input.mousePosition;
        var posicao_3 = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 posicao = new Vector2(posicao_3.x, posicao_3.y);
        transform.position = Vector2.Lerp(transform.position, posicao, speed);*/
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

    }
}
