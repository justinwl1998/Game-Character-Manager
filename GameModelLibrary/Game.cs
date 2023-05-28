using System;

public class Game
{
    private String _name;
    private String _platform;
    private String _releaseDate;
    private double _price;
    private int _maxPlayers;
    private bool _isOnPC;
    private bool _isExpired;

    // Default constructor
    public Game()
    {
        _name = "";
        _platform = "";
        _releaseDate = "01-01-1970";
        _price = 0.0;
        _maxPlayers = 1;
        _isOnPC = false;
        _isExpired = false;
    }

    // Constructor with parameters
	public Game(String name, 
                String platform,
                String releaseDate, 
                double price, 
                int maxPlayers, 
                bool isOnPC, 
                bool isExpired)
	{
        _name = name;
        _platform = platform;
        _releaseDate = releaseDate;
        _price = price;
        _maxPlayers = maxPlayers;
        _isOnPC = isOnPC;
        _isExpired = isExpired;
	}

    // Properties
    public string Name { get { return _name; } set { _name = value; } }
    public string Platform { get { return _platform; } set { _platform = value; } }
    public string ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
    public double Price { get { return _price; } set { _price = value; } }
    public int MaxPlayers { get { return _maxPlayers; } set { _maxPlayers = value; } }
    public bool IsOnPC { get { return _isOnPC; } set { _isOnPC = value; } }
    public bool IsExpired { get { return _isExpired; } set { IsExpired = value; } }
}
