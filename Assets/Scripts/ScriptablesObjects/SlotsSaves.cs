using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SlotsSaves", menuName = "Scriptable Objects/SlotsSaves")]
public class SlotsSaves : ScriptableObject
{
    private Dictionary<int, GameObject> slots = new Dictionary<int, GameObject>();

    public int slotsCount;

    public void AddSlotObject(int id, GameObject slot)
    {
        if (!slots.ContainsKey(id))
        {
            slots.Add(id, slot);
            if(slots.Count > slotsCount)
            {
                slotsCount = slots.Count;
            }
        }
        else
        {
            slots[id] = slot;
        }
    }

    public void ClearSlotSave()
    {
        slots.Clear();
        slotsCount = 0;
    }

    public GameObject GetSlotFromList(int id)
    {
        if (slots.ContainsKey(id))
        {
            return slots[id];
        }
        return null;
    }
}
