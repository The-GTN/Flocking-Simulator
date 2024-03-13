// Classe correspondant à une perception 90°
public class Perception90 : Perception
{
    // Une perception se construit avec son proprietaire, de son rayon et angle de vue
    public Perception90(Agent agent, float r) : base(agent, r, 90.0f) {}
}
