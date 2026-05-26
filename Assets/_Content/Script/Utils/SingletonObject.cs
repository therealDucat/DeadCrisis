using JetBrains.Annotations;
using UnityEngine;

namespace _Content.Script.Utils
{
    public abstract class Singleton<T> : SingletonObject where T : MonoBehaviour
    {
        private static T instance;
        [NotNull]
        private static readonly object locker = new object();

        [NotNull]
        public static T Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance != null)
                        return instance;

                    var instances = FindObjectsOfType<T>(true);
                    var count = instances.Length;
                    if (count > 0)
                    {
                        for(var i = 1; i < count; i++)
                            Destroy(instances[i]);
                        return instance = instances[0];
                    } else if (count <= 0)
                    {
                        var obj = new GameObject();
                        obj.name = typeof(T).Name;
                        obj.AddComponent<T>();

                        instance = obj.GetComponent<T>();
                    }

                    return instance;
                }
            }
        }
    }

    public abstract class SingletonObject : MonoBehaviour
    { }
}