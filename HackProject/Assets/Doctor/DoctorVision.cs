using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorVision : MonoBehaviour {

    public float visionAngle;
    public float maxDistance;
    
    private Vector3 forward;

    private GameObject[] players;

    private void Start() {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update() {
        CheckVision();
    }

    private void CheckVision() {
        forward = GetComponent<DoctorMovement>().moveDirection;
        
        foreach (var player in players) {
            RectTransform rect = player.GetComponent<RectTransform>();
            Vector3[] corners = new Vector3[4];
            rect.GetWorldCorners(corners);

            foreach (var corner in corners) {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, corner - transform.position, maxDistance);
                if (hit.collider == rect.GetComponent<Collider2D>()) {
                    float angle = Vector2.Angle(hit.point - (Vector2) transform.position, forward);
//                    if (angle < visionAngle)
//                        Debug.Log("Seen: " + rect.name);
                }
            }
        }
    }
}
