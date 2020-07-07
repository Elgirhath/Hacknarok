using UnityEngine;
using UnityEngine.UI;

public class VaxLab : MonoBehaviour, Interactable
{
    private GameObject feedbackContainer;
    public GameObject feedbackTextPrefab;
    private GameObject feedbackText;
    public Item placebo;
    private TaskManager taskManager;
    public void Interact(InteractController controller) {
        Inventory inventory = controller.GetComponent<Inventory>();
        if (IsPlaceboEquipped(inventory)) {
            Task task = taskManager.TaskExists(GameManager.TaskType.VAX);
            if (!task)
            {
                feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
                feedbackText.GetComponent<Text>().text = "Not now man! Now is not the time for that!";
                Destroy(feedbackText, 5.0f);
            }
            else
            {
                feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
                feedbackText.GetComponent<Text>().text = "Vax switched";
                Destroy(feedbackText, 5.0f);
                inventory.Remove(placebo);
                feedbackText = Instantiate(feedbackTextPrefab, feedbackContainer.transform);
                feedbackText.GetComponent<Text>().text = "Nice!";
                Destroy(feedbackText, 5.0f);
                task.Accomplish();
            }
        }
    }

    private bool IsPlaceboEquipped (Inventory inventory) {
        return inventory.Contains(placebo);
    }

    void Start()
    {
        taskManager = TaskManager.instance;
        feedbackContainer = GameObject.FindGameObjectWithTag("Feedback");
    }
}
