using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Arrow_Logic : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        [SerializeField] float arrowShakeTime;
        [SerializeField] float arrowShakeStrength;
        [SerializeField] float arrowFadeTime;

        //To store the prefab of the broken arrow
        public GameObject brokenArrow;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Will instantiate the broken arrow prefab
            Instantiate(brokenArrow, transform.position, Quaternion.identity);
            //Will destroy the game object this script is attached to
            Destroy(gameObject);
        }

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(ShakeTheArrowOnCreation());
        }

        private IEnumerator ShakeTheArrowOnCreation()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer.DOFade(0, arrowFadeTime);
                yield return new WaitForSeconds(arrowFadeTime);
                Destroy(gameObject);
            }
        }
    }
}