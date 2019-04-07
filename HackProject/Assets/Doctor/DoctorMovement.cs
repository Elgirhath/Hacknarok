using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorMovement : MonoBehaviour {
    public GameObject path;

    public Vector3 moveDirection;
    public float moveSpeed;

    private List<Transform> pathNodes = new List<Transform>();
    private int nextNodeIndex = 1;
    private int lastNodeIndex = 0;
    private bool isMovingForward = true;

    private float threshold = 1f;

    public float freezeTime = 0f;

    private bool freezed = false;
    private float freezeLeft;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform node in path.transform) {
            pathNodes.Add(node);
        }

        transform.position = pathNodes[0].position;
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (freezed) {
            freezeLeft -= Time.deltaTime;
            if (freezeLeft <= 0f)
                freezed = false;
            
            return;
        }
        
        moveDirection = pathNodes[nextNodeIndex].position - transform.position;
        float moveX = moveDirection.x;
        float moveY = moveDirection.y;
        if (Mathf.Abs(moveX) > Mathf.Abs(moveY)) {
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", 0f);
        }
        else {
            animator.SetFloat("MoveY", moveDirection.y);
            animator.SetFloat("MoveX", 0f);
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        
        if (IsDestReached())
            NodeProceed();
    }

    private void NodeProceed() {
        if (nextNodeIndex == 0 || nextNodeIndex == pathNodes.Count - 1) {
            freezed = true;
            freezeLeft = freezeTime;
        }
        UpdateIndex();
    }

    private bool IsDestReached() {
        return Vector2.Distance(transform.position, pathNodes[nextNodeIndex].position) < threshold;
    }

    private void UpdateIndex() {
        if (nextNodeIndex == 0) {
            isMovingForward = true;
        }
        else if (nextNodeIndex >= pathNodes.Count - 1) {
            isMovingForward = false;
        }

        lastNodeIndex = nextNodeIndex;
        nextNodeIndex += isMovingForward ? 1 : -1;
    }
}
