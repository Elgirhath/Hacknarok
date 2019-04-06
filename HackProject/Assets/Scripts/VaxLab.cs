using UnityEngine;

public class VaxLab : MonoBehaviour, Interactable
{
    private bool done;
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
                task.Perish(true);
                done = true;
            }
            else
            {
                if (done)
                {
                    Debug.Log("Dude, are you high?! You have already done that task!");
                }
                else
                    Debug.Log("Not now man! Now is not the time for that!");
            }
        }
    }

    private bool IsPlaceboEquipped (Inventory inventory) {
        return inventory.Contains(placebo);
    }

    void Start()
    {
        taskManager = TaskManager.instance;
        done = false;
    }
}
