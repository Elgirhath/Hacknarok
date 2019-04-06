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
        if (Input.GetButton(xInput))
        {
            MoveX();
        }
        if(Input.GetButton(yInput))
        {
            MoveY();
        }
    }

    private void MoveX()
    {
        float direction = Input.GetAxisRaw(xInput);
        tr.position += Vector3.right * moveSpeed * direction * Time.deltaTime;
        if (direction < 0)
        {
            if(facingRight)
                FlipX();
        }
        else
        {
            if (!facingRight)
                FlipX();
        }
    }

    private void MoveY()
    {
        float direction = Input.GetAxisRaw(yInput);
        tr.position += Vector3.up * moveSpeed * direction * Time.deltaTime;
        if (direction < 0)
        {
            if(facingUp)
                FlipY();
        }
        else
        {
            if (!facingUp)
                FlipY();
        }
    }

    private void FlipX()
    {
        facingRight = !facingRight;
        sprite.flipX = !sprite.flipX;
    }

    private void FlipY()
    {
        facingUp = !facingUp;
        sprite.flipY = !sprite.flipY;
    }
}
