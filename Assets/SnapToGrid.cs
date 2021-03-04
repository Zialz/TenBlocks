using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToGrid : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public Vector3 gridSize = default;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectExited.AddListener(Snap);
    }

    private void Snap(XRBaseInteractor interactor)
    {
        var position = new Vector3(
        Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
        Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
        Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.z
        );
        this.transform.position = position;
    }
}
