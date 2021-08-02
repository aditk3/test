using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour {
    [SerializeField] private Color defaultColor  = Color.white;
    [SerializeField] private Color blockedColor  = Color.grey;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor     = new Color(1f, .5f, 0f);

    private TextMeshPro label;
    private Vector2Int  coordinates = new Vector2Int();

    private GridManager gridManager;

    private void Awake() {
        label         = GetComponent<TextMeshPro>();
        label.enabled = false;

        gridManager = FindObjectOfType<GridManager>();

        DisplayCoordinates();
    }

    void Update() {
        if (!Application.isPlaying) {
            DisplayCoordinates();
            UpdateObjName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.enabled;
        }
    }

    void SetLabelColor() {
        if (gridManager == null) return;

        Node node = gridManager.GetNode(coordinates);
        if (node == null) return;

        if (!node.isWalkable) {
            label.color = blockedColor;
        }
        else if (node.isPath) {
            label.color = pathColor;
        }
        else if (node.isExplored) {
            label.color = exploredColor;
        }
        else {
            label.color = defaultColor;
        }
    }

    void DisplayCoordinates() {
        if (gridManager == null) return;
        
        Vector3 parentPosition = transform.parent.position;
        coordinates.x = Mathf.RoundToInt(parentPosition.x / 10);
        coordinates.y = Mathf.RoundToInt(parentPosition.z / 10);

        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjName() {
        transform.parent.name = coordinates.ToString();
    }
}