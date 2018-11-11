using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public GameObject player;
    public GameObject battleArea;
    public GameObject fightArea;
    public GameObject actMenu;
    public GameObject mainMenu;
    public GameObject itemMenu;
    public GameObject spareMenu;
    public GameObject testBullet;
    public BattleButton[] buttons;

    private Context currentContext = Context.MainMenu;

    private Vector2 battleAreaScale;
    private Vector2 battleAreaInitialScale;
    private Vector2 playerInitialPosition;

    private int menuIndex = 0;
    private int menuIndexMax = 3; // might want to change this for special cases like asgore

    // Use this for initialization
    void Start () {
        battleAreaScale = battleArea.transform.localScale;
        battleAreaInitialScale = battleArea.transform.localScale;
        playerInitialPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshPro>().SetText("Context: " + currentContext.ToString());

        if (Input.GetKeyDown("z") || Input.GetKeyDown("enter")) {
            currentContext = buttons[menuIndex].context;
        }

        if (Input.GetKeyDown("x")) {
            currentContext = Context.MainMenu;
        }

        // Move around the UI
        switch (currentContext) {
            case (Context.MainMenu):
                if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
                    menuIndex--;
                } else if (Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
                    menuIndex++;
                }
                
                if (menuIndex < 0) {
                    menuIndex = menuIndexMax;
                }

                if (menuIndex > menuIndexMax) {
                    menuIndex = 0;
                }
                battleAreaScale = battleAreaInitialScale;
                actMenu.SetActive(false);
                mainMenu.SetActive(true);
                itemMenu.SetActive(false);
                spareMenu.SetActive(false);
                UpdateMenu();
                break;
            case (Context.PlayerTurn):
                StartCoroutine(PlayerFight());
                mainMenu.SetActive(false);
                break;
            case (Context.EnemyTurn):
                battleAreaScale = new Vector2(.3f, battleAreaInitialScale.y);
                mainMenu.SetActive(false);
                break;
            case (Context.ActMenu):
                actMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
            case (Context.ItemMenu):
                itemMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
            case (Context.SpareMenu):
                spareMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
        }
    }

    private void FixedUpdate()
    {
        ResizeBattleArea(battleAreaScale);
    }

    IEnumerator PlayerFight()
    {
        fightArea.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyFight());
    }

    IEnumerator EnemyFight()
    {
        fightArea.SetActive(false);
        currentContext = Context.EnemyTurn;
        if(player.GetComponent<Player>().canMove == false) {
            player.transform.position = playerInitialPosition;
            player.GetComponent<Player>().canMove = true;
        }

        yield return new WaitForSeconds(3f);

        player.GetComponent<Player>().StopMoving();
        currentContext = Context.MainMenu;
    }

    void UpdateMenu()
    {
        for(int i = 0; i <= menuIndexMax; i++) {
            GameObject currentButton = buttons[i].instance;

            if (menuIndex == i) {
                Debug.Log(menuIndex);
                currentButton.GetComponent<SpriteRenderer>().sprite = buttons[i].spriteActive;
                player.transform.position = new Vector2(
                    currentButton.transform.position.x - .15f,
                    currentButton.transform.position.y
                );
            } else {
                currentButton.GetComponent<SpriteRenderer>().sprite = buttons[i].spriteInactive;
            }
        }
        
    }

    void SpawnTestBullet()
    {
        GameObject newTestBullet = Instantiate(testBullet);
        newTestBullet.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

        // fix negative z-axis bug
        newTestBullet.transform.position = new Vector2(newTestBullet.transform.position.x, newTestBullet.transform.position.y);
    }

    void ResizeBattleArea(Vector2 size)
    {
        battleArea.transform.localScale = Vector2.Lerp(battleArea.transform.localScale, size, 5f * Time.deltaTime);
    }
}
