// List
using System.Collections.Generic;

// Classe correspondant à une perception
public class Perception
{

    // Attributs

    // L'agent propriétaire de la perception
    protected Agent proprietaire;
    // Le rayon de vision
    protected float rayon;
    // l'angle de vision
    protected float angle;

    // Méthodes

    // Une perception se construit avec son proprietaire, de son rayon et angle de vue
    public Perception(Agent agent, float r, float a) {
        proprietaire = agent;
        rayon = r;
        angle = a;
    }

    // retourne les observations effectuées par la perception
    public List<Observation> voir() { 
        return proprietaire.getSystem().getVoisinage(proprietaire, rayon, angle);  
    }

}
