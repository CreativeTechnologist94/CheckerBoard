using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [HideInInspector] public bool isClicked = false;
    private bool _canClick = true;
    private MeshRenderer _checkerRenderer;
    
    void Start()
    {
        _checkerRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    private void OnMouseDown()
	{
        if(!_canClick) return;

		if(!isClicked){
            SetCheckerColor(Color.yellow);
            isClicked = true;
		}
        else 
        {
            SetCheckerColor(Color.red);
            isClicked = false;
        }
	}
    public void MoveChecker(Vector3 targetPos)
    {
        _canClick = false;
        isClicked = false;
        SetCheckerColor(Color.red);
        StartCoroutine(MoveToTarget(targetPos));
    }
    private IEnumerator MoveToTarget(Vector3 boardPiecePos)
    {
        float moveDuration = 0.25f;
        float elapsedTime = 0.0f;
        Vector3 startingPos = transform.position;
        Vector3 _targetPos = new Vector3(boardPiecePos.x, transform.position.y, boardPiecePos.z);

        while(elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startingPos, _targetPos , elapsedTime/moveDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = _targetPos;
        _canClick = true;
    }
    private void SetCheckerColor(Color _color)
    {
        _checkerRenderer.material.SetColor("_Color", _color);
    }
}
