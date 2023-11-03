using UnityEngine;
namespace Starvania
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static int m_referenceCount = 0;

        private static T m_instance;

        public static T instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<T>();
                }
                return m_instance;
            }
        }

        void Awake()
        {
            m_referenceCount++;
            if (m_referenceCount > 1)
            {
                Debug
                    .LogWarning("Attemped to create additional static instance: " +
                    this.gameObject.name);
            }

            m_instance = this as T;
        }

        void OnDestroy()
        {
            m_referenceCount--;
            if (m_referenceCount == 0)
            {
                m_instance = null;
            }
        }
    }
}