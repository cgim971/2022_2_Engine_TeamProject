using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager
{
    public static Dictionary<string, GameObject> _poolObjectDictionary = new Dictionary<string, GameObject>();
    public static Dictionary<string, Queue<GameObject>> _poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public static void CreatePool(string name, Transform parent = null, int count = 5)
    {
        try
        {
            Queue<GameObject> q = new Queue<GameObject>();
            GameObject prefab = null;

            if (!_poolObjectDictionary.ContainsKey(name))
            {
                prefab = Resources.Load<GameObject>($"Prefabs/{name}");

                if (prefab == null)
                {
                    throw new Exception("prefab을 찾지 못 하였습니다.");
                }

                _poolObjectDictionary.Add(name, prefab);
            }
            else
            {
                prefab = _poolObjectDictionary[name];
            }

            for (int i = 0; i < count; i++)
            {

                GameObject newPrefab = GameObject.Instantiate(prefab, parent);
                IPoolable iPool = newPrefab.GetComponent<IPoolable>();

                if (iPool == null)
                {
                    throw new Exception("Interface가 달려있지 않습니다.");
                }

                newPrefab.GetComponent<IPoolable>().NAME = name;
                newPrefab.SetActive(false);

                q.Enqueue(newPrefab);
            }

            if (!_poolDictionary.ContainsKey(name))
            {
                _poolDictionary.Add(name, q);
            }
            else
            {
                int index = q.Count;
                for (int i = 0; i < index; i++)
                {
                    _poolDictionary[name].Enqueue(q.Dequeue());
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }
    }
    public static void CreatePool(string name, string address, Transform parent = null, int count = 5)
    {
        try
        {
            Queue<GameObject> q = new Queue<GameObject>();
            GameObject prefab = null;

            if (!_poolObjectDictionary.ContainsKey(name))
            {
                prefab = Resources.Load<GameObject>($"Prefabs/{address}/{name}");

                if (prefab == null)
                {
                    throw new Exception("prefab을 찾지 못 하였습니다.");
                }

                _poolObjectDictionary.Add(name, prefab);
            }
            else
            {
                prefab = _poolObjectDictionary[name];
            }

            for (int i = 0; i < count; i++)
            {

                GameObject newPrefab = GameObject.Instantiate(prefab, parent);
                IPoolable iPool = newPrefab.GetComponent<IPoolable>();

                if (iPool == null)
                {
                    throw new Exception("Interface가 달려있지 않습니다.");
                }

                newPrefab.GetComponent<IPoolable>().NAME = name;
                newPrefab.SetActive(false);

                q.Enqueue(newPrefab);
            }

            if (!_poolDictionary.ContainsKey(name))
            {
                _poolDictionary.Add(name, q);
            }
            else
            {
                for (int i = 0; i < q.Count; i++)
                {
                    _poolDictionary[name].Enqueue(q.Dequeue());
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }
    }

    public static GameObject PopObject(string name, bool isCreate = true)
    {
        try
        {
            GameObject returnObj = null;
            if (!_poolDictionary.ContainsKey(name))
            {
                throw new Exception("Not pooled");
            }

            Queue<GameObject> q = _poolDictionary[name];

            if (isCreate == true && q.Count == 1)
            {
                CreatePool(name, q.Peek().transform.parent, 1);
            }

            returnObj = q.Dequeue();
            returnObj.SetActive(true);

            IPoolable iPool = returnObj.GetComponent<IPoolable>();
            if (iPool == null)
            {
                returnObj = null;
                throw new Exception("There is no interface attached.");
            }

            iPool.OnPool();

            return returnObj;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }

    public static void PushObject(string name, GameObject obj, Transform parent = null)
    {
        if (_poolDictionary.ContainsKey(name))
        {
            obj.SetActive(false);
            if (parent != null)
                obj.transform.SetParent(parent);
            obj.transform.SetAsLastSibling();
            _poolDictionary[name].Enqueue(obj);
        }
    }

    public static bool PooledCheck(string name)
    {
        if (_poolDictionary.ContainsKey(name))
        {
            return _poolDictionary[name].Count > 0;
        }
        return false;
    }
}
