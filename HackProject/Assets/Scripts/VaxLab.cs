using UnityEngine;

public class VaxLab : MonoBehaviour, Interactable
{
    public Item placebo;
    private TaskManager taskManager;
    public void Interact(InteractController controller) {
        Inventory inventory = controller.GetComponent<Inventory>();
        if (IsPlaceboEquipped(inventory)) {
            Debug.Log("Vax switched");
            inventory.Remove(placebo);
            Task task = taskManager.TaskExists(GameManager.TaskType.VAX);
            if (task)
            {
                Debug.Log("Nice!");
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
    }
}
