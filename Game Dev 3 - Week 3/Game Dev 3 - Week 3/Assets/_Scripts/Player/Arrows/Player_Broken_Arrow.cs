using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameDevWithMarco.Player
{
    public class NewBehaviourScript : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        [SerializeField] float arrowShakeTime;
        [SerializeField] float arrowShakeStrength;
        [SerializeField] float arrowFadeTime;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(ShakeTheArrowOnCreation());
        }

        private IEnumerator ShakeTheArrowOnCreation()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.transform.DOShakeScale(arrowShakeTime, arrowShakeStrength);
                yield return new WaitForSeconds(arrowShakeTime);
                StartCoroutine(FadeThenDestroyLogic());
            }
        }

        private IEnumerator FadeThenDestroyLogic()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.DOFade(0, arrowFadeTime);
                yield return new WaitForSeconds(arrowFadeTime);
                Destroy(gameObject);
            }
        }
    }
}
