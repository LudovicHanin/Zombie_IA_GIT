using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    private List<IPlayer> _players = new List<IPlayer>();
    public List<IPlayer> Players => _players;

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void AddPlayer(IPlayer player)
    {
        _players.Add(player);
        Debug.Log("Player Add");
    }

    public void RemovePlayer(IPlayer player)
    {
        if (!_players.Contains(player))
            return;
        _players.Remove(player);
    }
}
