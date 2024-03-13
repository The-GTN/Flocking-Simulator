// Classe correspondant à une perception 360°
public class Perception360 : Perception
{
    // Une perception se construit avec son proprietaire, de son rayon et angle de vue
    public Perception360(Agent agent, float r) : base(agent, r, 360.0f) {}

}
