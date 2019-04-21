using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoctorVision : MonoBehaviour {

    public float visionAngle;
    public float maxDistance;

    public Vector2 viewDirection;
    
    private GameManager gameManager;
    private GameObject[] players;

    private void Start() {
		GameObject[] tmp_1 = GameObject.FindGameObjectsWithTag("Player1"); 
		GameObject[] tmp_2 = GameObject.FindGameObjectsWithTag("Player2");
        players = tmp_1.Concat(tmp_2).ToArray();
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
            if (!hit)
                continue;
            if (hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2")) {
                float angle = Vector2.Angle(direction, viewDirection);
                if (angle < visionAngle)
                {
                    gameManager.EndGame(true);
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.6f);
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
