using UnityEngine.Events;

/// <summary>
/// Provides a layer of abstraction for events.
/// </summary>
public static class EventManager
{
    public static readonly UnityEvent onEnemyDestroyed = new UnityEvent();

    public static readonly UnityEvent onPlayerDestroyed = new UnityEvent();

    public static readonly UnityEvent onScoreUpdate = new UnityEvent();

    //static means it exists as soon as the program starts
    //NOT a MonoBehavior, so this class doesn't need to be in a scene -- always exists in project

    //readonly: because these are public, we don't want anyone else to do something screwy, like
    //onEnemyDestroyed = new UnityEvent() in a different class, which will unsubscribe everyone.
}
