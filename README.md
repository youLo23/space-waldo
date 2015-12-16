# space-waldo
worst space shooter ever

http://youlo23.github.io/space-waldo/Space_Waldo/Space_Waldo.html

### Objectifs
- Développer un Space Invaders avec l’aide du moteur 3D Unity.
- Etre capable d’enregistrer les scores.
- Ajouter des éléments de Gameplay originaux.

### Problématiques
- Temps de formation de l’équipe à Unity et au C#.
- Travailler à plusieurs sur les mêmes codes

### Unity 3D et les moteurs de jeu
Afin d’obtenir un rendu graphique de qualité, sans que cela ne représente une charge de travail trop importante, nous avons fait le choix d’utiliser un moteur de jeu.

Un moteur de jeu est un ensemble de composants logiciels qui effectuent des calculs de géométrie et de physique utilisés dans les jeux vidéo. L'ensemble forme un simulateur en temps réel souple qui reproduit les caractéristiques des mondes imaginaires dans lesquels se déroulent les jeux. Le but visé par un moteur de jeu est de permettre à une équipe de développement de se concentrer sur le contenu et le déroulement du jeu plutôt que la résolution de problèmes informatiques[1].

L’utilisation d’un moteur de jeu nous a donc permis de concentrer nos efforts sur le gameplay du jeu. Notre choix s’est porté vers Unity en raison de son accessibilité, notamment grâce à sa documentation très fournie.

### GitHub et la gestion de version
#### Gestion de version
Un gestionnaire de version est un système qui enregistre l'évolution d'un fichier ou d'un ensemble de fichiers au cours du temps de manière à ce qu'on puisse rappeler une version antérieure d'un fichier à tout moment[2]. Le système de gestion de version git permet de créer un dépôt distant où sont stockés des fichiers et leurs différentes versions. Il permet aussi aux utilisateurs de copier ce dépôt sur leur machine et de mettre à jour le dépôt distant à partir de leurs modifications locales.

#### GitHub
GitHub est centré vers l'aspect social du développement. En plus d'offrir l'hébergement de projets avec Git, le site offre de nombreuses fonctionnalités habituellement retrouvées sur les réseaux sociaux comme les flux, la possibilité de suivre des personnes ou des projets ainsi que des graphes de réseaux pour les dépôts. GitHub offre aussi la possibilité de créer un wiki et une page web pour chaque dépôt. Le site offre aussi un logiciel de suivi de problèmes. GitHub propose aussi l'intégration d'un grand nombre de services externes, tels que l'intégration continue, la gestion de versions, badges, chat basés sur les projets, etc[3].

L’utilisation de GitHub et de git nous a donc permis de répondre à l’une des problématiques de départ de manière efficace, car elle nous permettait de travailler

### Chronologie du projet
Dans un premier temps, il a fallu que les membres du groupe se forment à utiliser Unity et Git. La maîtrise de ces outils par tous les membres du groupe était nécessaire et son apprentissage a demandé un certain temps.

### Réalisation
#### Unity Assets Store
Afin de réaliser le jeu, nous avions besoin de modèles d’objets préfabriqués représentant les différents objets de notre jeu (vaisseaux, astéroïdes, etc.). En effet, il ne s’agissait pas de modéliser nous-mêmes des objets aux formes géométriques complexes, mais de modéliser et de coder leur comportement. La première étape consistait donc à télécharger sur l’Asset Store ce qu’on appelle des *Prefabs*. Une fois ces modèles téléchargés, on pouvait les instancier et les faire apparaître dans notre scène

#### Camera, Lumière et Scripts
Dans un premier temps, il fallait régler une caméra et des éclairages pour notre scène. Ces éléments sont statiques dans notre cas. La réalisation du jeu consistait en grande partie à coder le comportement des objets via des Scripts qui leur sont associés. A partir des Script, on pouvait par exemple faire en sorte qu’un objet se déplace via les commandes de l’utilisateur, instancier des objets (vaisseaux ennemis par exemple), afficher des messages à l’écran, etc. Le Scripting a donc eu une part très importante dans notre projet et chacun des membres a dû y participer.

### Répartition des tâches

### Problèmes durant la réalisation
#### Problèmes liés à la gestion de version
La gestion de version nous a posé quelques problèmes. La communication a été très importante dans le sens où à chaque fois qu’un contributeur effectuait un « push » sur le dépôt distant, il devait prévenir les autres contributeurs afin qu’ils récupèrent ses modifications. La gestion des conflits était aussi très importante lorsque deux développeurs modifiaient les mêmes fichiers. Là aussi, toute une méthodologie était à assimiler pour savoir comment gérer efficacement les conflits.

#### Problèmes liés à la gestion des scores/ressources externes
La gestion du stockage des scores a aussi été une source de difficultés. En effet, nous souhaitions sauvegarder le classement des meilleurs scores dans un fichier texte, fichier faisant partie ressource externe du jeu. Cependant, ces ressources ne sont accessibles à partir du jeu qu’en lecture seule. Heureusement, la classe PlayerPrefs nous permettait un accès en lecture et en écriture à un fichier contenant entre autres les préférences du joueur. C’est donc dans ce fichier que sont contenus les meilleurs scores. Nous aurions pu utiliser une base de données stockée sur pour gérer les scores. Cependant, ce n’était pas une nécessité et n’avions pas assez de temps pour réaliser ceci de manière correcte.

### Modélisation/ Diagrammes UML
MonoBehaviour est la classe dont doit hériter chaque Script. Elle contient des méthodes appelées à des moments clés de l’exécution du jeu comme par exemple à la première frame, à chaque frame, etc. Un objet du jeu peut être attaché à plusieurs Scripts comme par exemple les astéroïdes qui sont attachés à Mover (qui détermine leur déplacement), DestroyedByBoundary (pour détruire les instances qui sortent des limites du jeu) et DestroyedByContact (pour détruire les instances touchées par un projectile). Le Script GameController a un rôle assez particulier, car il n’est pas attaché à un objet visible dans la scène. Il est attaché à un objet invisible et qui n’a aucune influence ou interaction avec les autres objets du jeu. Ce script sert à gérer tout ce qui n’est pas en rapport avec le gameplay, comme le score ou la fin du jeu par exemple.

### Conclusion
Ce projet aura été très enrichissant pour nous car en plus de nous permettre d’appliquer les notions de génie logiciel vues en cours, il nous a permis d’avoir une expérience supplémentaire de travail en équipe. Ce projet aura également été l’occasion d’apprendre à utiliser de nouveaux outils très puissants tels que Unity et Git, un nouveau langage de programmation (le C#) et de développer notre créativité.

### Références
[1] Contributeur Wikipédia, « Moteur de jeu », Wikipédia. 28-août-2015.

[2] « Git - À propos de la gestion de version ». [En ligne]. Disponible sur: https://git-
scm.com/book/fr/v1/D%C3%A9marrage-rapide-%C3%80-propos-de-la-gestion-de-
version. [Consulté le: 13-déc-2015].

[3] Contributeur Wikipédia, « <span lang=“en”>GitHub</span> », Wikipédia. 30-oct-2015.
