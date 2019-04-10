using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorVision : MonoBehaviour {

    public float visionAngle;
    public float maxDistance;

    public Vector2 viewDirection;
    
    private GameManager gameManager;
    private GameObject[] players;

    private void Start() {
        players = GameObject.FindGameObjectsWithTag("Player");
        gameManager = GameManager.instance;
    }

    private void Update() {
        CheckVision();
    }

    private void CheckVision() {
        Debug.DrawRay(transform.position, viewDirection * 2f, Color.blue);
        foreach (var player in players) {
            float dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist > maxDistance)
                continue;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dist);
            Debug.DrawRay(transform.position, direction * dist, Color.red);
            if (!hit || hit.collider.CompareTag("Player")) {
                float angle = Vector2.Angle(direction, viewDirection);
                if (angle < visionAngle)
                    gameManager.EndGame(true);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.6f);
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
