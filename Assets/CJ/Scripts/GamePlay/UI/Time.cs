// Copyright 2024 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License").
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using CJ.Scripts.GamePlay.State;
using System;
using TMPro;
using UnityEngine;

namespace CJ.Scripts.GamePlay.UI
{
    public class Time : MonoBehaviour
    {
        public TMP_Text text;

        private void FixedUpdate()
        {
            if (!GameManager.Instance.isRunning) return;

            var time = (GameManager.Instance.state as GamePlayState_Running).playTime;
            text.text = $"{Mathf.Floor(time / 60).ToString("00")}:{Mathf.Floor(time % 60).ToString("00")}";
        }
    }
}
