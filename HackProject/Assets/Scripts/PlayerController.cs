using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public string xInput;
    public string yInput;
    public Vector2 currentDirection = new Vector2();

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
        SetAnimationDirection();
    }

    private void SetAnimationDirection() {
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("MoveX", currentDirection.x);
        animator.SetFloat("MoveY", currentDirection.y);
    }

    private void Move() {
        float vertExtent = Camera.main.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;
        
        float moveX = Input.GetAxisRaw(xInput);
        float moveY = Input.GetAxisRaw(yInput);
        currentDirection.x = moveX;
        currentDirection.y = moveY;
        float xPos = rb.position.x + moveSpeed * moveX * Time.deltaTime;
        float yPos = rb.position.y + moveSpeed * moveY * Time.deltaTime;
        Camera cam = Camera.main;
        xPos = Mathf.Clamp(xPos, cam.transform.position.x - horzExtent, cam.transform.position.x + horzExtent);
        yPos = Mathf.Clamp(yPos, cam.transform.position.y - vertExtent, cam.transform.position.y + vertExtent);
        rb.MovePosition(new Vector2(xPos, yPos));
    }
    
    void LateUpdate()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
    }
}
