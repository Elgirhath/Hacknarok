using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public string xInput;
    public string yInput;

    private RectTransform tr;
    private SpriteRenderer sprite;

    private bool facingUp;
    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<RectTransform>();
        sprite = GetComponent<SpriteRenderer>();
        facingUp = true;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        Rigidbody2D rb = tr.GetComponent<Rigidbody2D>();
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
