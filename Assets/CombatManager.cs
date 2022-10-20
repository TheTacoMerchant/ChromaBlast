using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;
    public GameObject Map5;
    public GameObject Map6;

    public Transform BlueSpawn1;
    public Transform BlueSpawn2;
    public Transform BlueSpawn3;
    public Transform BlueSpawn4;
    public Transform BlueSpawn5;
    public Transform BlueSpawn6;

    public Transform PinkSpawn1;
    public Transform PinkSpawn2;
    public Transform PinkSpawn3;
    public Transform PinkSpawn4;
    public Transform PinkSpawn5;
    public Transform PinkSpawn6;

    public GameObject BlueRifleman;
    public GameObject BlueShotgun;
    public GameObject BlueSniper;

    public GameObject PinkRifleman;
    public GameObject PinkShotgun;
    public GameObject PinkSniper;

    public Camera camera;

    public List<BaseUnit> battleunits;

    private int mapNumber;

    public static CombatManager Instance;

    private GameState previousState;
    private Tile combatTile;

    public void Awake(){
        Instance = this;
        mapNumber = Random.Range(1,7);
    }

    public void Combat(GameState prevState, Tile tile){
        string bluePlayer = null,pinkPlayer = null;
        int blueBattleUnitsIdx = 0,pinkBattleUnitsIdx = 0;
        if(battleunits[0].Faction == Faction.Blue){
            blueBattleUnitsIdx = 0;
            pinkBattleUnitsIdx = 1;
            if(battleunits[0].GetType() == typeof(Rifleman)) bluePlayer = "Rifleman";
            else if(battleunits[0].GetType() == typeof(ShotgunUnit)) bluePlayer = "ShotgunUnit";
            else if(battleunits[0].GetType() == typeof(SniperUnit)) bluePlayer = "SniperUnit";

            if(battleunits[1].GetType() == typeof(Rifleman)) pinkPlayer = "Rifleman";
            if(battleunits[1].GetType() == typeof(ShotgunUnit)) pinkPlayer = "ShotgunUnit";
            if(battleunits[1].GetType() == typeof(SniperUnit)) pinkPlayer = "SniperUnit";
        } else {
            blueBattleUnitsIdx = 1;
            pinkBattleUnitsIdx = 0;
            if(battleunits[0].GetType() == typeof(Rifleman)) pinkPlayer = "Rifleman";
            else if(battleunits[0].GetType() == typeof(ShotgunUnit)) pinkPlayer = "ShotgunUnit";
            else if(battleunits[0].GetType() == typeof(SniperUnit)) pinkPlayer = "SniperUnit";
            
            if(battleunits[1].GetType() == typeof(Rifleman)) bluePlayer = "Rifleman";
            if(battleunits[1].GetType() == typeof(ShotgunUnit)) bluePlayer = "ShotgunUnit";
            if(battleunits[1].GetType() == typeof(SniperUnit)) bluePlayer = "SniperUnit";
        }

        previousState = prevState;
        combatTile = tile;

        if(mapNumber == 1){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn1.position, BlueSpawn1.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn1.position, BlueSpawn1.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn1.position, BlueSpawn1.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn1.position, PinkSpawn1.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn1.position, PinkSpawn1.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn1.position, PinkSpawn1.rotation);
            }

            panCamera(Map1.transform.position.x, Map1.transform.position.y);
        }
        else if(mapNumber == 2){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn2.position, BlueSpawn2.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn2.position, BlueSpawn2.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn2.position, BlueSpawn2.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn2.position, PinkSpawn2.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn2.position, PinkSpawn2.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn2.position, PinkSpawn2.rotation);
            }
            panCamera(Map2.transform.position.x, Map2.transform.position.y);
        }
        else if(mapNumber == 3){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn3.position, BlueSpawn3.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn3.position, BlueSpawn3.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn3.position, BlueSpawn3.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn3.position, PinkSpawn3.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn3.position, PinkSpawn3.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn3.position, PinkSpawn3.rotation);
            }
            panCamera(Map3.transform.position.x, Map3.transform.position.y);
        }
        else if(mapNumber == 4){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn4.position, BlueSpawn4.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn4.position, BlueSpawn4.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn4.position, BlueSpawn4.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn4.position, PinkSpawn4.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn4.position, PinkSpawn4.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn4.position, PinkSpawn4.rotation);
            }
            panCamera(Map4.transform.position.x, Map4.transform.position.y);
        }
        else if(mapNumber == 5){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn5.position, BlueSpawn5.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn5.position, BlueSpawn5.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn5.position, BlueSpawn5.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn5.position, PinkSpawn5.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn5.position, PinkSpawn5.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn5.position, PinkSpawn5.rotation);
            }
            panCamera(Map5.transform.position.x, Map5.transform.position.y);
        }
        else if(mapNumber == 6){
            if(bluePlayer == "Rifleman"){
                GameObject blueRifleman = Instantiate(BlueRifleman, BlueSpawn6.position, BlueSpawn6.rotation);
            }
            else if(bluePlayer == "ShotgunUnit"){
                GameObject blueShotgun = Instantiate(BlueShotgun, BlueSpawn6.position, BlueSpawn6.rotation);
            }
            else{
                GameObject blueSniper = Instantiate(BlueSniper, BlueSpawn6.position, BlueSpawn6.rotation);
            }

            if(pinkPlayer == "Rifleman"){
                GameObject pinkRifleman = Instantiate(PinkRifleman, PinkSpawn6.position, PinkSpawn6.rotation);
            }
            else if(pinkPlayer == "ShotgunUnit"){
                GameObject pinkShotgun = Instantiate(PinkShotgun, PinkSpawn6.position, PinkSpawn6.rotation);
            }
            else{
                GameObject pinkSniper = Instantiate(PinkSniper, PinkSpawn6.position, PinkSpawn6.rotation);
            }
            panCamera(Map6.transform.position.x, Map6.transform.position.y);
        }
        // THIS IS TEMPORARY
        List<string> players = new List<string>{"pink", "blue"};
        //var random = new Random();
        int idx = Random.Range(0,2);
        Debug.Log(idx);
        string winner = players[idx];

        // keep this
        Debug.Log($"Winner is {winner}.");
        if(winner == "pink"){
            DestroyImmediate(battleunits[blueBattleUnitsIdx]);
            Debug.Log($"trying to destroy {battleunits[blueBattleUnitsIdx]}");
            combatTile.spriteRenderer.color = combatTile.pink;
            tile.SetUnit(battleunits[pinkBattleUnitsIdx]);
        } else {
            combatTile.spriteRenderer.color = combatTile.blue;
            Debug.Log($"trying to destroy {battleunits[pinkBattleUnitsIdx]}");
            DestroyImmediate(battleunits[pinkBattleUnitsIdx]);
            tile.SetUnit(battleunits[blueBattleUnitsIdx]);
        }
        panCamera(1f,-1.66f);
        GameManager.Instance.ChangeState(prevState);
    }

    public void panCamera(float x, float y){
        camera.transform.position = new Vector3(x,y,-5f);
    }

    public void SwitchStates(){
        panCamera(1f,-1.66f);
        GameManager.Instance.ChangeState(previousState);
        GameObject[] blueUnits = GameObject.FindGameObjectsWithTag("Blue");
        GameObject[] pinkUnits = GameObject.FindGameObjectsWithTag("Pink");
        
        foreach(GameObject blueUnit in blueUnits){
            if(blueUnit != null){
                Destroy(blueUnit);
            }
        }
        
        foreach(GameObject pinkUnit in pinkUnits){
            if(pinkUnit != null){
                Destroy(pinkUnit);
            }
        }
        
        
    }
}
