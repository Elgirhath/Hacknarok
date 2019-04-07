using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public string xInput;
    public string yInput;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move() {
        float vertExtent = Camera.main.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;
        
        float moveX = Input.GetAxisRaw(xInput);
        float moveY = Input.GetAxisRaw(yInput);
        float xPos = rb.position.x + moveSpeed * moveX * Time.deltaTime;
        float yPos = rb.position.y + moveSpeed * moveY * Time.deltaTime;
        Camera cam = Camera.main;
        xPos = Mathf.Clamp(xPos, cam.transform.position.x - horzExtent, cam.transform.position.x + horzExtent);
        yPos = Mathf.Clamp(yPos, cam.transform.position.y - vertExtent, cam.transform.position.y + vertExtent);
        rb.MovePosition(new Vector2(xPos, yPos));
    }
}
