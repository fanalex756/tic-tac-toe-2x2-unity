using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public ScoreUIManager keepScore;
    public Button resetButton;
    public Button quitButton;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        resetButton.transform.localScale = new Vector3(0, 0, 0);
        quitButton.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ChangePlayer()
    {
        if (CurrentPlayer == Owner.None)
            return;

        if (CheckForWinner())
        {
            resetButton.transform.localScale = new Vector3(1, 1, 1);
            quitButton.transform.localScale = new Vector3(1, 1, 1);
            keepScore.UpdateScore(CurrentPlayer);
            CurrentPlayer = Owner.None;
            return;
        }

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public void Reset()
    {
        foreach (Tile tile in Tiles)
        {
            tile.owner = Owner.None;
            tile.GetComponent<SpriteRenderer>().color = Color.white;
        }
        StartGame();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You quit the game");
    }

    public bool CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            return true;
        }

        return false;
    }


}
