// Vector3
using UnityEngine;

// Classe abstraite pour la topologie d'un environnement
public abstract class Topologie
{
    // Attributs

    // Environnement auquel appartient la topologie
    protected Environnement environnement;

    // Méthodes

    // Constructeur abstrait d'une topologie d'un environnement
    public Topologie(Environnement env) {
        environnement = env;
    }

    // retourne le GameObject de la topologie
    public abstract GameObject getGameObject();

    // retourne le point de la topologie que l'agent current pourrait heurter
    public abstract Observation detectEnv(Agent current);

    // retourne une position valide dans la topologie
    public abstract Vector3 validPosition();

    // indique si la position est valide dans la topologie
    public abstract bool isValidPosition(Vector3 pos);

    // retourne la distance maximale mesurable dans la topologie
    public abstract float getMaxDistance();

}
