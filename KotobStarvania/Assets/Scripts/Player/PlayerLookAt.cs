using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Starvania
{
    public class PlayerLookAt : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private GameObject swordParent;
        [SerializeField] private GameObject knightSprite;

        public UnityAction<Vector2> onLook;
        void Start()
        {
            onLook += Look;
        }

        void Look(Vector2 _direction)
        {

            if (Platform.IsOnPc())
            {
                _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            }
            if (_direction.magnitude > 0)
            {
                swordParent.transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
            }

            if(_direction.x > 0){
                knightSprite.transform.localScale = new Vector3(1, 1, 1);
            }else{
                knightSprite.transform.localScale = new Vector3(-1, 1, 1);
            }
        }


    }
}