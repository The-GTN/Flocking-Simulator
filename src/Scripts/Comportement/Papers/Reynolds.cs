// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement du papier de Reynolds
public class Reynolds : Comportement
{

    // Attributs

    // constante de distance de séparation
    static public float Escape = 10.0f;
    // poids de la séparation
    static public float EscapeWeight = 1.0f;
    // constante de distance de l'alignement 
    static public float Together = 20.0f;
    // poids de l'alignement
    static public float TogetherWeight = 1.0f;
    // constante de distance de cohésion
    static public float Follow = 25.0f;
    // poids de la cohésion
    static public float FollowWeight = 1.0f;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire
    public Reynolds(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        List<Vector3> vectorsFuir = new List<Vector3>();
        List<Vector3> vectorsSuivre = new List<Vector3>();
        vectorsSuivre.Add(proprietaire.deplacement);
        List<Vector3> vectorsRapprocher = new List<Vector3>();
        foreach(Observation o in observation) {
            if (o.objet.isAlive()) {
                if(proprietaire.getSystem().AllReynolds) {
                    if(danger(o)) vectorsFuir.Add(fuir(o.distance));
                    if(normal(o)) vectorsSuivre.Add(suivre(o.objet));
                    if(isolement(o)) vectorsRapprocher.Add(rapprocher(o.distance));
                }
                else {
                    if(danger(o)) vectorsFuir.Add(fuir(o.distance));
                    else if(normal(o)) vectorsSuivre.Add(suivre(o.objet));
                    else if(isolement(o)) vectorsRapprocher.Add(rapprocher(o.distance));
                }
            }
        }
        float security = 1.0f;
        if(vectorsRapprocher.Count == 0) security = 0.0f;
        Vector3 res = EscapeWeight * Utils.meanVector(vectorsFuir).normalized + 
                      TogetherWeight * Utils.meanVector(vectorsSuivre).normalized + 
                      FollowWeight * security * 
                      (Utils.meanVector(vectorsRapprocher) - proprietaire.transform.position).normalized;
        
        return res.normalized;
    }
    
    // renvoie s'il faut s'éloigner
    private bool danger(Observation o) {
        return (Utils.normVector(o.distance) <= Escape);
    }

    // renvoie le vecteur d'eloignement
    private Vector3 fuir(Vector3 d) { return -d; }

    // renvoie s'il faut s'aligner
    private bool normal(Observation o) { 
        return Utils.normVector(o.distance) <= Together;
    }

    // renvoie le vecteur d'alignement
    private Vector3 suivre(Visible a) { 
        Agent agent = (Agent) a;
        return agent.deplacement;
    }

    // renvoie s'il faut se rapprocher
    private bool isolement(Observation o) {
        return Utils.normVector(o.distance) <= Follow;
    }

    // renvoie le vecteur de cohésion 
    private Vector3 rapprocher(Vector3 d) {
        return proprietaire.transform.position + d;
    }

}
