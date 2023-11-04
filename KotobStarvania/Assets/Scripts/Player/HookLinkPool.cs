using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
    public class HookLinkPool : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private GameObject hookLinkPrefab;

        private List<GameObject> hookLinks = new List<GameObject>();

        void Start()
        {

        }

        public GameObject GetHookLink(){
            foreach (GameObject hookLink in hookLinks)
            {
                if(!hookLink.activeSelf){
                    hookLink.SetActive(true);
                    return hookLink;
                }
            }

            // If no inactive hooklinks are found, create a new one
            GameObject newHookLink = Instantiate(hookLinkPrefab, Vector3.zero, Quaternion.identity);
            hookLinks.Add(newHookLink);
            return newHookLink;
        }

        public void HideHookLinks()
        {
            foreach (GameObject hookLink in hookLinks)
            {
                hookLink.SetActive(false);
            }
        }

    }
}