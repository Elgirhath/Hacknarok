using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receptionist : MonoBehaviour, Interactable
{
    private bool talkInProgress;
    private bool blockTalk;
    private GameObject interactedPlayer;
    public float moveTolerance;
    private RectTransform playerPosition;
    private Vector3 initialPosition;
    private Coroutine coroutine;

    private Vector3 screenPosition;
    private RectTransform indicatorPosition;
    private Image indicatorBar;
    private GameObject progressIndicator;
    private float startTime;
    private List<Collider2D> colliders = new List<Collider2D>();
    
    public float timeToSucceed;
    public void Interact(InteractController controller)
    {
        GameObject interactingPlayer = controller.gameObject;
        if (!blockTalk && interactedPlayer != interactingPlayer)
        {
            if (interactedPlayer)
            {
                blockTalk = true;
            }
            playerPosition = interactingPlayer.GetComponent<RectTransform>();
            initialPosition = playerPosition.position;
            if(!talkInProgress)
                coroutine = StartCoroutine(Talk());
        }
        
        else
        {
            Debug.Log("No, man! No! She already knows you!");
        }
    }
    
    void Start()
    {
        talkInProgress = false;
        screenPosition = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(transform.position);
        screenPosition.y += 22;
        progressIndicator = GameObject.Find("Talk Progress");
        indicatorPosition = progressIndicator.GetComponent<RectTransform>();
        indicatorPosition.position = screenPosition;
        indicatorBar = progressIndicator.GetComponent<Image>();
        indicatorBar.fillAmount = 1;
        progressIndicator.SetActive(false);
        interactedPlayer = null;
        blockTalk = false;
        foreach (Transform child in transform)
        {
            colliders.Add(child?.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        if (talkInProgress)
        {
            indicatorBar.fillAmount = 1 - (Time.time - startTime) / timeToSucceed;
            if (Vector2.Distance(playerPosition.position, initialPosition) > moveTolerance)
            {
                StopCoroutine(coroutine);
                progressIndicator.SetActive(false);
                indicatorBar.fillAmount = 1;
                talkInProgress = false;
            }
        }
    }

    IEnumerator Talk()
    {
        startTime = Time.time;
        progressIndicator.SetActive(true);
        talkInProgress = true;
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }
        yield return new WaitForSeconds(timeToSucceed);
        progressIndicator.SetActive(false);
        foreach (Collider2D col in colliders)
        {
            col.enabled = true;
        }
    }
}
