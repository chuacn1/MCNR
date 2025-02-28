public class HealthPotion
{
    //details for health potion
    public string name { get; set; }
    public int healingAmount { get; set; }
    public int Cost { get; set; }
    public int maxUses { get; set; } = 3;
    public int currentUses { get; set; }

    //required material to craft this potion
    public static string requiredMaterial = "Delicate Flower";
    public static int requiredQuantity = 1;
}