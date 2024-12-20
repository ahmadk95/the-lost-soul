using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace tls.utils
{
    public class List : MonoBehaviour
    {
        public Item Prefab;
        protected IEnumerable items;
        protected object classRef;
        [Space]
        public UnityEvent OnRefresh;


        [Header("Loading Icon Before Item Population")]
        public GameObject LoadingIconPrefab;
        public Transform LoadingIconParent;
        public Vector3 positionOffset;
        private GameObject loadingIcon;
        private bool contentLoaded = false;

        [HideInInspector]
        protected List<Item> instantiatedPrefabs = new List<Item>();
        public List<Item> InstantiatedPrefabs => instantiatedPrefabs;


        public virtual void OnEnable()
        {
            if (!contentLoaded)
            {
                Clear();
                if (LoadingIconPrefab)
                {
                    loadingIcon = Instantiate(LoadingIconPrefab, LoadingIconParent ?? this.transform);
                    loadingIcon.transform.localPosition += positionOffset;
                }
            }
        }

        public virtual void Refresh()
        {
            Clear();

            if (Items != null)
            {

                //            instantiatedPrefab = Instantiate(Prefab) as Icon;
                foreach (object item in Items)
                {
                    Item icon = ObjectPool.Spawn<Item>(Prefab, transform);
                    icon.transform.SetParent(transform, false);
                    icon.transform.localScale = Prefab.transform.localScale;
                    icon.ClassReference = classRef;
                    icon.Data = item;
                    instantiatedPrefabs.Add(icon);
                }
            }
            DestroyLoadingIcon();

            // Invoke The OnRefresh Event
            OnRefresh.Invoke();
        }

        public void DestroyLoadingIcon()
        {
            if (loadingIcon)
                Destroy(loadingIcon);
        }

        public virtual void Clear()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                DestroyImmediate(transform.GetChild(i).gameObject);
            //InstantiatedPrefabs.Clear();
            //DestroyLoadingIcon();
            instantiatedPrefabs.Clear();
        }

        public virtual Item FirstIcon()
        {
            return GetComponentInChildren<Item>();
        }

        public virtual Item[] Icons()
        {
            return GetComponentsInChildren<Item>();
        }

        public virtual T FirstIcon<T>()
        {
            return GetComponentInChildren<T>();
        }

        public virtual T[] Icons<T>(bool value = false)
        {
            return GetComponentsInChildren<T>(value);
        }

        public virtual bool IsValid(int i)
        {
            return i >= 0 && i < Count;
        }

        public virtual int IndexOf(Item icon)
        {
            Item found = transform.GetComponentsInChildren<Item>(true).FirstOrDefault(i => i == icon);
            if (found != null)
                return found.transform.GetSiblingIndex();
            return -1;
        }

        public void SetReference(object _reference)
        {
            classRef = _reference;
        }

        public virtual Item this[int index]
        {
            get
            {
                if (IsValid(index))
                {
                    Transform child = transform.GetChild(index);
                    if (child != null)
                        return child.GetComponent<Item>();
                }
                return null;
            }
        }

        public virtual int Count
        {
            get
            {
                return transform.childCount;
            }
        }

        public virtual IEnumerable Items
        {
            get
            {
                return items;
            }
            set
            {
                contentLoaded = true;
                items = value;
                Refresh();
            }
        }
    }
}