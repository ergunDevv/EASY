using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharactersShopData
{
    public List<int> purchasedCharactersIndexes = new List<int>();

}

[System.Serializable]
public class PlayerData
{
    public int coins = 0;
    public int crowns = 0;
    public int selectedCharacterIndex = 0;
    public int selectedColorIndex = 0;
}

public static class GameDataManager
{


    static PlayerData playerData = new PlayerData();
    static CharactersShopData charactersShopData = new CharactersShopData();


    static Character selectedCharacter;

    static ParticleSystem characterParicleEffect;

    
    static GameDataManager()
    {
        LoadPlayerData();
        LoadCharacterShopData();

    }






    public static void SetSelectedCharacter(Character character, int index)
    {
        selectedCharacter = character;
        playerData.selectedCharacterIndex = index;
        playerData.selectedColorIndex = index;




        SavePlayerData();
        SaveCharacterShopData();



    }
    public static Character GetSelectedCharacter()
    {



        return selectedCharacter;

    }

    public static int GetSelectedCharacterIndex()
    {
        return playerData.selectedCharacterIndex;
    }

    public static void SetSelectedCharacterIndex(int newIndex)
    {
        playerData.selectedCharacterIndex = newIndex;
        SavePlayerData();

    }
    public static int GetCoins()
    {
        return playerData.coins;
    }
    public static void AddCoins()
    {
        playerData.coins++;
        SavePlayerData();
    }
    public static bool CanSpendCoins(int amount)
    {
        return (playerData.coins >= amount);
    }
    public static void SpendCoins(int amount)
    {
        playerData.coins -= amount;

        SavePlayerData();
    }
    public static int GetCrowns()
    {
        return playerData.crowns;
    }
    public static void AddCrowns()
    {
        playerData.crowns++;
        SavePlayerData();
    }
    public static bool CanSpendCrowns(int amount)
    {
        return (playerData.crowns >= amount);
    }
    public static void SpendCrowns(int amount)
    {
        playerData.crowns -= amount;

        SavePlayerData();
    }
    public static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>("player-data.txt");
        UnityEngine.Debug.Log("loaded LoadPlayerData");
    }
    public static void SavePlayerData()
    {
        BinarySerializer.Save(playerData, "player-data.txt");
        UnityEngine.Debug.Log("saved SavePlayerData");

    }
    // Characters Shop Data Methods
    public static void AddPurchasedCharacter(int characterIndex)
    {
        charactersShopData.purchasedCharactersIndexes.Add(characterIndex);
        SaveCharacterShopData();
    }public static void RemovePurchasedCharacter(int characterIndex)
    {
        charactersShopData.purchasedCharactersIndexes.Remove(characterIndex);
        SaveCharacterShopData();
    }

    public static List<int> GetAllPurchasedCharacter()
    {
        return charactersShopData.purchasedCharactersIndexes;
    }
    public static int GetPurchasedCharacter(int index)
    {
        return charactersShopData.purchasedCharactersIndexes[index];
    }


    public static void LoadCharacterShopData()
    {
        charactersShopData = BinarySerializer.Load<CharactersShopData>("characters-shop-data.txt");
        UnityEngine.Debug.Log("loaded LoadCharacterShopData");
    }
    public static void SaveCharacterShopData()
    {
        BinarySerializer.Save(charactersShopData, "characters-shop-data.txt");
        UnityEngine.Debug.Log("saved SaveCharacterShopData");

    }

    public static void AddAlotOfCoins(int value)
    {
        playerData.coins+=value;
        SavePlayerData();
    }
    public static void AddAlotOfCrowns(int value)
    {
        playerData.crowns+=value;
        SavePlayerData();
    }


}
