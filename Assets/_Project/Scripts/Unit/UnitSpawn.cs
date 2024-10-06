using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _delay;
    
    [Range(0, 200)] public int _offsetX;
    [Range(0, 200)] public int _offsetY;
    [Range(0,2)] public float  _timeToBuild;
    private int _widthScreen;
    private int _heightScreen;
    private System.Random _random;
    private Canvas can;


    private void Start()
    {
        _camera = Camera.main;
        _widthScreen = Screen.width/2;
        _heightScreen = Screen.height/2;
        StartCoroutine(VirusCreationDelay());
        _random = new Random();
        //_camera.transform.position = new Vector3(_widthScreen, _heightScreen, -10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_unit, new Vector3(_random.Next(_offsetX, _widthScreen - _offsetX),
                    _random.Next(_offsetY, _heightScreen - _offsetY), 0),
                transform.rotation);
        }
    }

    //получить Canvas.scale
    // позиция мыши относительно Canvas
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator VirusCreationDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Instantiate(_enemy, new Vector3(_random.Next(_offsetX, _widthScreen - _offsetX),
                    _random.Next(_offsetY, _heightScreen - _offsetY), 0),
                    transform.rotation);
        }
    }

    private IEnumerator UnitCreationDelay()
    {
        yield return new WaitForSeconds(_timeToBuild);
            Instantiate(_enemy, new Vector3(_random.Next(_offsetX, _widthScreen - _offsetX),
                    _random.Next(_offsetY, _heightScreen - _offsetY), 0),
                transform.rotation);
    }
}
