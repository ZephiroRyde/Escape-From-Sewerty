using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager
{
    public static event UnityAction GameOverEvent;
    public static event UnityAction GoalEvent;
    public static event UnityAction ActivateMechanism;
    public static event UnityAction ChangeCamera;

    public static void OnGameOverEvent() => GameOverEvent?.Invoke();
    public static void OnGoalEvent() => GoalEvent?.Invoke();
    public static void OnActivateMechanism() => ActivateMechanism?.Invoke();
    public static void OnChangeCamera() => ChangeCamera?.Invoke();
}
