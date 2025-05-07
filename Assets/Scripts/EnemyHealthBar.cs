using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public float distanceFromPlayer = 0.01f;
    private GameObject healthBarInstance { get; set; }
    
    private HealthManager healthMng;

    private RectTransform healthBarRect;
    private Canvas uiCanvas;
    
    void Start()
    {
        uiCanvas = FindObjectOfType<Canvas>();
        healthMng = GetComponent<HealthManager>();
        
        // Instantiate the UI under the canvas
        healthBarInstance = Instantiate(healthBarPrefab, uiCanvas.transform);
        healthBarInstance.transform.SetParent(uiCanvas.transform, false);
        healthBarRect = healthBarInstance.GetComponent<RectTransform>();

        healthMng.healthBar = healthBarInstance.GetComponent<Slider>();
        healthMng.InitHealthBar();
    }

    void Update()
    {
        // Position health bar above the enemy in screen space
        Vector3 worldPos = transform.position + Vector3.up * distanceFromPlayer;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        // Convert to UI local position for Screen Space - Camera canvas
        RectTransform canvasRect = uiCanvas.GetComponent<RectTransform>();
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, Camera.main, out localPoint))
        {
            healthBarRect.localPosition = localPoint;
        }
    }
}
