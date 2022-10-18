using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color homeBlue, homePink, blue, pink, grey;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public BaseUnit OccupiedUnit;
    public void Init(int colorInd)
    {
        switch (colorInd)
        {
            case 0:
                spriteRenderer.color = grey;
                break;
            case 1:
                spriteRenderer.color = homeBlue;
                break;
            case 2:
                spriteRenderer.color = homePink;
                break;
            case 3:
                spriteRenderer.color = blue;
                break;
            case 4:
                spriteRenderer.color = pink;
                break;
        }
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.state != GameState.BattleModeBlue && GameManager.Instance.state != GameState.BattleModePink) return;


        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.CanBeSelected() && !TurnManager.Instance.hasMovedThisTurn) UnitManager.Instance.SetSelectedUnit(OccupiedUnit); //If its my turn and I select another one of my own pieces, select the new piece.
            else
            {
                if (UnitManager.Instance.SelectedHero != null)
                {
                    var enemy = (BaseUnit)OccupiedUnit;
                    //Initiate Combat Mode
                    UnitManager.Instance.SetSelectedUnit(null);
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null)
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedUnit(null);
                TurnManager.Instance.hasMovedThisTurn = true;
            }
        }

    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
