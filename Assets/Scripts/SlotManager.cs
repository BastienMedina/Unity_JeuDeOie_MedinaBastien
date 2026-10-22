using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private int maxSlotQuantity = 3;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform baseSpawnTransform;
    [SerializeField] private float spawnDecal = 1.5f;

    private int slotCount = 0;

    void AddSlot()
    {
        if(slotCount < maxSlotQuantity)
        {
            // Logique de spawn
        }
    }
}
