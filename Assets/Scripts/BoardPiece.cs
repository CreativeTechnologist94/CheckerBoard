using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour
{
    public Checker checker;

    private void OnMouseDown()
    {
        if(checker.isClicked)
        {
            checker.MoveChecker(transform.position);
        }
    }

}
