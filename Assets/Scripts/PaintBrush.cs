using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public Transform paintBrushTip;
    public GameObject paintPrefab;
    public Material _tempMaterial;
    public GameObject _tempPaint;

    public List<GameObject> objectsToArrange;

    public Material defaultMat;
    public void StartPainting()
    {
        _tempPaint = Instantiate(paintPrefab, paintBrushTip.position, paintBrushTip.rotation);
        _tempPaint.transform.SetParent(paintBrushTip);
        if (_tempMaterial != null)
        {
            _tempPaint.GetComponent<TrailRenderer>().material = _tempMaterial;
        }
        else
        {
            _tempPaint.GetComponent<TrailRenderer>().material = defaultMat;
        }

        foreach (var item in objectsToArrange)
        {
            if (item.GetComponent<MeshRenderer>() != null)
            {
                Debug.Log("Mesh Renderer Found");
            }
            else
            {
                Debug.Log("No Mesh Renderer Found");
            }
        }
    }

    public void StopPainting()
    {
        if (_tempPaint != null)
        {
            _tempPaint.transform.SetParent(null);
            _tempPaint = null;
        }

        objectsToArrange.RemoveAt(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paint"))
        {
            _tempMaterial = other.GetComponent<MeshRenderer>().material;
            paintBrushTip.GetComponent<MeshRenderer>().material.color = _tempMaterial.color;
        }
    }
}
