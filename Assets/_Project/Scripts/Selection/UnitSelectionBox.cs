// using UnityEngine;
// using UnityEngine.UI;
//
// public class UnitSelectionBox : MonoBehaviour
// {
//     [SerializeField] private RectTransform boxVisual;
//     [SerializeField] private Canvas _canvas;
//     private Camera _mainCamera;
//     private Rect selectionBox;
//     private Vector3 _startPosition;
//     private Vector3 _endPosition;
//     private Vector3 _mousePosition;
//     private Ray _rayStart;
//     private Ray _rayEnd;
//
//     private Vector2 startMP;
//     private void Start()
//     {
//         _mainCamera = Camera.main;
//         _startPosition = Vector3.zero;
//         _endPosition = Vector3.zero;
//         //_mousePosition = Input.mousePosition / _canvas.scaleFactor;
//         DrawVisual();
//     }
//  
//     private void Update()
//     {
//         _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
//         if (Input.GetMouseButtonDown(0))
//         {
//             _startPosition = _mousePosition;
//             boxVisual.position = _startPosition;
//             boxVisual.sizeDelta = new Vector2(0, 0);
//             selectionBox = new Rect();
//             Debug.Log("Start pos: " + _startPosition);
//         }
//  
//         if (Input.GetMouseButton(0))
//         {
//             if (boxVisual.rect.width > 0 || boxVisual.rect.height > 0)
//             {
//                 UnitSelectionManager.Instance.DeselectAllUnits();
//                 SelectUnits();
//             }
//             
//             // _rayEnd =  _mainCamera.ScreenPointToRay(Input.mousePosition);
//             _endPosition = _mousePosition;
//             
//             DrawVisual();
//             DrawSelection();
//             // Debug.Log($"xMin = " + selectionBox.xMin + "& xMax = " + selectionBox.xMax);
//         }
//  
//         // if (Input.GetMouseButtonUp(0))
//         // {
//         //     SelectUnits();
//         //     _rayStart.origin = Vector3.zero;
//         //     _rayEnd.origin = Vector3.zero;
//         //     DrawVisual();
//         // }
//     }
//  
//     private void DrawVisual()
//     {
//         Vector2 boxStart = _startPosition;
//         Vector2 boxEnd = _endPosition;
//         Vector2 boxCenter = (boxStart + boxEnd) / 2;
//         boxVisual.position = boxCenter;
//         Debug.Log(_canvas.scaleFactor);
//         Vector2 boxDir = (boxEnd - boxStart) * 100 / _canvas.scaleFactor;
//         Vector2 boxSize = new Vector2(Mathf.Abs(boxDir.x), Mathf.Abs(boxDir.y));
//         boxVisual.sizeDelta = boxSize;
//         
//         // Vector2 boxStart = new Vector2(_rayStart.origin.x,_rayStart.origin.y);
//         // Vector2 boxEnd = new Vector2(_rayEnd.origin.x, _rayEnd.origin.y);
//         // Vector2 boxCenter = (boxStart + boxEnd) / 2;
//         // boxVisual.position = boxCenter;
//         // Vector2 boxSize = ((Vector2)Input.mousePosition - startMP)*2;
//         // //Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
//         // boxVisual.sizeDelta = new Vector2(Mathf.Abs(boxSize.x), Mathf.Abs(boxSize.y)) * 2;
//     }
//  
//     private void DrawSelection()
//     {
//         if (Input.mousePosition.x < _startPosition.x)
//         {
//             selectionBox.xMin = Input.mousePosition.x;
//             selectionBox.xMax = _startPosition.x;
//         }
//         else
//         {
//             selectionBox.xMin = _startPosition.x;
//             selectionBox.xMax = Input.mousePosition.x;
//         }
//  
//         if (Input.mousePosition.y < _startPosition.y)
//         {
//             selectionBox.yMin = Input.mousePosition.y;
//             selectionBox.yMax = _startPosition.y;
//         }
//         else
//         {
//             selectionBox.yMin = _startPosition.y;
//             selectionBox.yMax = Input.mousePosition.y;
//         }
//         
//         
//         // Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
//         // RaycastHit2D hit = Physics2D.Raycast(ray.origin *2 , Vector2.zero);
//         // if (hit.point.x < _rayStart.origin.x)
//         // {
//         //     selectionBox.xMin = hit.point.x; //Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
//         //     selectionBox.xMax = _rayStart.origin.x;
//         // }
//         // else
//         // {
//         //     selectionBox.xMin = _rayStart.origin.x;
//         //     selectionBox.xMax = hit.point.x;
//         // }
//         //
//         // if (hit.point.y < _rayStart.origin.y)
//         // {
//         //     selectionBox.yMin = hit.point.y;
//         //     selectionBox.yMax = _rayStart.origin.y;
//         // }
//         // else
//         // {
//         //     selectionBox.yMin = _rayStart.origin.y;
//         //     selectionBox.yMax = hit.point.y;
//         //     Debug.Log($"yMin = " + selectionBox.yMin + "& yMax = " + selectionBox.yMax);
//         // }
//     }
//  
//     private void SelectUnits()
//     {
//         foreach (var unit in UnitSelectionManager.Instance.allUnits)
//         {
//             if (selectionBox.Contains(_mainCamera.WorldToScreenPoint(unit.transform.position)))
//             {
//                 UnitSelectionManager.Instance.DragSelect(unit);
//             }
//         }
//     }
// }