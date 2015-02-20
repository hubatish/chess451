using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ColorChangeObject : Photon.MonoBehaviour
{
    void Update()
    {
        if (photonView.isMine)
        {
            InputColorChange();
        }
    }

    private void InputColorChange()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ChangeColorTo(new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)));
    }

    [RPC]
    void ChangeColorTo(Vector3 color)
    {
        renderer.material.color = new Color(color.x, color.y, color.z, 1f);

        if (photonView.isMine)
            photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
    }
}

