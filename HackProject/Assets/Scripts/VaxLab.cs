using UnityEngine;

public class VaxLab : MonoBehaviour, Interactable {
    public Item placebo;
    public void Interact(InteractController controller) {
        Inventory inventory = controller.GetComponent<Inventory>();
        if (IsPlaceboEquipped(inventory)) {
            Debug.Log("Vax switched");
            inventory.Remove(placebo);
        }
    }

    private bool IsPlaceboEquipped (Inventory inventory) {
        return inventory.Contains(placebo);
    }
}
