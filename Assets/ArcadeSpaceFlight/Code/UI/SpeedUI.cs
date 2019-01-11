//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows throttle and speed of the player ship.
/// </summary>
public class SpeedUI : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null && Ship.PlayerShip != null)
        {
            text.text = string.Format("THR: {0}\nSPD: {1}", (Ship.PlayerShip.Throttle * 100.0f).ToString("000"), Ship.PlayerShip.Velocity.magnitude.ToString("000"));
        }
    }
}
