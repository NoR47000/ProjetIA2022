//GCost caculé en fonction distEuclidienne<distManhattan ainsi pour toute nos estimation 
//on devra prendre comme distance la distance euclidienne 

// Problème 1 : 

//Dans ce problème nous n'avons  pas le droit de tester la
//présence d’un marécage à une position donnée, notre heuristique 
//doit rester valable mêmesi on change la zone marécageuse.

//Pour cela la détection de franchissement de marécage dans notre
//heuristique doit ce faire exclusivement grâce à la valuer de matrice[x,y]
//On doit alors créer un chemin passant par des coordonnées entière et 
//vérifier le type de case rencontrée

//Pour avoir un chemin de case entière on va prendre en distance de référence
//la distance de Manhattan entre 2 points.

//Distance Manhattan entre PC et PF (un nombre de cases)
double distManhattan =Math.Abs(this.x - Form1.xfinal) + Math.Abs(this.y - Form1.yfinal); 

//Compteur du nombre de marécage rencontré sur le chemin
int cmpt =0;

//Variable intermédiare pour ne pas modifier les coordonnées du point courant
int cheminX = x;
int cheminY = y;
while(cheminX!=Form1.xfinal && cheminY!=Form1.yfinal)
{
    if(cheminX<Form1.xfinal)
    {
        cheminX+=1;      
    }
    else if(cheminX>Form1.xfinal)
    {
        cheminX-=1;
    }

    if(cheminY<Form1.yfinal)
    {
        cheminY+=1;
    }
    else if(cheminY>Form1.yfinal)
    {
        cheminY-=1;
    }

    if(matrice[cheminX,cheminY]==-1);cmpt+=1
}

//La distance totale est alors la somme du nombre de marécage rencontré fois trois
//plus le reste des cases à parcourir pour arriver à PF
return(3*cmpt+(distManhattan-cmpt))

//Enoncer le problème si on est en haut à gauche et bas à droite du marécage
//Chemin le plus court on sort du marécage donc vu que l'estimation passe par
//le marécage on aura une estimation plus élevée que le chemin reel. 
