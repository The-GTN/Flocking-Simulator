// Vector3
using UnityEngine;
// list
using System.Collections.Generic;

// 2eme classe pour comportement de bord qui répond en tangente 
public class TangenteBord2 : TangenteBord1
{
    // Attributs
    
    // constante de force de tangente
    public static float kT = 1.0f;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire
    public TangenteBord2(Agent proprietaire) : base(proprietaire) {}
    
    // retourne l'intensité du vecteur réponse selon une distance
    protected override float deltaTan(Vector3 d) {
        return kT/Utils.normVector(d);
    }
    
}
