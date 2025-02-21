// Copyright (c) 2024 Synty Studios Limited. All rights reserved.
//
// Use of this software is subject to the terms and conditions of the Synty Studios End User Licence Agreement (EULA)
// available at: https://syntystore.com/pages/end-user-licence-agreement
//
// Sample scripts are included only as examples and are not intended as production-ready.

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Synty.Interface.SciFiSoldierHUD.Samples
{
    /// <summary>
    ///     A simple countdown label that counts down from a set time.
    /// </summary>
    public class SampleCountdownLabel : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public TMP_Text text;

        [Header("Parameters")]
        public bool setAnimatorActive = true;
        public float initialDelay = 0;
        public float countdownTime = 30;
        public float updateInterval = 0.1f;
        public float timeUpDuration = 2.5f;
        public UnityEvent onCountdownComplete;

        private float currentTime;

        private void Reset()
        {
            text = GetComponentInChildren<TMP_Text>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(initialDelay);

            BeginTimer();
        }

        private void BeginTimer()
        {
            currentTime = countdownTime;
            RefreshUI();

            StartCoroutine(C_TickDown());
        }

        private IEnumerator C_TickDown()
        {
            while (currentTime > 0)
            {
                yield return new WaitForSeconds(updateInterval);

                currentTime -= updateInterval;
                if (currentTime <= 0)
                {
                    currentTime = 0;
                }

                RefreshUI();
            }

            if (setAnimatorActive)
                animator?.gameObject.SetActive(true);
            animator?.SetBool("Active", true);
            yield return new WaitForSeconds(timeUpDuration);

            animator?.SetBool("Active", false);
            yield return new WaitForSeconds(1);

            if (setAnimatorActive)
                animator?.gameObject.SetActive(false);

            onCountdownComplete?.Invoke();
            BeginTimer();
        }

        private void RefreshUI()
        {
            if (text)
                text.SetText(currentTime.ToString("F1"));
        }
    }
}
