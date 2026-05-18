using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public static class Utils
{
    /// <summary>
    /// Get angle by vector
    /// </summary>
    /// <returns>angle in radians</returns>
    public static float GetAngle(Vector2 vector)
    {
        var normalizedVector = vector.normalized;
        return Mathf.Atan2(normalizedVector.y, normalizedVector.x);
    }
    public static Vector2 GetAngle(Vector2 firstPoint, Vector2 secondPoint)
    {
        return (firstPoint - secondPoint).normalized;
    }
    public static T GetRandomElement<T>(this IEnumerable<T> array)
    {
        var count = array.Count();
        var index = UnityEngine.Random.Range(0, count);
        if (index >= count)
            return default(T);
        return array.ElementAt(index);
    }
    /// <summary>
    /// Get random element from IEnumerable by weight
    /// Weight must be bigger, than 0
    /// </summary>
    public static T GetWeightedRandomElement<T>(this IEnumerable<(float, T)> array)
    {
        var sum = array.Sum(pair => pair.Item1 > 0 ? pair.Item1 : 0);
        var index = UnityEngine.Random.Range(0, sum);
        return array.First(pair=>
        {
            index -= pair.Item1;
            return index <= 0;
        }).Item2;
    }

    public static T GetWeightedRandomElement<T>(this IEnumerable<T> array, Func<T, float> weightFunc)
    {
        var sum = array.Sum(element => weightFunc(element) > 0 ? weightFunc(element) : 0);
        var index = UnityEngine.Random.Range(0, sum);
        return array.First(element =>
        {
            index -= weightFunc(element);
            return index <= 0;
        });
    }
    public static Vector2 GetAngle(float degree)
    {
        degree = degree * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(degree), Mathf.Sin(degree)).normalized;
    }

    public static void SetActiveSafe(this GameObject obj, bool state)
    {
        if (obj != null && obj.activeSelf != state)
            obj.SetActive(state);
    }
    
    public static void SetActiveSafe(this Component obj, bool state)
    {
        if (obj != null && obj.gameObject.activeSelf != state)
            obj.gameObject.SetActive(state);
    }
    
    public static RectTransform GetRectTransform(this GameObject obj)
    {
        return (RectTransform)obj.transform;
    }
    public static RectTransform GetRectTransform(this Component obj)
    {
        return (RectTransform)obj.transform;
    }

    public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (var element in list)
        {
            action(element);
        }
    }
    
    public static int IndexOf<T>(this IList<T> list, Func<T, int, bool> action)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (action(list[i], i))
                return i;
        }

        return -1;
    }
    
    public static int IndexOfBackwards<T>(this IList<T> list, Func<T, int, bool> action)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (action(list[i], i))
                return i;
        }

        return -1;
    }

    public static bool AddIfNotContains<T>(this IList<T> list, T value)
    {
        if (list.Contains(value))
        {
            return false;
        }
        list.Add(value);
        return true;
    }
}
public class ConnectionCollector : IDisposable
{
    private LinkedList<IDisposable> _disposables = new LinkedList<IDisposable>();

    public void Add(IDisposable value)
    {
        _disposables.AddLast(value);
    }

    public void Dispose()
    {
        _disposables.ForEach(disposable => disposable.Dispose());
        _disposables.Clear();
    }
}
public static class AnimatorExtensions
{
    public static readonly int MeleeAttack = Animator.StringToHash("MeleeAttack");
    public static readonly int FireAttack = Animator.StringToHash("FireAttack");
}