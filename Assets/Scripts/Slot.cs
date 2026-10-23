using System.Data.Common;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotID = 0;
    public SlotStructSave slotData;

    public void ApplySlotEffect() //Applique l'effet du slot
    {
        print(slotData.effect);
    }
}
