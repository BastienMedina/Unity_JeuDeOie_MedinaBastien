using UnityEditor.VisionOS;
using UnityEngine;

using NUnit.Framework.Interfaces;

public class Dices : MonoBehaviour
{
    [SerializeField] private int launchDiceQuantity = 1;
    [SerializeField] private int diceMax = 6;
    [SerializeField] private int diceMin = 1;

    void Start()
    {
        LaunchDice();
    }

    void LaunchDice()
    {
        int totalResult = 0;
        for (int i = 0; i < (launchDiceQuantity + 1); i++)
        {
            int diceResult = RandomDiceResult();
            totalResult += diceResult;
            print("Dés n°" + i + ":" + diceResult);
        }
        print(totalResult);
    }

    public int RandomDiceResult()
    {
        int result = UnityEngine.Random.Range(diceMin, (diceMax + 1));
        return result;
    }
}
