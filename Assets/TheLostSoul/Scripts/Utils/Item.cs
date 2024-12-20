using UnityEngine;

namespace tls.utils
{
    public class Item : MonoBehaviour
    {
        protected object data;
        public object reference;
        public virtual void Refresh()
        {

        }

        public virtual object Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                Refresh();
            }
        }

        public void SetData(object data)
        {
            this.data = data;
        }

        public virtual object ClassReference
        {
            get => reference;
            set => reference = value;
        }

        public virtual void Clear()
        {
            reference = null;
            data = null;
            Refresh();
        }
        public virtual int Index
        {
            get
            {
                return transform.GetSiblingIndex();
            }
            set
            {
                transform.SetSiblingIndex(value);
            }
        }
    }
}