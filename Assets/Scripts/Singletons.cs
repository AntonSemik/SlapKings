using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _s;

    public Coins Coins;
    public SaveGameState SaveGameState;
    public AdsPlaceholder AdsPlaceholder;
    public Fight Fight;
    public LevelParameters LevelParameters;

    private void Awake()
    {
        _s = this;
    }
}
