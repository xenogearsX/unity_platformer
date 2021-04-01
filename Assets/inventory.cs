
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public int coinsCount;

   public static Inventory instance;
   private void Awake()
   {
       if(instance != null)
       {
           Debug.LogWarning("il y a plus d'une instance d'inventory dans la scène");
           return;
       }
       instance = this;
   }
   public void AddCoins(int count)
   {
       coinsCount += count;
   }
}
