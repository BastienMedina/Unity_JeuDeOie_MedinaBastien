using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [Header("Spawn parameters")]
    [SerializeField] private int maxSlotQuantity = 3;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform baseSpawnTransform;
    [SerializeField] private float spawnDecal = 1.5f;

    [Header("Saves")]
    [SerializeField] private SlotsSaves slotSave;

    private int slotCount = 0;
    private float ancientX;

    void Awake()
    {
        ancientX = (baseSpawnTransform.position.z - spawnDecal);
        LoadAllSlots();
    }

    void AddSlot(int id)
    {
        if(slotCount < maxSlotQuantity)
        {
            GameObject newSlot = Instantiate(slotPrefab, CalculSlotPos(), baseSpawnTransform.rotation);
            slotCount++;
            slotSave.AddSlotObject(slotCount, newSlot);
            if(id >= 0)
            {
                newSlot.GetComponent<Slot>().slotData = slotSave.slotsData[id];
            }
            else
            {
                newSlot.GetComponent<Slot>().slotData.id = slotCount;
                slotSave.AddSlotData( newSlot.GetComponent<Slot>().slotData);
            }
        }
    }

    private void SpawnAllSlots()
    {
        if(slotSave.slotsCount > 0)
        {
            maxSlotQuantity = slotSave.slotsCount;
            slotCount = 0;
        }
        for (int i = 0; i < maxSlotQuantity; i++)
        {
            AddSlot(-1);
        }
    }

    private Vector3 CalculSlotPos()
    {
        Vector3 Pos = new Vector3(baseSpawnTransform.position.x, baseSpawnTransform.position.y, (ancientX + spawnDecal));
        ancientX = (ancientX + spawnDecal);
        return Pos;
    }

    public void LoadAllSlots()
    {
        if(slotSave.slotsData.Count > 0)
        {
            for(int i = 0; i< slotSave.slotsData.Count; i++)
            {
                AddSlot(i);
            }
            if(slotSave.slotsData.Count < maxSlotQuantity)
            {
                SpawnAllSlots();
            }
        }
        else
        {
            SpawnAllSlots();
        }
    }
}
