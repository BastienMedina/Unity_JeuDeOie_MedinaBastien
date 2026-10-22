using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private int maxSlotQuantity = 3;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform baseSpawnTransform;
    [SerializeField] private float spawnDecal = 1.5f;

    private int slotCount = 0;
    private float ancientX;

    void Start()
    {
        SpawnAllSlots();
    }

    void AddSlot(int id)
    {
        if(slotCount < maxSlotQuantity)
        {
            GameObject newSlot = Instantiate(slotPrefab, CalculSlotPos(), baseSpawnTransform.rotation);
        }
    }

    private void SpawnAllSlots()
    {
        for (int i = 0; i < maxSlotQuantity; i++)
        {
            AddSlot(i);
        }
    }

    private Vector3 CalculSlotPos()
    {
        Vector3 Pos = new Vector3(baseSpawnTransform.localPosition.x, baseSpawnTransform.localPosition.y, (ancientX + spawnDecal));
        ancientX = (ancientX + spawnDecal);
        return Pos;
    }
}
