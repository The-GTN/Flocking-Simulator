// Classe correspondant à une perception 180°
public class Perception180 : Perception
{
    // Une perception se construit avec son proprietaire, de son rayon et angle de vue
    public Perception180(Agent agent, float r) : base(agent, r, 180.0f) {}
}
