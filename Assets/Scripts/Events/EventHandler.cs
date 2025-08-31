using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static event Action LoseGameEvent;
    public static void LoseGame() => LoseGameEvent?.Invoke();
    
    public static event Action WinGameEvent;
    
    public static void WinGame() => WinGameEvent?.Invoke();
}
