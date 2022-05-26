using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager
{
    public static event UnityAction GameOverEvent;
    public static event UnityAction GoalEvent;


    public static void OnGameOverEvent() => GameOverEvent?.Invoke();
    public static void OnGoalEvent() => GoalEvent?.Invoke();
}
