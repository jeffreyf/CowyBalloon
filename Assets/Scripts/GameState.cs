using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameState
{
    public static List<GameObject> NewCollectibles = new List<GameObject>();
    public static List<GameObject> CollectedCollectibles = new List<GameObject>();
    public static Queue<Vector3> AvailableDropOffPositions = new Queue<Vector3>();

    public static int TotalMilkBottles = 1;
    public static int NewMilkBottles = 0;
    public static float MaxEnergy { get { return TotalMilkBottles * 10.0f; } }
    public static float Energy = MaxEnergy;
    public static readonly int EnergyDecayRate = 1;
}