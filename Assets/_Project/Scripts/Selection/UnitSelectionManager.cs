using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance { get; set; }
    
    public List<GameObject> selectedUnits;
    public List<GameObject> allUnits;
    
    [SerializeField] private Camera _mainCamera;
    
    void Start()
    {
        if (Instance != null && Instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                SelectByClicking(hit.collider.gameObject);
            }
            else
            {
                DeselectAllUnits();
            }
        }
    }
    
    public void DragSelect(GameObject unit)
    {
        if (selectedUnits.Contains(unit) == false)
        {
            selectedUnits.Add(unit);
            SelectUnit(unit, true);
        }
    }
    
    public void DeselectAllUnits()
    {
        foreach (var unit in selectedUnits)
        {
            SelectUnit(unit, false);
        }
        selectedUnits.Clear();
    }

    private void SelectByClicking(GameObject unit)
    {
        DeselectAllUnits();
        selectedUnits.Add(unit);
        SelectUnit(unit, true);
    }
    
    private void SelectUnit(GameObject unit, bool isSelected)
    {
        EnableUnitMovement(unit, isSelected);
        TriggerIndicator(unit, isSelected);
    }

    private void EnableUnitMovement(GameObject unit, bool isMove)
    {
        unit.GetComponent<UnitMovement>().enabled = isMove;
    }

    private void TriggerIndicator(GameObject unit, bool isSelected)
    {
        unit.transform.GetChild(0).gameObject.SetActive(isSelected);
    }
}
